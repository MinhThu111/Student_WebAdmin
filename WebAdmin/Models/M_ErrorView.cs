namespace Student_WebAdmin.Models
{
    public class M_ErrorView
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}