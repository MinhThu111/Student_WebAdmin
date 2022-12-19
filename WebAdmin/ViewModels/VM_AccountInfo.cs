namespace Student_WebAdmin.ViewModels
{
    public class VM_AccountInfo
    {
        public string accountId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public int? personId { get; set; }
        public string phoneNumber { get; set; }
        public string national { get; set; }
        public List<string> roles { get; set; }
        public DateTime? birthDay { get; set; }
        public int? gender { get; set; }
    }
}