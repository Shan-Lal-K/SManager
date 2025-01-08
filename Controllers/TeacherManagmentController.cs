using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.TeacherManagment;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherManagmentController : ControllerBase
    {
        private readonly ITeacherManagmentService _teacherService;
        public TeacherManagmentController(ITeacherManagmentService teacherManagmentService)
        {
            _teacherService = teacherManagmentService;
        }

        [HttpPost("CreateTeacher")]
        [Authorize]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateTeacher(TeacherDto dto)
        {
            if (dto == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid teacher data.");
            }

            try
            {
                var result = await _teacherService.CreateTeacher(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the teacher. Please try again later.");
            }
        }

        [HttpGet("GetTeacherById")]
        [Authorize]
        [ProducesResponseType(typeof(TeacherDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTeacherById(int id)
        {
            try
            {
                var result = _teacherService.GetTeacherById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the teacher. Please try again later.");
            }
        }

        [HttpGet("GetAllTeacher")]
        [Authorize]
        [ProducesResponseType(typeof(List<TeacherDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllTeacher(int id)
        {
            try
            {
                var result = _teacherService.GetAllTeacher();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the teacher. Please try again later.");
            }
        }

        [HttpDelete("DeleteTeacher")]
        [Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            try
            {
                var result = _teacherService.DeleteTeacher(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the teacher. Please try again later.");
            }
        }

        [HttpPut("UpdateTeacher")]
        [Authorize]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateTeacher(TeacherDto dto)
        {
            try
            {
                var result = _teacherService.UpdateTeacher(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred while creating the teacher. Please try again later.");
            }
        }


    }
}
