using System.ComponentModel.DataAnnotations;
namespace Student_WebAdmin.Models
{
    public class M_Religion : M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string Description { get; set; }


    }
    public class EM_Religion : M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string Description { get; set; }
  

    }
}
