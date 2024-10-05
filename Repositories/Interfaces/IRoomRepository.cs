using lab1.Models;

namespace lab1.Repositories.Interfaces
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room GetById(int id);
        void Add(Room room);
        void Update(Room room);
        void Delete(int id);
    }
}
