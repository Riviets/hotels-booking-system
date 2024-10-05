using lab1.DBContext;
using lab1.Models;
using lab1.Repositories.Interfaces;

namespace lab1.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
