using ApiCompras.Application.DTOs;
using ApiCompras.Application.Services;
using ApiCompras.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers;

[ApiController]
[Route("v1/produto")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<ResultService<ICollection<ProductDTO>>>> GetAllAsync()
    {
        var result = await _productService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResultService<ProductDTO>>> GetByIdAsync(
        [FromRoute]int id)
    {
        var result = await _productService.GetByIdAsync(id);

        if(!result.IsSuccess)
            return NotFound(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ResultService<ProductDTO>>> CreateAsync(
        [FromBody]ProductDTO productDTO)
    {
        var result = await _productService.CreateAsync(productDTO);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ResultService<ProductDTO>>> UpdateAsync(
         [FromBody] ProductDTO productDTO)
    {
        var result = await _productService.UpdateAsync(productDTO);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<ResultService<ProductDTO>>> DeleteAsync(
        [FromRoute] int id)
    {
        var result = await _productService.DeleteAsync(id);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }
}
