using Shop.Application.DTO.CategoryDTO;
using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Automapper
{
    public class CategoryProfile : BrandProfile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CreateCategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
