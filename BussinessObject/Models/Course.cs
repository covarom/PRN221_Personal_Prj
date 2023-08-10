using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Course
    {
        public Course()
        {
            Sessions = new HashSet<Session>();
            StudentInCourses = new HashSet<StudentInCourse>();
        }

        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int? SubjectId { get; set; }
        public int? SemesterId { get; set; }
        public int? MajorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Major? Major { get; set; }
        public virtual Semester? Semester { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<StudentInCourse> StudentInCourses { get; set; }
    }
}
