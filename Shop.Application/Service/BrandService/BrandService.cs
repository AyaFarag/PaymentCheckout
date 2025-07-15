using AutoMapper;
using Shop.Application.DTO.BrandDTO;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.BrandService
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BrandService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<string> deleteBrand(int id)
        {
            await unitOfWork.Repository<Brand>().DeleteAsync(id);
            return "Deleted";
        }

        public async Task insertBrand(CreateBrandDTO brandDTO)
        {
            var brand = mapper.Map<Brand>(brandDTO);
            await unitOfWork.Repository<Brand>().AddAsync(brand);
        }

        public async Task<IEnumerable<BrandDTO>> ShowAllBrands()
        {
            var brands = await unitOfWork.Repository<Brand>().GetAllAsync();
            return mapper.Map<IEnumerable<BrandDTO>>(brands);
        }

        public async Task<BrandDTO> ShowBrandById(int id)
        {
            var brand = await unitOfWork.Repository<Brand>().GetByIdAsync(id);
            return mapper.Map<BrandDTO>(brand);
        }

        public async Task<bool> updateBrand(int id, BrandDTO brandDTO)
        {
            var brand = mapper.Map<Brand>(brandDTO);
            var result  = await unitOfWork.Repository<Brand>().UpdateAsync(brand);
            return (result!=null) ? true : false;
        }
    }
}
