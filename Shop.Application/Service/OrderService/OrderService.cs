using Microsoft.EntityFrameworkCore;
using Shop.Application.Service.CartService;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartService cartService;
        public OrderService(IOrderRepository _orderRepository, ICartService _cartService)
        {
            orderRepository = _orderRepository;
            cartService = _cartService;
                
        }

      
    }
}
