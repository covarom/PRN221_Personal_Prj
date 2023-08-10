using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SubjectRepository
{
    public class SubjectDAO
    {
        private static SubjectDAO instance = null;
        private static readonly object instanceLock = new object();
        private SubjectDAO() { }

        public static SubjectDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SubjectDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Subject in context.Subjects select Subject;
            return stu.ToList();
        }

        public IEnumerable<Subject> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Subjects.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Subject Subject)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Subjects.SingleOrDefault(stu => stu.Id == Subject.Id);
                    context.Subjects.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Subject" + ex.Message);
            }
        }
        public void CreateOrUpdate(Subject Subject)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Subjects.SingleOrDefault(stu => stu.Id == Subject.Id);
                    if(stu == null)
                    {
                        context.Subjects.Add(Subject);
                    }
                    else
                    {
                        context.Subjects.Update(Subject);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Subject" + ex.Message);
            }
        }
    }
}
