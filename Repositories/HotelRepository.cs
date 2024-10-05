using lab1.Models;
using lab1.DBContext;
using lab1.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly ApplicationDbContext _context;

        public HotelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _context.Hotels.ToList();
        }

        public Hotel GetById(int id)
        {
            return _context.Hotels.Find(id);
        }

        public void Add(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var hotel = _context.Hotels.Find(id);
            if (hotel != null)
            {
                _context.Hotels.Remove(hotel);
                _context.SaveChanges();
            }
        }
    }
}
