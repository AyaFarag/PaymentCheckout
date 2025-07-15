using AutoMapper;
using Shop.Application.DTO.ProductDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Automapper
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductDTO>().ReverseMap();
            CreateMap<Product, ProductResponseDTO>().ReverseMap();

            CreateMap<Product, UpdateProductDTO>().ReverseMap();

        }
    }
}
