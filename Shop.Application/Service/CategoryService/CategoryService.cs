using AutoMapper;
using Shop.Application.DTO.CategoryDTO;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CategoryService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task<string> deleteCategory(int id)
        {
            await unitOfWork.Repository<Category>().DeleteAsync(id);
            return "";
        }

        public async Task insertCategory(CreateCategoryDTO countryDTO)
        {
            var country = mapper.Map<Category>(countryDTO);
            await unitOfWork.Repository<Category>().AddAsync(country);
        }

        public async Task<IEnumerable<CategoryDTO>> ShowAllCategory()
        {
            var cats = await unitOfWork.Repository<Category>().GetAllAsync();
            return mapper.Map<IEnumerable<CategoryDTO>>(cats);
        }

        public async Task<CategoryDTO> ShowCategoryById(int id)
        {
            var cat = await unitOfWork.Repository<Category>().GetByIdAsync(id);
            return mapper.Map<CategoryDTO>(cat);
        }

        public async Task<bool> updateCategory(int id, CategoryDTO country)
        {
            var cat = mapper.Map<Category>(country);
            var updatedCat = await unitOfWork.Repository<Category>().UpdateAsync(cat);
            return updatedCat != null;

        }
    }
}
