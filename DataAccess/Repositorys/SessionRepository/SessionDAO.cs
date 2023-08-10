using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SessionRepository
{
    public class SessionDAO
    {
        private static SessionDAO instance = null;
        private static readonly object instanceLock = new object();
        private SessionDAO() { }

        public static SessionDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new SessionDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Session> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Session in context.Sessions select Session;
            return stu.ToList();
        }

        public IEnumerable<Session> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Sessions.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Session Session)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Sessions.SingleOrDefault(stu => stu.Id == Session.Id);
                    context.Sessions.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Session" + ex.Message);
            }
        }
        public void CreateOrUpdate(Session Session)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Sessions.SingleOrDefault(stu => stu.Id == Session.Id);
                    if(stu == null)
                    {
                        context.Sessions.Add(Session);
                    }
                    else
                    {
                        context.Sessions.Update(Session);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Session" + ex.Message);
            }
        }
    }
}
