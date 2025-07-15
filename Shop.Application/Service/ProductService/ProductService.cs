using AutoMapper;
using Shop.Application.DTO.ProductDTO;
using Shop.Domain.Entities;
using Shop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Service.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }
        public async Task CreateProduct(CreateProductDTO createProductDTO)
        {
            var product = mapper.Map<Product>(createProductDTO);
            await unitOfWork.Repository<Product>().AddAsync(product); 
            // add new product
            // new category 
            // new brand
        }

        public async Task DeleteProduct(int id)
        {
            await unitOfWork.Repository<Product>().DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseDTO>> showAllProducts()
        {
            var products = await unitOfWork.Repository<Product>().GetAllAsync();
            var response = mapper.Map<IEnumerable<ProductResponseDTO>>(products);
            return response;
        }

        public async Task<ProductResponseDTO> ShowProductById(int id)
        {
            var product = await unitOfWork.Repository<Product>().GetByIdAsync(id);
            return mapper.Map<ProductResponseDTO>(product);
        }

        public async Task<bool> UpdateProduct(int id, UpdateProductDTO updateProductDTO)
        {
            if(id != updateProductDTO.Id)
            {
                throw new ArgumentException("Id not identical");
            }
            var product = mapper.Map<Product>(updateProductDTO);
            var updatedProduct =  await unitOfWork.Repository<Product>().UpdateAsync(product);
            return updatedProduct != null;
        }
    }
}
