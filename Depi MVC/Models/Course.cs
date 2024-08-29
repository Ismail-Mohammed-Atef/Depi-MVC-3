using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Depi_MVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [Uniqness]
        public string Name { get; set; }
        [Remote("CheckDegree","Course",AdditionalFields = nameof(MinDegree), ErrorMessage ="Invalid MaxDegree")]
        public int MaxDegree { get; set; }

        [Remote("CheckMinDegree", "Course", ErrorMessage = "Min Degree Must Be 25")]
        public int MinDegree { get; set; }
        public virtual ICollection<Instructor>? Instructors { get; set; }
        public virtual ICollection<CourseResults>? CourseResults { get; set; }

    }
}
