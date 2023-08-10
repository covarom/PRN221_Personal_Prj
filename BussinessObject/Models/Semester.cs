using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
