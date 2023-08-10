using BussinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentRepository
{
    public class StudentDAO
    {
        private static StudentDAO instance = null;
        private static readonly object instanceLock = new object();
        private StudentDAO() { }

        public static StudentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new StudentDAO();
                    }
                    return instance;
                }
            }
        }

        public IList<Student> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = context.Students.Include(s => s.Major);
            return stu.ToList();
        }

        public Student GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Students.SingleOrDefault(x => x.Id == Id);
                 return rs;
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var item = GetById(id);
                    var res = context.Students.Remove(item);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete student" + ex.Message);
            }
        }
        public void CreateOrUpdate(Student student)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Students.AsNoTracking().SingleOrDefault(stu => stu.Id == student.Id);
                    if(stu == null)
                    {
                        context.Students.Add(student);
                        context.SaveChanges();
                    }
                    else
                    {
                        context.Students.Update(student);
                        context.SaveChanges();
                    }
              
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate student" + ex.Message);
            }
        }
    }
}
