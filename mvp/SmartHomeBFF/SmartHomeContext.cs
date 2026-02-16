using Microsoft.EntityFrameworkCore;

namespace SmartHomeBFF;

public class SmartHomeContext : DbContext
{
    public SmartHomeContext(DbContextOptions<SmartHomeContext> options) : base(options)
    { }

    public DbSet<SmartHomeSettingsEntity> Settings { get; set; }

    public DbSet<EventEntity> Events { get; set; }
}