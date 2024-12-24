namespace STUDMANAG.Modal.Basemodal
{
    public class TimeEntity
    {
        public int Id { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.UtcNow;
        public DateTime? DeletedTime { get; set; }
        public string? CreatedId { get; set; }
        public string? DeletedId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? LastModifiedTime { get; set; }
        public string LastModifiedId { get; set; }
    }
}
