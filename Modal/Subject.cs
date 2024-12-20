using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class Subject : TimeEntity
    {
        public string SubjectName { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectDescription { get; set; }
    }
}
