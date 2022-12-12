using System.ComponentModel.DataAnnotations;
using static Student_WebAdmin.Lib.ValidationAttribute;

namespace Student_WebAdmin.Models
{
    public class M_UploadSingleFile: ValidationAttribute
    {
        [Required(ErrorMessage = "Please select file")]
        [DataType(DataType.Upload)]
        [MaxFileSize(maxFileSize:5*1024*1024, errorMessage:"Dung luong toi da cua anh la 5M!!!")]
        [AllowedExtensions(new string[] { ".jpg", ".png" }, errorMessage:"Anh khong hop le!!!")]
        public IFormFile singlefile { get; set; }
        public int id { get; set; }
    }
    public class M_UploadMultipleFile
    {
        [Required(ErrorMessage = "Please select file")]
        [DataType(DataType.Upload)]
        [MaxFileSizeInList(maxFileSize: 5 * 1024 * 1024, errorMessage: "Dung luong toi da cua anh la 5M!!!")]
        [AllowedExtensionsInList(new string[] { ".jpg", ".png" }, errorMessage: "Anh khong hop le!!!")]

        public List<IFormFile> multiplefiles { get; set; }
        public int id { get; set; }
    }
    public class M_FileName
    {
        public string fName { get; set; }
        public int id { get; set; }
    }
}
