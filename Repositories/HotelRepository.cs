using lab1.DBContext;
using lab1.Models;
using lab1.Repositories.Interfaces;

namespace lab1.Repositories
{
    public class HotelRepository : GenericRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
