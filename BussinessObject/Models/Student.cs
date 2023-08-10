using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public string Name { get; set; } = null!;
        public int? MajorId { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Major? Major { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
