using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.RolesService;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _roleService;
        public RolesController(IRolesService roleService_)
        {
            _roleService = roleService_;
        }

        [HttpPost("CREATEROLE")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        //[ProducesResponseType(typeof(int), BadRequestResult)]
        public async Task<IActionResult> CREATEROLE(RoleDto Dto)
        {
            if (Dto == null)
            {
                return BadRequest("Data is required to create a new entry");
            }
            else
            {
                var result = _roleService.RoleCreation(Dto);
                return Ok(result);
            }
        }

        [HttpDelete("DELETEROLE/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> DELETEROLE(int Id)
        {
            try
            {
                var result = _roleService.RoleDelete(Id);
                if (result == null)
                {
                    return BadRequest("Role with the specified ID was not found");
                }
                return Ok(new { Message = "Role deleted successfully." });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GETROLEBYID/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GETROLEBYID(int Id)
        {
            try
            {
                var resultDto = _roleService.GetRoleById(Id).Result;
                if (resultDto == null)
                {
                    return BadRequest("Role with the specified ID was not found");
                }
                else
                {
                    return Ok(resultDto);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GETALLROLE")]
        [Authorize]
        [ProducesResponseType(typeof(List<RoleDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> GETALLROLE()
        {
            try
            {
                var RolesList = _roleService.GetRoles();
                if (RolesList == null)
                {
                    return BadRequest("NO ENTRIES FOUND");
                }
                else
                {
                    return Ok(RolesList);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UPDATEROLE")]
        [Authorize]
        [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        //[ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UPDATEROLE(RoleDto Dto)
        {
            try
            {
                if (Dto == null)
                {
                    return BadRequest("NO DATA FOUND TO UPDATE");
                }
                else
                {
                    var result = _roleService.RoleUpdate(Dto).Result;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
