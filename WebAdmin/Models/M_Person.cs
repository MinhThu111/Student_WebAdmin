using System.ComponentModel.DataAnnotations;
namespace Student_WebAdmin.Models
{
    public class M_Person:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string lastNameSlug { get; set; }
        public string firstNameSlug { get; set; }
        public DateTime? birthDay { get; set; }
        public int? gender { get; set; }
        public string code { get; set; }
        public int personTypeId { get; set; }
        public int? nationalityId { get; set; }
        public int? religionId { get; set; }
        public int? folkId { get; set; }
        public int? addressId { get; set; }
        public string phoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]   
        public string email { get; set; }
        public string remark { get; set; }
        //public int? status { get; set; }
        //public DateTime? createdAt { get; set; }
        //public int? createdBy { get; set; }
        //public DateTime? updatedAt { get; set; }
        //public int? updatedBy { get; set; }
        //public DateTime? timer { get; set; }
        //public BaseCustom baseObj { get; set; }

    }
    public class EM_Person:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string lastNameSlug { get; set; }
        public string firstNameSlug { get; set; }
        public DateTime? birthDay { get; set; }
        public int? gender { get; set; }
        public string code { get; set; }
        public int personTypeId { get; set; }
        public int? nationalityId { get; set; }
        public int? religionId { get; set; }
        public int? folkId { get; set; }
        public int? addressId { get; set; }
        public string phoneNumber { get; set; }
   
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string remark { get; set; }
        //public int? status { get; set; }
        //public DateTime? createdAt { get; set; }
        //public int? createdBy { get; set; }
        //public DateTime? updatedAt { get; set; }
        //public int? updatedBy { get; set; }
        //public DateTime? timer { get; set; }
        //public BaseCustom baseObj { get; set; }

    }
}
