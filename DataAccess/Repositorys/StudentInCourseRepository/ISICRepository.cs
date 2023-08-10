using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.StudentInCourseRepository
{
    public interface ISICRepository
    {
        IEnumerable<StudentInCourse> GetAll();
        void CreateOrUpdate(StudentInCourse StudentInCourse);
        void Delete (StudentInCourse StudentInCourse);
        IEnumerable<StudentInCourse> GetById(int id);
    }
}
