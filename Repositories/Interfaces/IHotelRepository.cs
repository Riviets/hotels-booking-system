using lab1.Models;

namespace lab1.Repositories.Interfaces
{
    public interface IHotelRepository
    {
        IEnumerable<Hotel> GetAll();
        Hotel GetById(int id);
        void Add(Hotel hotel);
        void Update(Hotel hotel);
        void Delete(int id);
    }
}

