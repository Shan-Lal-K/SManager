using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.PrincipalManagmentService;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalManagmentController : ControllerBase
    {
        private readonly IPrincipalService _principalService;
        public PrincipalManagmentController(IPrincipalService principalService)
        {
            _principalService = principalService;
        }

        [HttpPost]
        [Authorize]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int),(int) HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreatePrincipal (PrincipalDto principalDto)
        {
            try
            {
                var result = _principalService.CreatePrincipal(principalDto);
                if (result.Id != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Not Added ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpPut("UpdatePrincipal")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdatePrincipal(PrincipalDto principalDto)
        {
            try
            {
                var result = _principalService.UpdatePrincipal(principalDto);
                if (result.Id != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Not Added ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpDelete("DeletePrincipal")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeletePrincipal(int id)
        {
            try
            {
                var result = _principalService.DeletePrincipal(id);
                if (result.Id != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Not Added ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpGet("GetPrincipalById")]
        [Authorize]
        [ProducesResponseType(typeof(PrincipalDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetPrincipalById(int id)
        {
            try
            {
                var result = _principalService.GetPrincipalById(id);
                if (result.Id != 0)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Not Data Found ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

        [HttpGet("GetAll")]
        [Authorize]
        [ProducesResponseType(typeof(List<PrincipalDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = _principalService.GetAll();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No entries found in the database ");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }

    }
}
