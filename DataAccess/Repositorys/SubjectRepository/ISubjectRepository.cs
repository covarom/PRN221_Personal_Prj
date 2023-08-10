using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SubjectRepository
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        void CreateOrUpdate(Subject Subject);
        void Delete (Subject Subject);
        IEnumerable<Subject> GetById(int id);
    }
}
