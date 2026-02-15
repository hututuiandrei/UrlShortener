using Application.Interfaces;
using Domain;

namespace Application.ShortUrls;

public class ShortUrlService : IShortUrlService
{
    private readonly IApplicationDbContext _context;

    public ShortUrlService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ShortUrlDto> CreateShortUrlAsync(LongUrlDto longUrlDto, CancellationToken cancellationToken = default)
    {
        var shortCodeTest = "test";

        var shortUrl = new ShortUrl
        {
            ShortCode = shortCodeTest,
            Url = longUrlDto.Url,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow
        };

        _context.ShortUrls.Add(shortUrl);

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