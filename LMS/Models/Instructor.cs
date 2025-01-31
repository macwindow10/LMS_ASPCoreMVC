using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int CoursesAttended { get; set; }

        [MaxLength(100)]
        public string AreaOfExpertise { get; set; }

        public bool IsSME { get; set; }
    }
}
