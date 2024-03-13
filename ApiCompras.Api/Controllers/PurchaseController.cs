using ApiCompras.Application.DTOs;
using ApiCompras.Application.Services;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Validation;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers
{
    [ApiController]
    [Route("v1/purchase")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        [HttpGet]
        public async Task<ActionResult<ResultService<ICollection<PurchaseDTO>>>> GetAllAsync()
        {
            return Ok(await _purchaseService.GetAllAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ResultService<PurchaseDTO>>> GetByIdAsync(
            [FromRoute]int id)
        {
            var result = await _purchaseService.GetByIdAsync(id);
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<ResultService<PurchaseDTO>>> CreateAsync(
            [FromBody]PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.CreateAsync(purchaseDTO);

                if (!result.IsSuccess)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (DomainValidationException e)
            {
                return BadRequest(ResultService.Fail(e.Message));
            }           
        }

        [HttpPut]
        public async Task<ActionResult<ResultService<PurchaseDTO>>> UpdateAsync(
           [FromBody] PurchaseDTO purchaseDTO)
        {
            try
            {
                var result = await _purchaseService.UpdateAsync(purchaseDTO);

                if (!result.IsSuccess)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (DomainValidationException e)
            {
                return BadRequest(ResultService.Fail(e.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultService>> DeleteAsync(
            [FromRoute]int id)
        {
            var result = await _purchaseService.DeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
