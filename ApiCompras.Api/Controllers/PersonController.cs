using ApiCompras.Application.DTOs;
using ApiCompras.Application.Services;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Authentication;
using ApiCompras.Domain.FiltersDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompras.Api.Controllers
{
    [ApiController]
    [Route("v1/person")]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly ICurrentUser _currentUser;
        private List<string> _permissionNeeded = new List<string>() { "Admin" };
        private readonly List<string> _permissionUser;
        public PersonController(
            IPersonService personService,
            ICurrentUser currentUser)
        {
            _personService = personService;
            _currentUser = currentUser;
            _permissionUser = _currentUser.Permissions.Split(",").ToList() ?? new List<string>();
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            _permissionNeeded.Add("BuscaPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetAsync();

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id)
        {
            _permissionNeeded.Add("BuscaPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetByIdAsync(id);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("paged")]
        public async Task<IActionResult> GetPagedAsync(
            [FromQuery] PersonFilterDb filter)
        {
            _permissionNeeded.Add("BuscaPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.GetPagedAsync(filter);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(
            [FromBody] PersonDTO person)
        {
            _permissionNeeded.Add("CadastroPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.CreateAsync(person);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpddateAsync(
            [FromBody] PersonDTO person)
        {
            _permissionNeeded.Add("EditaPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();

            var result = await _personService.UpdateAsync(person);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id)
        {
            _permissionNeeded.Add("DeletaPessoa");
            if (!ValidatePermission(_permissionUser, _permissionNeeded))
                return Forbidden();
            var result = await _personService.DeleteAsync(id);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
