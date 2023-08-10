using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AttendanceRepository
{
    public class AttendanceDAO
    {
        private static AttendanceDAO instance = null;
        private static readonly object instanceLock = new object();
        private AttendanceDAO() { }

        public static AttendanceDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AttendanceDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Attendance> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Attendance in context.Attendances select Attendance;
            return stu.ToList();
        }

        public IEnumerable<Attendance> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Attendances.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Attendance Attendance)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Attendances.SingleOrDefault(stu => stu.Id == Attendance.Id);
                    context.Attendances.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Attendance" + ex.Message);
            }
        }
        public void CreateOrUpdate(Attendance Attendance)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Attendances.SingleOrDefault(stu => stu.Id == Attendance.Id);
                    if(stu == null)
                    {
                        context.Attendances.Add(Attendance);
                    }
                    else
                    {
                        context.Attendances.Update(Attendance);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Attendance" + ex.Message);
            }
        }
    }
}
