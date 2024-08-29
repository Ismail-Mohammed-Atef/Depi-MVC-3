using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depi_MVC.Models
{
    public class CourseResults
    {
        public int Id { get; set; }
        [Required]
        [Range(0, 100)]
        public int Degree { get; set; }

        [ForeignKey("Course")]
        [Required(ErrorMessage = "Course field is required")]
        public int CrsId { get; set; }

        public virtual Course? Course { get; set; }

        [ForeignKey("Trainee")]
        [Required(ErrorMessage ="Trainee field is required")]

        public int TraineeId { get; set; }
        public virtual Trainee? Trainee { get; set; }
    }
}
