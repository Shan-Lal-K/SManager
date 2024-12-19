using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class SchoolEntity : TimeEntity
    {
        public string? SchoolId { get; set; }
        public string? SchoolName { get; set; }
        public string Address { get; set; }
        public int? City { get; set; }
        public int? Country { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string? Website { get; set; }
        public int? PrincipalId { get; set; }
        public string? SchoolLogo { get; set; }
        public int? FoundedYear { get; set; }
        public int? Board { get; set; }

        //Board Example 
        //1.CBSE
        //2.State
        //3.ICSE
        public string? SchoolMission { get; set; }
    }
}
