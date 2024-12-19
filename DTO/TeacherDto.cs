using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class TeacherDto : TimeEntityDto
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public int? BloodGroup { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? EmployeeId { get; set; }
        public DateTime? DateOfJoin { get; set; }
        public int Qualification { get; set; }
        public int Experience { get; set; }
        public int? AspUserId { get; set; } // Id of User In ASpUsersTable 
    }
}
