using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ShortUrl> ShortUrls { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}