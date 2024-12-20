using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class StudentAcademicDetail : TimeEntity
    {
        public int ClassId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public int? RollNo { get; set; }
        public string? MedicalDetails { get; set; }
        public int? StudentId { get; set; }
    }
}
