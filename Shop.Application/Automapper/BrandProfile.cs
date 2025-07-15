using AutoMapper;
using Shop.Application.DTO.BrandDTO;
using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Automapper
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<Brand, CreateBrandDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>().ReverseMap();
        }
    }
}
