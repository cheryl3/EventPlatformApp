using EventPlatformApp.Models;
using FluentNHibernate.Mapping;

namespace EventPlatformApp.Mappings
{
    public class TicketMap : ClassMap<Ticket>
    {
        public TicketMap() 
        {
            Table("Tickets");
            Id(x => x.TicketId).Column("TicketId").GeneratedBy.Identity();
            Map(x => x.EventId).Column("EventId");
            Map(x => x.EventName).Column("EventName");
            Map(x => x.TicketType).Column("TicketType");
            Map(x => x.Price).Column("Price");
            Map(x => x.Sold).Column("Sold");
        }
    }
}
