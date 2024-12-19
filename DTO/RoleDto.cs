using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class RoleDto : TimeEntityDto
    {
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
    }
}
