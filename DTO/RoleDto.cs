using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class RoleDto : TimeEntityDto
    {
        public string RoleName { get; set; } = string.Empty;
        public string RoleDescription { get; set; } = string.Empty;
    }
}
