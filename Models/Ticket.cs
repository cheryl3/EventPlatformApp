namespace EventPlatformApp.Models
{
    public class Ticket
    {
        public virtual required int TicketId { get; set; }
        public virtual required string EventId { get; set; }
        public virtual required string EventName { get; set; }
        public virtual required string TicketType { get; set; }
        public virtual required double Price { get; set; }
        public virtual required int Sold { get; set; }
        public virtual DateTime CreatedDater { get; set; }
        public virtual DateTime UpdatedDate { get; set; }
    }
}
