using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ApiProject.Domain;
using ApiProject.Services;
using Microsoft.AspNetCore.Http;
using ApiProject.Services.userRole;

namespace ApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UserRoleController : ControllerBase
    {

        protected readonly IUserRoleServices _UserRoleService;

        public UserRoleController(IUserRoleServices userRoleService)
        {
            _UserRoleService = userRoleService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var userRoles = await _UserRoleService.GetAllUserRoleAsync();
            return Ok(userRoles);
        }



        [HttpGet("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById(int Id)
        {
            var userRole = await _UserRoleService.GetUserRoleByIdAsync(Id);
            return Ok(userRole);
        }




        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult AddUserRole([FromBody] UserRole userRole)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _UserRoleService.AddUserRole(userRole);
            return CreatedAtAction(nameof(GetById), new { Id = userRole.Id }, userRole);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult UpdateUserRole([FromBody] UserRole userRole)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _UserRoleService.UpdateUserRole(userRole);
            return Ok();
        }



        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteUserRole(int Id)
        {
            _UserRoleService.DeleteUserRole(Id);
            return Ok();
        }

    }
}