using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class TeacherSubjectDetailsDto : TimeEntityDto
    {
        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
    }
}
