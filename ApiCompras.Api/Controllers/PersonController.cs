using ApiCompras.Application.DTOs;
using ApiCompras.Application.Services;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.FiltersDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("v1/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<ResultService<List<PersonDTO>>>> GetAsync()
        {
            var result = await _personService.GetAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResultService<PersonDTO>>> GetByIdAsync(
            [FromRoute] int id)
        {
            var result = await _personService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<ActionResult> GetPagedAsync(
            [FromQuery]PersonFilterDb filter)
        {
            var result = await _personService.GetPagedAsync(filter);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ResultService<PersonDTO>>> CreateAsync(
            [FromBody] PersonDTO person)
        {
            var result = await _personService.CreateAsync(person);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<ActionResult<ResultService<PersonDTO>>> UpddateAsync(
            [FromBody]PersonDTO person)
        {
            var result = await _personService.UpdateAsync(person);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ResultService>> DeleteAsync(
            [FromRoute]int id)
        {
            var result = await _personService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
