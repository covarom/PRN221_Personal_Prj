using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AccountRepository
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        void CreateOrUpdate(Account Account);
        void Delete (Account Account);
        IEnumerable<Account> GetById(int id);

       Account GetByUsername(string username);
    }
}
