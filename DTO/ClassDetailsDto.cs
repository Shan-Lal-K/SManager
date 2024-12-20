using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class ClassDetailsDto : TimeEntityDto
    {
        public int ClassName { get; set; }
        public int? ClassDivision { get; set; }
        public int? ClassTeacherId { get; set; }
    }
}
