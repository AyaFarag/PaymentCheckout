using Shop.Application.DTO.ProductDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.ProductService
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDTO>> showAllProducts();

        Task<ProductResponseDTO> ShowProductById(int id);

        Task CreateProduct(CreateProductDTO createProductDTO);
        Task<bool> UpdateProduct(int id, UpdateProductDTO updateProductDTO);
        Task DeleteProduct(int id);
    }
}
