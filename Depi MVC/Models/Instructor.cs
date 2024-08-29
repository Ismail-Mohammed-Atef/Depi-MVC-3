using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Depi_MVC.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public Double Salary { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Course")]
        public int CrsId { get; set; }

        public virtual Course Course { get; set; }
    }
}
