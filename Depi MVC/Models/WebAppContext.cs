using Microsoft.EntityFrameworkCore;

namespace Depi_MVC.Models
{
    public class WebAppContext : DbContext
    {
        
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseResults> CourseResults { get; set; }
        public DbSet<Trainee> Trainees { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-O0QCD23\\SQLDEVELOPER ; Database = DepiMvc2 ; Trusted_Connection=true");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = DESKTOP-O0QCD23\\SQLDEVELOPER ; Database = DepiMvc2 ; Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }
    }

}
