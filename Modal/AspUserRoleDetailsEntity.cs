using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class AspUserRoleDetailsEntity : TimeEntity
    {
        public string AspUserId { get; set; } // GUID ID CREATED WHEN CREATING A USER 
        public int AspRoleId { get; set; }
    }
}
