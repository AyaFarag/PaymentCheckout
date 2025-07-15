using Shop.Application.DTO.CartDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.CartService
{
    public interface ICartService
    {
        Task<Cart> AddItemAsync(CartItem item);
        Task<Cart> GetCartAsync();
        Task<Cart> UpdateProductQuantityAsync(UpdateCartDto UpdateCartDto);

        Task ClearCartAsync();
        Task RemoveItemAsync(int productId);
        Task<Order> CheckoutAsync();

    }
}
