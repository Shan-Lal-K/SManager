using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class AspUsersDto : TimeEntityDto
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string UserId { get; set; }
        public bool IsTwoFactor { get; set; }

    }
}
