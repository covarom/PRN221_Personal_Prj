using BussinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositorys.RoomRepository
{
    public class RoomDAO
    {
        private static RoomDAO instance = null;
        private static readonly object instanceLock = new object();
        private RoomDAO() { }

        public static RoomDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new RoomDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Room> GetAll()
        {
            CourseManagementDBContext context = new CourseManagementDBContext();
            var stu = from Room in context.Rooms select Room;
            return stu.ToList();
        }

        public IEnumerable<Room> GetById(int Id)
        {
            using (CourseManagementDBContext context = new CourseManagementDBContext())
            {
                var rs =  context.Rooms.SingleOrDefault(x => x.Id == Id);
                yield return rs;
            }
        }

        public void Delete(Room Room)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Rooms.SingleOrDefault(stu => stu.Id == Room.Id);
                    context.Rooms.Remove(stu);
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("Error delete Room" + ex.Message);
            }
        }
        public void CreateOrUpdate(Room Room)
        {
            try
            {
                using (CourseManagementDBContext context = new CourseManagementDBContext())
                {
                    var stu = context.Rooms.SingleOrDefault(stu => stu.Id == Room.Id);
                    if(stu == null)
                    {
                        context.Rooms.Add(Room);
                    }
                    else
                    {
                        context.Rooms.Update(Room);
                    }
                    context.SaveChanges();
                };
            }
            catch (Exception ex)
            {
                throw new Exception("CreateOrUpdate Room" + ex.Message);
            }
        }
    }
}
