using Shop.Application.DTO.CategoryDTO;
using Shop.Application.DTO.CountryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.CategoryService
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> ShowAllCategory();
        Task<CategoryDTO> ShowCategoryById(int id);
        Task insertCategory(CreateCategoryDTO categoryDTO);
        Task<bool> updateCategory(int id, CategoryDTO categoryDTO);
        Task<string> deleteCategory(int id);
    }
}
