using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.CourseRepository
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        void CreateOrUpdate(Course Course);
        void Delete (Course Course);
        IEnumerable<Course> GetById(int id);
    }
}
