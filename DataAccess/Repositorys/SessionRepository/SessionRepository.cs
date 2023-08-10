using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SessionRepository
{
    public class SessionRepository : ISessionRepository
    {
        IEnumerable<Session> ISessionRepository.GetAll() => SessionDAO.Instance.GetAll();

        IEnumerable<Session> ISessionRepository.GetById(int id) => SessionDAO.Instance.GetById(id);
        void ISessionRepository.CreateOrUpdate(Session Session) => SessionDAO.Instance.CreateOrUpdate( Session);
        void ISessionRepository.Delete(Session Session) => SessionDAO.Instance.Delete( Session);
    }
}
