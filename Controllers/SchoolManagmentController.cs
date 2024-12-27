using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.SchoolManagmentService;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolManagmentController : ControllerBase
    {
        private readonly ISchoolManagmentService _schoolService;
        public SchoolManagmentController(ISchoolManagmentService schoolService_)
        {
            _schoolService = schoolService_;
        }

        [HttpPost("CREATESCHOOL")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Unauthorized)]
        public async Task<IActionResult> CREATESCHOOL(SchoolDto dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest("Data is required to create a new entry");
                }
                else
                {
                    var result = _schoolService.CreateSchool(dto);
                    return Ok(new { Message = "New School Added SuccessFully" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpGet("GETBYID")]
        [Authorize]
        [ProducesResponseType(typeof(SchoolDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GETBYID(int Id)
        {
            try
            {
                if (Id == 0 || Id == null)
                {
                    return BadRequest("Id Required");
                }
                else
                {
                    var result = _schoolService.GetSchoolById(Id).Result;
                    if (result.SchoolName == null)
                    {
                        return BadRequest("No data found");
                    }
                    else
                    {
                        return Ok(result);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }

        [HttpDelete("DELETESCHOOL")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DELETESCHOOL(int id)
        {
            try
            {
                var result = _schoolService.DeleteSchool(id).Result;
                if (result == 0)
                {
                    return BadRequest("No Data Found To Delete");
                }
                else
                {
                    return Ok("Deleted Successfully");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }
        }


    }
}
