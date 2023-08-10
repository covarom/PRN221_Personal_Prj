using System;
using System.Collections.Generic;

namespace BussinessObject.Models
{
    public partial class Attendance
    {
        public int Id { get; set; }
        public int? StudentInCourseId { get; set; }
        public int? SessionId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsPresent { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual Session? Session { get; set; }
        public virtual StudentInCourse? StudentInCourse { get; set; }
    }
}
