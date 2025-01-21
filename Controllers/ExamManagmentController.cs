using Microsoft.AspNetCore.Mvc;
using STUDMANAG.DTO;
using STUDMANAG.Services.ExamManageService;
using System.Net;

namespace STUDMANAG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamManagmentController : ControllerBase
    {
        private readonly IExamManagmentService _examService;
        public ExamManagmentController(IExamManagmentService examService)
        {
            _examService = examService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateExam(ExamDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Please provide data");
            }
            try
            {
                var result = _examService.CreateExam(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error found");
            }
        }

        //[HttpGet("")]
    }
}
