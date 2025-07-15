using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO.CategoryDTO;
using Shop.Application.Service.CategoryService;
using Shop.Domain.Interfaces;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService _categoryService)
        {
             categoryService = _categoryService;   
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                return Ok(await categoryService.ShowAllCategory());

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) 
        {
            try
            {
                var cat = await categoryService.ShowCategoryById(id);
                return Ok(cat);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Post( [FromBody] CreateCategoryDTO categoryDTO)
        {
            try
            {
                await categoryService.insertCategory(categoryDTO);
                return Ok("Created");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id , [FromBody] CategoryDTO categoryDTO)
        {
            try
            {
                await categoryService.updateCategory(id, categoryDTO);
                return Ok("Updated");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await categoryService.deleteCategory(id);
                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
