using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentInCourseRepository
{
    public class SICDAO
    {
        private static SICDAO instance = null;
        private static readonly object instanceLock = new object();
        private SICDAO() { }

        public static SICDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SICDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<StudentInCourse> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from StudentInCourse in context.StudentInCourses select StudentInCourse;
            return stu.ToList();
        }

        public IEnumerable<StudentInCourse> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.StudentInCourses.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(StudentInCourse StudentInCourse)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.StudentInCourses.SingleOrDefault(stu => stu.Id == StudentInCourse.Id);
                    context.StudentInCourses.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete StudentInCourse" + ex.Message);
            }
        }
        public void CreateOrUpdate(StudentInCourse StudentInCourse)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.StudentInCourses.SingleOrDefault(stu => stu.Id == StudentInCourse.Id);
                    if(stu == null)
                    {
                        context.StudentInCourses.Add(StudentInCourse);
                    }
                    else
                    {
                        context.StudentInCourses.Update(StudentInCourse);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate StudentInCourse" + ex.Message);
            }
        }
    }
}
