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
        public string avatarUrl { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }
        public string remark { get; set; }
        public M_Nationality nationalityObj { get; set; }
        public M_PersonType personTypeObj { get; set; }
        public EM_Address addressObj { get; set; }

    }
    public class EM_Person:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public string firstName { get; set; }
        public string lastNameSlug { get; set; }
        public string firstNameSlug { get; set; }
        [Required]
        public DateTime? birthDay { get; set; }
        public int? gender { get; set; }
        public string code { get; set; }
        [Required]
        public int personTypeId { get; set; }
        [Required]
        public int? nationalityId { get; set; }
        [Required]
        public int? religionId { get; set; }
        [Required]
        public int? folkId { get; set; }
        public int? addressId { get; set; }
        [Required]
        public string avatarUrl { get; set; }
        [Required]
        [StringLength(11, ErrorMessage = "Số nhà có độ dài tối đa 11 ký tự")]
        public string phoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public string remark { get; set; }
        public EM_Address addressObj { get; set; }

    }
    public class VM_Person: M_BaseModel.BaseCustom
    {
        
        public int? id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [Required]
        public int? gender { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string avatar { get; set; }
        [Required]
        public string phonenumber { get; set; }
        [Required]
        public string national { get; set; }
        [Required]
        public DateTime? birthDay { get; set; }
    }
}
