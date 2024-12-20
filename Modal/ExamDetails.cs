using STUDMANAG.Modal.Basemodal;

namespace STUDMANAG.Modal
{
    public class ExamDetails : TimeEntity
    {
        public int? ForClassId { get; set; }
        public DateTime? ConductingDateFrom { get; set; }
        public DateTime? ConductingDateTo { get; set; }
        public int? SubjectId { get; set; }
    }
}
