using Microsoft.EntityFrameworkCore;
using NetCongratulator.Models;

namespace NetCongratulator.Data;

public class UserCardContext : DbContext
{
    public UserCardContext (DbContextOptions<UserCardContext> options) : base (options)
    {
    }

    public DbSet<Avatar> Avatars => Set<Avatar>();
    public DbSet<EmailAddress> EmailAddresses => Set<EmailAddress>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<TaskElement> TaskElements => Set<TaskElement>();
    public DbSet<UserCard> UserCards => Set<UserCard>();
}