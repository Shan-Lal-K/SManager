using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class StudentAcademicDetailDto : TimeEntityDto
    {
        public int ClassId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public int? RollNo { get; set; }
        public string? MedicalDetails { get; set; }
        public int? StudentId { get; set; }
    }
}
