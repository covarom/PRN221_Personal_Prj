using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.RoomRepository
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        void CreateOrUpdate(Room Room);
        void Delete (Room Room);
        IEnumerable<Room> GetById(int id);
    }
}
