namespace EventPlatformApp.Models
{
    public class Event
    {
        public virtual required string Id { get; set; }
        public virtual required string Name { get; set; }
        public virtual DateTime StartsOn { get; set; }
        public virtual DateTime EndsOn { get; set; }
    }
}
