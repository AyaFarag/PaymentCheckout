using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Dictionary<int, Product>> getProductsByIds(List<int> productIds);
    }
}
