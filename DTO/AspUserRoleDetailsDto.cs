using STUDMANAG.DTO.BaseDto;

namespace STUDMANAG.DTO
{
    public class AspUserRoleDetailsDto : TimeEntityDto
    {
        public string AspUserId { get; set; } // GUID ID CREATED WHEN CREATING A USER 
        public int AspRoleId { get; }
    }
}
