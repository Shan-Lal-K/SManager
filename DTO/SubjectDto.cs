using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class SubjectDto : TimeEntityDto
    {
        public string SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }
    }
}
