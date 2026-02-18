using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ShortUrl> ShortUrls { get; }

    DbSet<ShortUrlCounter> ShortUrlCounters { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}