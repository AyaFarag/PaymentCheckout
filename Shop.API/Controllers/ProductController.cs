using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO.ProductDTO;
using Shop.Application.Service.ProductService;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            productService = _productService;    
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductDTO createProductDto)
        {
            try
            {
                await productService.CreateProduct(createProductDto);
                return Ok("Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
