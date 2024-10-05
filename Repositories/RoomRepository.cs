using lab1.DBContext;
using lab1.Models;
using lab1.Repositories.Interfaces;

namespace lab1.Repositories
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
