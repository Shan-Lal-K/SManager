using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class AspUsersDto : TimeEntityDto
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
