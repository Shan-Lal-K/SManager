using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class StudentDto : TimeEntityDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int RollNo { get; set; }
        public string AdmissionNumber { get; set; }
        public DateTime DOB { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }

    }
}
