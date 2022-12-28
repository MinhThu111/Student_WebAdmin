using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Student_WebAdmin.Models
{
    public class M_NewsCategory:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public int? parentid { get; set; }
        public string name { get; set; }
        /// <summary>
        /// 0:Giới thiệu;1:Tin tức;2:Thông báo
        /// </summary>
        public int? type { get; set; }
    }
    public class EM_NewsCategory:M_BaseModel.BaseCustom
    {
        public int id { get; set; }
        public int? parentid { get; set; }
        [Required(ErrorMessage = "Nhập tên danh sách")]
        [MaxLength(150, ErrorMessage = "Không nhập quá 150 ký tự")]
        public string name { get; set; }
        /// <summary>
        /// 0:Giới thiệu;1:Tin tức;2:Thông báo
        /// </summary>
        public int? type { get; set; }
    }
}
