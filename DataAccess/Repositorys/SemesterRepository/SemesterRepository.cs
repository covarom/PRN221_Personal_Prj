using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.SemesterRepository
{
    public class SemesterRepository: ISemesterRepository
    {
        IEnumerable<Semester> ISemesterRepository.GetAll() => SemesterDAO.Instance.GetAll();

        IEnumerable<Semester> ISemesterRepository.GetById(int id) => SemesterDAO.Instance.GetById(id);
        void ISemesterRepository.CreateOrUpdate(Semester Semester) => SemesterDAO.Instance.CreateOrUpdate( Semester);
        void ISemesterRepository.Delete(Semester Semester) => SemesterDAO.Instance.Delete( Semester);
    }
}
