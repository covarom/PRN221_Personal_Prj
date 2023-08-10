using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SemesterRepository
{
    public class SemesterDAO
    {
        private static SemesterDAO instance = null;
        private static readonly object instanceLock = new object();
        private SemesterDAO() { }

        public static SemesterDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SemesterDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Semester> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Semester in context.Semesters select Semester;
            return stu.ToList();
        }

        public IEnumerable<Semester> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Semesters.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Semester Semester)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Semesters.SingleOrDefault(stu => stu.Id == Semester.Id);
                    context.Semesters.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Semester" + ex.Message);
            }
        }
        public void CreateOrUpdate(Semester Semester)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Semesters.SingleOrDefault(stu => stu.Id == Semester.Id);
                    if(stu == null)
                    {
                        context.Semesters.Add(Semester);
                    }
                    else
                    {
                        context.Semesters.Update(Semester);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Semester" + ex.Message);
            }
        }
    }
}
