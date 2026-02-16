using Microsoft.EntityFrameworkCore;

namespace GetHandler;

public class EventsContext : DbContext
{
    public EventsContext(DbContextOptions<EventsContext> options) : base(options)
    { }

    public DbSet<EventEntity> Events { get; set; }
}