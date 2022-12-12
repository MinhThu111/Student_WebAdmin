using System.ComponentModel.DataAnnotations;

namespace Student_WebAdmin.Models
{
    public class M_Account
    {
        public int? id { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string accountType { get; set; }
        public int? systemId { get; set; }
        public int? personId { get; set; }
        public VM_Person personObj { get; set; }
    }
    public class M_AccountSignIn : M_Account
    {
        public string accessToken { get; set; }
    }
    public class EM_AccountSignIn
    {
        [Required(ErrorMessage = "Nhập tài khoản")]
        [RegularExpression("^[a-z0-9_-]{3,50}$", ErrorMessage = "Tài khoản không hợp lệ")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Nhập mật khẩu")]
        [RegularExpression(@"^([^'ÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêếìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳýỵỷỹ\-\s]+)$", ErrorMessage = "Mật khẩu không được chứa ký tự dấu và khoảng trắng.")]
        public string password { get; set; }
        public bool stayLoggedIn { get; set; }
    }
}
