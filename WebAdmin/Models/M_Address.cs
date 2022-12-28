using System.ComponentModel.DataAnnotations;
namespace Student_WebAdmin.Models
{
    public class M_Address: M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AddressNumber { get; set; }
        public string AddressText { get; set; }
        public int? CountryId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
    public class EM_Address : M_BaseModel.BaseCustom
    {
        public int? id { get; set; }
        public int? supplierId { get; set; }
        [StringLength(150, ErrorMessage = "Tên có độ dài tối đa 150 ký tự")]
        public string title { get; set; }
        [StringLength(100, ErrorMessage = "Số nhà có độ dài tối đa 100 ký tự")]
        public string addressNumber { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Địa chỉ có độ dài tối đa 100 ký tự")]
        public string addressText { get; set; }
        public int? countryId { get; set; }
        [Required]
        public int? provinceId { get; set; }
        [Required]
        public int? districtId { get; set; }
        [Required]
        public int? wardId { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }

}
