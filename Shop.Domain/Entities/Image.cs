using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string Size { get; set; }
        public string Extention { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
