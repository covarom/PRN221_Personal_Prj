using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Major
    {
        public Major()
        {
            Courses = new HashSet<Course>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
