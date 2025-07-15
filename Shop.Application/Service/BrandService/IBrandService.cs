using Shop.Application.DTO.BrandDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.BrandService
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandDTO>> ShowAllBrands();
        Task<BrandDTO> ShowBrandById(int id);
        Task insertBrand(CreateBrandDTO brandDTO);
        Task<bool> updateBrand(int id, BrandDTO brandDTO);
        Task<string> deleteBrand(int id);
    }
}
