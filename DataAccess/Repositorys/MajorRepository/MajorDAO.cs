using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.MajorRepository
{
    public class MajorDAO
    {
        private static MajorDAO instance = null;
        private static readonly object instanceLock = new object();
        private MajorDAO() { }

        public static MajorDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new MajorDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Major> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Major in context.Majors select Major;
            return stu.ToList();
        }

        public IEnumerable<Major> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Majors.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Major Major)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Majors.SingleOrDefault(stu => stu.Id == Major.Id);
                    context.Majors.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Major" + ex.Message);
            }
        }
        public void CreateOrUpdate(Major Major)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Majors.SingleOrDefault(stu => stu.Id == Major.Id);
                    if(stu == null)
                    {
                        context.Majors.Add(Major);
                    }
                    else
                    {
                        context.Majors.Update(Major);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Major" + ex.Message);
            }
        }
    }
}
