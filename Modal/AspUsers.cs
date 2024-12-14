using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class AspUsers : TimeEntity
    {
        public string UserName { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int? RoleId   { get; set; }

    }
}
