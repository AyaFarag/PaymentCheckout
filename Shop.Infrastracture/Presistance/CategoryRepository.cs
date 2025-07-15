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
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
