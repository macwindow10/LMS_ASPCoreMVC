using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsFellowship { get; set; }

        public string Visits { get; set; }

        public string Instructors { get; set; }

        // Many-to-Many Relationship
        public List<Enrollment> Enrollments { get; set; }
    }
}
