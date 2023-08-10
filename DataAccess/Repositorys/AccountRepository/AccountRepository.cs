using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AccountRepository
{
    public class AccountRepository : IAccountRepository
    {
        IEnumerable<Account> IAccountRepository.GetAll() => AccountDAO.Instance.GetAll();

        Account IAccountRepository.GetByUsername(string username) => AccountDAO.Instance.GetByUsername(username);
        IEnumerable<Account> IAccountRepository.GetById(int id) => AccountDAO.Instance.GetById(id);
        void IAccountRepository.CreateOrUpdate(Account Account) => AccountDAO.Instance.CreateOrUpdate( Account);
        void IAccountRepository.Delete(Account Account) => AccountDAO.Instance.Delete( Account);
    }
}
