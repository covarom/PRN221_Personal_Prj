using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class StudentInCourse
    {
        public StudentInCourse()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? StudentId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
