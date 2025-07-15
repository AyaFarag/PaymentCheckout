using Microsoft.AspNetCore.Mvc;
using Shop.Application.DTO.CountryDTO;
using Shop.Application.Service.CountryService;
using Shop.Domain.Entities;


namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        public readonly ICountryService countryService;
        public CountryController(ICountryService _countryService)
        {
            countryService = _countryService;
        }
        
        [HttpGet]
        public async Task<IActionResult>  Get()
        {
            try
            {
                return Ok(await countryService.ShowAllCountry());

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Ok(await countryService.ShowCountryById(id));

            }
            catch (Exception ex) { 
                return  BadRequest(ex.Message);
            }
        }

        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCountryDTO value)
        {
            try
            {
                await countryService.insertCountry(value);
                return Ok("Created");
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
           
        }

        // PUT api/<CountryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryDTO value)
        {
            try
            {
                await countryService.updateCountry(id, value);
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
                await countryService.deleteCountry(id);
                return Ok("Deleted");

            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
