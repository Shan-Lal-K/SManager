using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class StudentEntity : TimeEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int? BloodGroup { get; set; }
        public string? ContactNo { get; set; }
        public string? ContactEmail { get; set; }
        public string? Photo { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianEmail { get; set; }
    }
}
