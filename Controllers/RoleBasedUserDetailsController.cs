using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.SContext;
using STUDMANAG.Services.RoleAspUserDetailsService;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleBasedUserDetailsController : ControllerBase
    {
        private readonly IRoleBasedUserDetailsService _rolebaseduserdetailsService;
        private readonly SDbcontext _sDbcontext;
        public RoleBasedUserDetailsController(IRoleBasedUserDetailsService rolebaseduserdetailsService, SDbcontext sDbcontext_)
        {
            _rolebaseduserdetailsService = rolebaseduserdetailsService;
            _sDbcontext = sDbcontext_;
        }

        [HttpPost("CREATEUSERROLEDETAILS")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CREATEUSERROLEDETAILS(AspUserRoleDetailsDto Dto)
        {
            try
            {
                if (Dto == null)
                {
                    return BadRequest("Data is required to create a new entry");
                }

                else
                {
                    var result = _rolebaseduserdetailsService.CreateRoleUser(Dto);
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UPDATEUSERROLEDETAILS")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> UPDATEUSERROLEDETAILS(AspUserRoleDetailsDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("NO DATA FOUND TO UPDATE");
                }
                else
                {
                    var result = _rolebaseduserdetailsService.UpdateRoleUser(dto).Result;
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteRoleUser/{id}")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteRoleUser(int Id)
        {
            try
            {
                var DatatoDelete = _sDbcontext.AspUserRoleDetails.FindAsync(Id).Result;
                if (DatatoDelete == null)
                {
                    return BadRequest("Role with the specified ID was not found to delete");
                }
                else
                {
                    var Data = _rolebaseduserdetailsService.DeleteRoleUser(Id).Result;
                    if (Data == true)
                    {
                        return Ok("DELETED SUCCESSFULLY");
                    }
                    else
                    {
                        return BadRequest("Issue With Deleting Specific RoleUser");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllRolesByUser")]
        [Authorize]
        [ProducesResponseType(typeof(List<AspUserRoleDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllRolesByUser(string UserId)
        {
            try
            {
                if (UserId == null)
                {
                    return BadRequest("Please Provide a UserId");
                }
                else
                {
                    var Data = _rolebaseduserdetailsService.GetAllRolesByUser(UserId).Result;
                    return Ok(Data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAllUserByRoles")]
        [Authorize]
        [ProducesResponseType(typeof(List<AspUserRoleDetailsDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllUserByRoles(string RoleId)
        {
            try
            {
                if (RoleId == null)
                {
                    return BadRequest("Please Provide a RoleId");
                }
                else
                {
                    var Data = _rolebaseduserdetailsService.GetAllRolesByUser(RoleId).Result;
                    return Ok(Data);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
