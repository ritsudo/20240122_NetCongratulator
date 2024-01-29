using Microsoft.EntityFrameworkCore;
using NetCongratulator.Domain;

namespace NetCongratulator.Infrastructure;

public class NetCongratulatorDbContext : DbContext
{
    public NetCongratulatorDbContext (DbContextOptions<NetCongratulatorDbContext> options) : base (options)
    {
    }

    public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<TaskElement> TaskElements => Set<TaskElement>();
    public DbSet<UserCard> UserCards => Set<UserCard>();
}