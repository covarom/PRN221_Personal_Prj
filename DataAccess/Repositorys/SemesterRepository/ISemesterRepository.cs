using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SemesterRepository
{
    public interface ISemesterRepository
    {
        IEnumerable<Semester> GetAll();
        void CreateOrUpdate(Semester Semester);
        void Delete (Semester Semester);
        IEnumerable<Semester> GetById(int id);
    }
}
