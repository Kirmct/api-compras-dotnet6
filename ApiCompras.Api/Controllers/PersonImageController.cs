using ApiCompras.Application.DTOs.PersonImage;
using ApiCompras.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers
{
    [ApiController]
    [Route("v1/person-image")]
    public class PersonImageController : ControllerBase
    {
        private readonly IPersonImageService _personImageService;

        public PersonImageController(IPersonImageService personImageService)
        {
            _personImageService = personImageService;
        }

        [HttpPost("base-64")]
        public async Task<ActionResult> CreateBase64Async(
            [FromBody]PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageBase64Async(personImageDTO);  
            
            if(!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("url")]
        public async Task<ActionResult> CreateImageUrlAsync(
            [FromBody] PersonImageDTO personImageDTO)
        {
            var result = await _personImageService.CreateImageUrlAsync(personImageDTO);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
