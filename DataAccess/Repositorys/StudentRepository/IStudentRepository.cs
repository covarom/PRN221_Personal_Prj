using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentRepository
{
    public interface IStudentRepository
    {
        IList<Student> GetAll();
        void CreateOrUpdate(Student student);
        void Delete (int id);
        Student GetById(int id);
    }
}
