using System.ComponentModel.DataAnnotations;
namespace Student_WebAdmin.Models
{
    public class M_Register
    {
        //nhắc nhở yêu cầu nhập vào với mess được custom
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        //điều kiện dữ liệu đầu vào nằm trong 10 đến 25 ký tự
        [StringLength(maximumLength: 25, MinimumLength = 2, ErrorMessage = "Length must be between 2 to 25")]
        public string Username { get; set; }

        //nhắc nhở nhập vào với mess mặt định
        [Required]
        //điều kiện dữ liệu thuộc loại password
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //nhắc nhở nhập vào với mess mặt định
        [Required]
        //điều kiện dữ liệu thuộc loại password
        [DataType(DataType.Password)]
        //so sánh trường hiện tại với trường khác
        [Compare(otherProperty: "Password", ErrorMessage ="Password and Confirmpassword does not match")]
        public string ConfirmPassword { get; set; }

        //nhắc nhở nhập vào với mess mặt định
        [Required]
        //điều kiện dữ liệu thuộc loại email
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
