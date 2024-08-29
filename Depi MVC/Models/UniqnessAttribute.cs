using System.ComponentModel.DataAnnotations;

namespace Depi_MVC.Models
{
    public class UniqnessAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value , ValidationContext validationContext)
        {
            WebAppContext context = new WebAppContext();
            string name = value?.ToString();
            Course course = context.Courses.FirstOrDefault(c=>c.Name == name);
            if (course == null) 
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Course Already Exists");
        }
    }
}
