using AutoMapper;
using FluentValidation;
using Shop.Application.DTO.CountryDTO;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.CountryService
{
    public class CountryService : ICountryService
    {
        private readonly IValidator<Country> _validator;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CountryService(
           
            IUnitOfWork unitOfWork,
            IValidator<Country> validator
            , ICountryRepository countryRepository,
            IMapper mapper)
        {
           
            _unitOfWork = unitOfWork;
            _validator = validator;
            _mapper = mapper;

        }

        public async Task<string> deleteCountry(int id)
        {
            await _unitOfWork.Repository<Country>().DeleteAsync(id);
            return "Deleted";
        }

        public async Task insertCountry(CreateCountryDTO countryDTO)
        {
            var country = _mapper.Map<Country>(countryDTO);
            await _unitOfWork.Repository<Country>().AddAsync(country);
        }

        public async Task<IEnumerable<CountryDTO>> ShowAllCountry()
        {
            try
            {
                var countries = await _unitOfWork.Repository<Country>().GetAllAsync();
                return _mapper.Map<IEnumerable<CountryDTO>>(countries); 

            }
            catch (System.Exception ex)
            {
                // Log exception (optional)
                throw new System.Exception("An error occurred while retrieving countries.", ex);
            }
        }

        public async Task<CountryDTO> ShowCountryById(int id)
        {
            var country = await _unitOfWork.Repository<Country>().GetByIdAsync(id);
            return _mapper.Map<CountryDTO>(country);
                
        }

        public async Task<bool> updateCountry(int id, CountryDTO countryDto)
        {
            var country = _mapper.Map<Country>(countryDto);
            var updatedcountry = await _unitOfWork.Repository<Country>().UpdateAsync(country);
            return updatedcountry != null;
        }
    }
}
