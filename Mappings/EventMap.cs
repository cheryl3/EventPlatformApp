using EventPlatformApp.Models;
using FluentNHibernate.Mapping;

namespace EventPlatformApp.Mappings
{
    public class EventMap : ClassMap<Event>
    {
        public EventMap() 
        {
            Table("Events");
            Id(x => x.Id).Column("Id");
            Map(x => x.Name).Column("Name");
            Map(x => x.StartsOn).Column("StartsOn");
            Map(x => x.EndsOn).Column("EndsOn");
        }
    }
}
