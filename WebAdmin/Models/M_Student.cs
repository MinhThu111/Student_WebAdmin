using System.ComponentModel.DataAnnotations;

namespace Student_WebAdmin.Models
{
    public class M_Student
    {
        public int id { get; set; }
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string className { get; set; }
        public string schoolName { get; set; }
        public int status { get; set; }
        public Point maths { get; set; }
        public Point physics { get; set; }
        public Point chemistry { get; set; }
    }
    public class Point
    {
        public double? fifteenMinutes { get; set; }
        public double? sixtyMinutes { get; set; }
        public double? midTerm { get; set; }
        public double? lastTerm { get; set; }
    }
    public class EM_Student
    {
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string className { get; set; }
        public string schoolName { get; set; }
        public int status { get; set; }
        public Point maths { get; set; }
        public Point physics { get; set; }
        public Point chemistry { get; set; }
    }
    public class VM_Student
    {
        public int id { get; set; }
        public string fullName { get; set; }
    }
}
