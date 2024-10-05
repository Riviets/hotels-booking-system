using lab1.Models;

namespace lab1.ViewModels
{
    public class AppViewModel
    {
        public List<Hotel> Hotels { get; set; }
        public List<Room> Rooms { get; set; }
        public List<User> Users { get; set; }
        public List<Booking> Bookings {get; set;}

    }
}
