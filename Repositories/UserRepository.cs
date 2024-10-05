using lab1.DBContext;
using lab1.Models;
using lab1.Repositories.Interfaces;

namespace lab1.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
