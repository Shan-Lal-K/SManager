using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class ExamDto : TimeEntityDto
    {
        public string ExamName { get; set; }
        public string? ExamDescription { get; set; }
    }
}
