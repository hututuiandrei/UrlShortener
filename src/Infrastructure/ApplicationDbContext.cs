using System.Reflection;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ShortUrl> ShortUrls => Set<ShortUrl>();

    public DbSet<ShortUrlCounter> ShortUrlCounters => Set<ShortUrlCounter>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<ShortUrlCounter>().HasData(
            new ShortUrlCounter()
        );
    }
}