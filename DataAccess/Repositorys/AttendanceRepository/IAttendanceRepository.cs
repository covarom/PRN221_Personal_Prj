using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AttendanceRepository
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendance> GetAll();
        void CreateOrUpdate(Attendance Attendance);
        void Delete (Attendance Attendance);
        IEnumerable<Attendance> GetById(int id);
    }
}
