using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SessionRepository
{
    public interface ISessionRepository
    {
        IEnumerable<Session> GetAll();
        void CreateOrUpdate(Session Session);
        void Delete (Session Session);
        IEnumerable<Session> GetById(int id);
    }
}
