using Application.ShortUrls;

namespace Application.Interfaces;

public interface IShortUrlService
{
    public Task<ShortUrlDto> CreateShortUrlAsync(LongUrlDto longUrlDto, CancellationToken cancellationToken = default);
}