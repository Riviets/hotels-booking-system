namespace lab1.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
