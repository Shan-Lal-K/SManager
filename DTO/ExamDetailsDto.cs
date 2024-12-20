using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class ExamDetailsDto : TimeEntityDto
    {
        public int? ForClassId { get; set; }
        public DateTime? ConductingDateFrom { get; set; }
        public DateTime? ConductingDateTo { get; set; }
        public int? SubjectId { get; set; }
    }
}
