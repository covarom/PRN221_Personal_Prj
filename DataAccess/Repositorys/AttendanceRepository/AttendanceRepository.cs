using BussinessObject.Models;
using DataAccess.Repositorys.AttendanceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.AttendanceRepository
{
    public class AttendanceRepository: IAttendanceRepository
    {
        IEnumerable<Attendance> IAttendanceRepository.GetAll() => AttendanceDAO.Instance.GetAll();

        IEnumerable<Attendance> IAttendanceRepository.GetById(int id) => AttendanceDAO.Instance.GetById(id);
        void IAttendanceRepository.CreateOrUpdate(Attendance Attendance) => AttendanceDAO.Instance.CreateOrUpdate( Attendance);
        void IAttendanceRepository.Delete(Attendance Attendance) => AttendanceDAO.Instance.Delete( Attendance);
    }
}
