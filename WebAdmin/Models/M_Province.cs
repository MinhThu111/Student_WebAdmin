namespace Student_WebAdmin.Models
{
    public class M_Province:M_BaseModel.BaseCustom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameSlug { get; set; }
        public int? CountryId { get; set; }
        public string ProvinceCode { get; set; }
    }
}
