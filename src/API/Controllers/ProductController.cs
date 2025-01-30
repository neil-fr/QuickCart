using Microsoft.AspNetCore.Mvc;
using QuickCart.Application.DTOs;
using QuickCart.Application.Services;
using QuickCart.Core.Exceptions;
using QuickCart.Core.Interfaces;

namespace QuickCart.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService)
        : ControllerBase
    {
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<ProductResponseDto>>> GetById(int id)
        {
            var response = await productService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse<IEnumerable<ProductResponseDto>>>> GetAll()
        {
            var response = await productService.GetAllAsync();
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<int>>> Create(ProductCreateDto productDto)
        {
            var response = await productService.CreateAsync(productDto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data }, response);
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
