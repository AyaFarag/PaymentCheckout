using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public int BrandId { get; set; }

        public Category Category { get; set; }
        public Brand Brand { get; set; }
        public ICollection<Review> Reviews { get; set; }
      //  public ICollection<CartItem> CartItems { get; set; }
        public ICollection<OrderItems> OrderItems { get; set; }
        public ICollection<Image> Images { get; set; }
        public ICollection<Color> Colors { get; set; }

        public ICollection<Country> Countries { get; set; }



    }
}
