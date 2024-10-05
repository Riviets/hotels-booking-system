using lab1.Models;
namespace lab1.Repositories.Interfaces
{
    public interface IBookingRepository
    {
        IEnumerable<Booking> GetAll();
        Booking GetById(int id);
        void Add(Booking booking);
        void Update(Booking booking);
        void Delete(int id);
    }
}
