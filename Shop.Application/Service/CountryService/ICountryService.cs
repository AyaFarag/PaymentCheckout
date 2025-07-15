using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Shop.Application.Service.CountryService
{
    public interface ICountryService
    {
        // business logic
        Task<IEnumerable<CountryDTO>> ShowAllCountry();
        Task<CountryDTO> ShowCountryById(int id);
        Task insertCountry(CreateCountryDTO country);
        Task<bool> updateCountry(int id, CountryDTO country);
        Task<string> deleteCountry(int id);

    }
}
