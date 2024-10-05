using lab1.Models;
using lab1.DBContext;
using lab1.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace lab1.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Отримати всі записи бронювань
        public IEnumerable<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        // Отримати бронювання за його ідентифікатором
        public Booking GetById(int id)
        {
            return _context.Bookings.Find(id);
        }

        // Додати нове бронювання
        public void Add(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        // Оновити існуюче бронювання
        public void Update(Booking booking)
        {
            _context.Bookings.Update(booking);
            _context.SaveChanges();
        }

        // Видалити бронювання за його ідентифікатором
        public void Delete(int id)
        {
            var booking = _context.Bookings.Find(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                _context.SaveChanges();
            }
        }
    }
}
