using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentInCourseRepository
{
    public class SICRepository: ISICRepository
    {
        IEnumerable<StudentInCourse> ISICRepository.GetAll() => SICDAO.Instance.GetAll();

        IEnumerable<StudentInCourse> ISICRepository.GetById(int id) => SICDAO.Instance.GetById(id);
        void ISICRepository.CreateOrUpdate(StudentInCourse StudentInCourse) => SICDAO.Instance.CreateOrUpdate( StudentInCourse);
        void ISICRepository.Delete(StudentInCourse StudentInCourse) => SICDAO.Instance.Delete( StudentInCourse);
    }
}
