namespace lab1.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public Hotel Hotel { get; set; }
    }
}
