using AutoMapper;
using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;


namespace Shop.Application.Automapper
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, CountryDTO>().ReverseMap();

        }
    }
}
