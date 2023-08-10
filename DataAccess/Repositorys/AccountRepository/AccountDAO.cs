using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AccountRepository
{
    public class AccountDAO
    {
        private static AccountDAO instance = null;
        private static readonly object instanceLock = new object();
        private AccountDAO() { }

        public static AccountDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new AccountDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Account> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Account in context.Accounts select Account;
            return stu.ToList();
        }

        public Account GetByUsername(string username)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs = context.Accounts.SingleOrDefault(x => x.Username == username);
                return rs;
            }
        }

        public IEnumerable<Account> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Accounts.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Account Account)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Accounts.SingleOrDefault(stu => stu.Id == Account.Id);
                    context.Accounts.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Account" + ex.Message);
            }
        }
        public void CreateOrUpdate(Account Account)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Accounts.SingleOrDefault(stu => stu.Id == Account.Id);
                    if(stu == null)
                    {
                        context.Accounts.Add(Account);
                    }
                    else
                    {
                        context.Accounts.Update(Account);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Account" + ex.Message);
            }
        }
    }
}
