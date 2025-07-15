using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using Shop.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastracture.Presistance
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public readonly ApplicationDBContext _dbContext;
        public OrderRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<object> createOrder(Order order)
        {
            
            var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                _dbContext.Orders.Add(order);
                await _dbContext.SaveChangesAsync();  // saves order and stock updates

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            return transaction;
        }
    }
}
