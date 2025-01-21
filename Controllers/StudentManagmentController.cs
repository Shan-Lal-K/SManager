using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.StudentManage;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentManagmentController : ControllerBase
    {
        private readonly IStudentManagmentService _studentService;
        private StudentManagmentController(IStudentManagmentService studentService)
        {
            _studentService = studentService;
        }
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateStudent(StudentDto dto)
        {
            if (dto == null)
            {
                return BadRequest("No data found to create a student");
            }
            try
            {
                var result = _studentService.SaveStudent(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("An error occured while creating a student , Please try agian later");
            }
        }

        [HttpGet("GetStudentById")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetStudentById(int StudentId)
        {
            if (StudentId == 0)
            {
                return BadRequest("Please provide a Id");
            }
            try
            {
                var studentDetail = _studentService.GetStudentById(StudentId);
                if (studentDetail == null)
                {
                    return BadRequest("No data corresponding this Id");
                }
                return Ok(studentDetail);
            }
            catch (Exception ex)
            {
                return BadRequest("No data corresponding this Id");
            }
        }

        [HttpPut("UpdateStudent")]
        [ProducesResponseType(typeof(StudentDto), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateStudent(StudentDto dto)
        {
            if (dto == null)
            {
                return BadRequest("No data to update");
            }
            try
            {
                var result = _studentService.UpdateStudent(dto);
                if (result.Result == 0)
                {
                    return BadRequest("Not Updated");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Found");
            }
        }
        [HttpDelete("DeleteStudent")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            if (studentId == 0)
            {
                return BadRequest("Please provide a Id");
            }
            try
            {
                var result = _studentService.DeleteStudent(studentId);
                if (result.Result == false)
                {
                    return BadRequest("Not Deleted");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error Found");
            }
        }
        [HttpGet("GetAllStudents")]
        [ProducesResponseType(typeof(List<StudentDto>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAllStudents(int studentId)
        {
            try
            {
                var result = _studentService.GetAllStudents();
                if (result == null)
                {
                    return BadRequest("No data to show");
                }
                else
                {
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error Found");
            }
        }

    }
}
