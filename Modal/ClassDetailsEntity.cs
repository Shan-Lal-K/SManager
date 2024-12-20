using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class ClassDetailsEntity : TimeEntity
    {
        public int ClassName { get; set; }
        public int? ClassDivision { get; set; }
        public int? ClassTeacherId { get; set; }
    }
}
