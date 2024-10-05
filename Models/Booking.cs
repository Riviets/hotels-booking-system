namespace lab1.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RoomId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        public string Status {get; set;}

        public User User { get; set; }
        public Room Room { get; set; }
    }
}
