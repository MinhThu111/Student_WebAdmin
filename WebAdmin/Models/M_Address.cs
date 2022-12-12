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
}
