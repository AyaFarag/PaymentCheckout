using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation
        public ICollection<Product> Products { get; set; }
    }
}
