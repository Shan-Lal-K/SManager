using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class AspUsers : TimeEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        //public int? RoleId   { get; set; }
        public bool IsTwoFactor { get; set; }


    }
}
