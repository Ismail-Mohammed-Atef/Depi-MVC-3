﻿namespace Depi_MVC.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ManagerName { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }

    }
}
