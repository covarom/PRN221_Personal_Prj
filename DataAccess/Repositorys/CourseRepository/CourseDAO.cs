using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.CourseRepository
{
    public class CourseDAO
    {
        private static CourseDAO instance = null;
        private static readonly object instanceLock = new object();
        private CourseDAO() { }

        public static CourseDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CourseDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Course> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Course in context.Courses select Course;
            return stu.ToList();
        }

        public IEnumerable<Course> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Courses.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Course Course)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Courses.SingleOrDefault(stu => stu.Id == Course.Id);
                    context.Courses.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Course" + ex.Message);
            }
        }
        public void CreateOrUpdate(Course Course)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Courses.SingleOrDefault(stu => stu.Id == Course.Id);
                    if(stu == null)
                    {
                        context.Courses.Add(Course);
                    }
                    else
                    {
                        context.Courses.Update(Course);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Course" + ex.Message);
            }
        }
    }
}
