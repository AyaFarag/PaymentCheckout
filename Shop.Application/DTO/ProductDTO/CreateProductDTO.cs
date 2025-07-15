using Shop.Application.DTO.BrandDTO;
using Shop.Application.DTO.CategoryDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.DTO.ProductDTO
{
    public class CreateProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public CreateCategoryDTO Category { get; set; }
        public CreateBrandDTO Brand { get; set; }


    }
}
