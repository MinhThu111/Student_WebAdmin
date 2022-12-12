namespace Student_WebAdmin.Models
{
    public class M_PersonType:M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }
       
    }
    public class EM_PersonType : M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Remark { get; set; }

    }
}
