using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.CourseRepository
{
    public class CourseRepository: ICourseRepository
    {
        IEnumerable<Course> ICourseRepository.GetAll() => CourseDAO.Instance.GetAll();

        IEnumerable<Course> ICourseRepository.GetById(int id) => CourseDAO.Instance.GetById(id);
        void ICourseRepository.CreateOrUpdate(Course Course) => CourseDAO.Instance.CreateOrUpdate( Course);
        void ICourseRepository.Delete(Course Course) => CourseDAO.Instance.Delete( Course);
    }
}
