using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string Contact { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string Department { get; set; }

        // Navigation property
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
