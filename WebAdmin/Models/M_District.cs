namespace Student_WebAdmin.Models
{
    public class M_District:M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public string DistrictCode { get; set; }
        public int ProvinceId { get; set; }
    }
}
