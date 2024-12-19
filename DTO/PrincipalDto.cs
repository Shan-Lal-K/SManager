using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class PrincipalDto : TimeEntityDto
    {
        public string FirstName { get; set; }
        public string? MiddeName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int? BloodGroup { get; set; }
        public int Qualification { get; set; }
        public string Address { get; set; }
        public int? MartialStatus { get; set; }
        public int? Gender { get; set; }
        public string? PhotoUrl { get; set; }
        public string PhoneContact { get; set; }
        public string ContactEmail { get; set; }
        public int? EmployeeID { get; set; } // EmployeeID Eg:- EMP00047
        public int? Designation { get; set; }
        public int Experience { get; set; }
        public DateTime DateOfJoin { get; set; }
        public string? AspUserId { get; set; } // // Id of User In ASpUsersTable 

    }
}
