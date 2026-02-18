using System.Text;
using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.ShortUrls;

public class ShortUrlService : IShortUrlService
{
    private readonly IApplicationDbContext _context;
    private const string Base62Characters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"; 

    public ShortUrlService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrlDto> CreateShortUrlAsync(LongUrlDto longUrlDto, CancellationToken cancellationToken = default)
    {
        var shortUrlCounter = await _context.ShortUrlCounters.SingleAsync();
        var counter = shortUrlCounter.Counter;

        var shortUrlReversed = new StringBuilder();

        if (counter == 0)
        {
            shortUrlReversed.Append('0');
        }

        while (counter > 0)
        {
            var rest = counter % 62;

            shortUrlReversed.Append(Base62Characters[rest]);

            counter /= 62;
        }

        var shortCode = new string([.. shortUrlReversed.ToString().Reverse()]);

        var shortUrl = new ShortUrl
        {
            ShortCode = shortCode,
            Url = longUrlDto.Url,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _context.ShortUrls.Add(shortUrl);
        shortUrlCounter.IncrementCounter();

        await _context.SaveChangesAsync(cancellationToken);

        return new ShortUrlDto
        {
            Id = shortUrl.Id,
            Url = shortUrl.Url,
            ShortCode = shortUrl.ShortCode,
            CreatedAt = shortUrl.CreatedAt.UtcDateTime,
            UpdatedAt = shortUrl.UpdatedAt.UtcDateTime
        };
    }
}