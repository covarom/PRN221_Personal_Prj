using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.RoomRepository
{
    public class CourseRepository: IRoomRepository
    {
        IEnumerable<Room> IRoomRepository.GetAll() => RoomDAO.Instance.GetAll();

        IEnumerable<Room> IRoomRepository.GetById(int id) => RoomDAO.Instance.GetById(id);
        void IRoomRepository.CreateOrUpdate(Room Room) => RoomDAO.Instance.CreateOrUpdate( Room);
        void IRoomRepository.Delete(Room Room) => RoomDAO.Instance.Delete( Room);
    }
}
