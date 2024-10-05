using lab1.Models;
using lab1.DBContext;
using lab1.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> GetAll()
        {
            return _context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return _context.Rooms.Find(id);
        }

        public void Add(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Update(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }
    }
}
