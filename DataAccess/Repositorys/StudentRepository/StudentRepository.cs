using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentRepository
{
    public class StudentRepository : IStudentRepository
    {
        IList<Student> IStudentRepository.GetAll() => StudentDAO.Instance.GetAll();

        Student IStudentRepository.GetById(int id) => StudentDAO.Instance.GetById(id);
        void IStudentRepository.CreateOrUpdate(Student student) => StudentDAO.Instance.CreateOrUpdate( student);
        void IStudentRepository.Delete(int id) => StudentDAO.Instance.Delete(id);
    }
}
