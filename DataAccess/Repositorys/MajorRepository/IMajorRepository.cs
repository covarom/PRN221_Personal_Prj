using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.MajorRepository
{
    public interface IMajorRepository
    {
        IEnumerable<Major> GetAll();
        void CreateOrUpdate(Major Major);
        void Delete (Major Major);
        IEnumerable<Major> GetById(int id);
    }
}
