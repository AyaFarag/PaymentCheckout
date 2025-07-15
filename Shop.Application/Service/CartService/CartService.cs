using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Shop.Application.DTO.CartDTO;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using IDatabase = StackExchange.Redis.IDatabase;

namespace Shop.Application.Service.CartService
{
    public class CartService : ICartService
    {
        private readonly StackExchange.Redis.IDatabase _redis;
        private readonly IHttpContextAccessor _ctxAccessor;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public CartService(IConnectionMultiplexer redis, IHttpContextAccessor ctxAccessor,
            IUnitOfWork unitOfWork, IOrderRepository _orderRepository, IProductRepository _productRepository)
        {
            _redis = redis.GetDatabase();
            _ctxAccessor = ctxAccessor;
            _unitOfWork = unitOfWork;
            orderRepository = _orderRepository;
            productRepository = _productRepository;
        }

        public string GetCartOwnerId()
        {
            var context = _ctxAccessor.HttpContext
                     ?? throw new InvalidOperationException("No HTTP context");

            var isAuthenticated = _ctxAccessor.HttpContext.User.Identity?.IsAuthenticated ?? false;

            if (isAuthenticated)
            {
                return _ctxAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                       ?? throw new Exception("Authenticated user has no ID claim");
            }

            // Ensure session is enabled
            if (string.IsNullOrEmpty(_ctxAccessor.HttpContext.Session.Id))
                throw new Exception("Session not available");

            //return $"guest:{_ctxAccessor.HttpContext.Session.Id}";
            return "b6a7f0b3-67dc-2f96-c971-d0cd17a99373";
        }

        private string GetCartKey(string userId) => $"cart:user:{userId}";

        public async Task<Cart> AddItemAsync(CartItem item)
        {
            string userId = GetCartOwnerId();
            var key = GetCartKey(userId);
            Cart cart;

            var existingData = await _redis.StringGetAsync(key);
            if (!existingData.HasValue)
            {
                cart = new Cart { UserId = userId };
            }
            else
            {
                cart = JsonConvert.DeserializeObject<Cart>(existingData!) ?? new Cart { UserId = userId };
            }

            var existingItem = cart.Items.FirstOrDefault(i => i.ProductId == item.ProductId);
            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }

            await _redis.StringSetAsync(key, JsonConvert.SerializeObject(cart), TimeSpan.FromSeconds(60));
            return cart;
        }
        public async Task<Cart> GetCartAsync()
        {
            string userId = GetCartOwnerId();
            var key = GetCartKey(userId);
            var data = await _redis.StringGetAsync(key);

            if (!data.HasValue)
                return new Cart { UserId = userId };

            var cart = JsonConvert.DeserializeObject<Cart>(data!)
                       ?? new Cart { UserId = userId };

            return cart;
        }

        public async Task<Cart> UpdateProductQuantityAsync(UpdateCartDto UpdateCartDto)
        {
            string userId = GetCartOwnerId();

            var key = GetCartKey(userId);

            var cart = await GetCartAsync();

            var item = cart.Items.FirstOrDefault(x => x.ProductId == UpdateCartDto.ProductId);
            if (item != null)
            {
                if (UpdateCartDto.Quantity > 0)
                {
                    item.Quantity = UpdateCartDto.Quantity;
                }
                else
                {
                    // Remove item if quantity is 0 or less
                    cart.Items.Remove(item);
                }

                var updatedCartJson =  JsonConvert.SerializeObject(cart);
                await _redis.StringSetAsync(key, updatedCartJson, TimeSpan.FromSeconds(60));

            }

            return cart;
        }


        public async Task RemoveItemAsync(int productId)
        {
            string userId = GetCartOwnerId();
            var carts = await GetCartAsync();
            var updated = carts.Items.Where(x => x.ProductId != productId).ToList();
            await _redis.StringSetAsync(GetCartKey(userId), JsonConvert.SerializeObject(updated), TimeSpan.FromSeconds(60));
        }

        public async Task ClearCartAsync()
        {
            string userId = GetCartOwnerId();
            await _redis.KeyDeleteAsync(GetCartKey(userId));
        }


        public async Task<Domain.Entities.Order> CheckoutAsync()
        {
            var userId = GetCartOwnerId();
            var key = GetCartKey(userId);


            // Step 1: Load Cart
            var cart = await GetCartAsync();
            if (cart.Items == null || !cart.Items.Any())
                throw new InvalidOperationException("Cart is empty.");

            // Step 2: Load Products From DB
            var productIds = cart.Items.Select(i => i.ProductId).ToList();
            Dictionary<int, Product> products = await productRepository.getProductsByIds(productIds);

            
            // Step 3: Validate Stock
            foreach (var item in cart.Items)
            {
                if (!products.ContainsKey(item.ProductId))
                    throw new InvalidOperationException($"Product '{item.ProductId}' not found.");

                var product = products[item.ProductId];

                if (item.Quantity > product.Quantity)
                    throw new InvalidOperationException(
                        $"Insufficient stock for '{product.Name}'. Available: {product.Quantity}, Requested: {item.Quantity}"
                    );
                
                // Step 4: Deduct Stock
                product.Quantity -= item.Quantity;

            }


            // Step 5: Create Order Object
            var order = new Domain.Entities.Order
            {
                UserId = userId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = cart.Total,
                Items = cart.Items.Select(i => new OrderItems
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice
                }).ToList()
            };

            // Step 6: Save to DB with Transaction
            await orderRepository.createOrder(order);

            // Step 7: Clear Redis Cart
            await _redis.KeyDeleteAsync(key);

            return order;


        }

        // add enum to order status
    }
}


