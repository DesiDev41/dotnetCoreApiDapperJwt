using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiProject.Domain;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]




    public class DeveloperController : ControllerBase
    {

        protected readonly IDeveloperServices _developerService;


        public DeveloperController(IDeveloperServices developerService)
        {
            _developerService = developerService;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var developers = await _developerService.GetAllDeveloperAsync();
            return Ok(developers);
        }



        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int Id)
        {
            var developer = await _developerService.GetDeveloperByIdAsync(Id);
            return Ok(developer);
        }


        [Route("[action]")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetByEmail(string Email)
        {
            var developer = await _developerService.GetDeveloperByEmailAsync(Email);
            return Ok(developer);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddDeveloper([FromBody] Developer developer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.AddDeveloper(developer);
            return CreatedAtAction(nameof(GetById), new { Id = developer.Id }, developer);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateDeveloper([FromBody] Developer developer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _developerService.UpdateDeveloper(developer);
            return Ok();
        }



        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteDeveloper(int Id)
        {
            _developerService.DeleteDeveloper(Id);
            return Ok();
        }

    }
}