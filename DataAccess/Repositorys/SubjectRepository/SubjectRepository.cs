using BussinessObject.Models;
using DataAccess.Repositorys.SubjectRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SubjectRepository
{
    public class SubjectRepository : ISubjectRepository
    {
        IEnumerable<Subject> ISubjectRepository.GetAll() => SubjectDAO.Instance.GetAll();

        IEnumerable<Subject> ISubjectRepository.GetById(int id) => SubjectDAO.Instance.GetById(id);
        void ISubjectRepository.CreateOrUpdate(Subject Subject) => SubjectDAO.Instance.CreateOrUpdate( Subject);
        void ISubjectRepository.Delete(Subject Subject) => SubjectDAO.Instance.Delete( Subject);
    }
}
