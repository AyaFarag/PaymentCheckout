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
    public class ProductRepository : Repository<Product> , IProductRepository
    {
        public readonly ApplicationDBContext _dbContext;
        public ProductRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext = context;
        }
        

        public async Task<Dictionary<int, Product>> getProductsByIds(List<int> productIds)
        {
            var products = await _dbContext.Products
                .Where(p => productIds.Contains(p.Id))
                .ToDictionaryAsync(p => p.Id);
            return products;
        }
    }
}
