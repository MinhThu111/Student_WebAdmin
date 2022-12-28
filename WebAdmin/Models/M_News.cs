using System.ComponentModel.DataAnnotations;
namespace Student_WebAdmin.Models
{
    public class M_News : M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public int? newscategoryid { get; set; }
        public string title { get; set; }
        public string titleslug { get; set; }
        /// <summary>
        /// id lấy từ person. Xác định GVCN
        /// </summary>
        public string description { get; set; }
        public string avatarurl { get; set; }
        public string detail { get; set; }
        public EM_NewsCategory newscategoryObj { get; set; }
    }
    public class EM_News : M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        [Required]
        public int? newscategoryid { get; set; }

        [Required(ErrorMessage = "Nhập tiêu đề")]
        [MaxLength(100, ErrorMessage = "Không nhập quá 100 ký tự")]
        public string title { get; set; }
        public string titleslug { get; set; }
        /// <summary>
        /// id lấy từ person. Xác định GVCN
        /// </summary>
        [Required(ErrorMessage = "Nhập mô tả")]
        [MaxLength(200,ErrorMessage = "Không nhập quá 200 ký tự")]
        public string description { get; set; }
        [Required]
        public string avatarurl { get; set; }
        [Required]
        public string detail { get; set; }
        public EM_NewsCategory newscategoryObj { get; set; }
    }
}