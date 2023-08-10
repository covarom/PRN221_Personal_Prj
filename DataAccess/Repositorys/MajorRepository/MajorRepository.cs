using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.MajorRepository
{
    public class MajorRepository : IMajorRepository
    {
        IEnumerable<Major> IMajorRepository.GetAll() => MajorDAO.Instance.GetAll();

        IEnumerable<Major> IMajorRepository.GetById(int id) => MajorDAO.Instance.GetById(id);
        void IMajorRepository.CreateOrUpdate(Major major) => MajorDAO.Instance.CreateOrUpdate( major);
        void IMajorRepository.Delete(Major major) => MajorDAO.Instance.Delete( major);
    }
}
