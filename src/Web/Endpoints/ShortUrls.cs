using Application.Interfaces;
using Application.ShortUrls;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Web.Endpoints;

public class ShortUrls : EndpointGroupBase
{
    public override string GroupName => "shorten";

    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", CreateShortUrl);
    }

    public async Task<Created<ShortUrlDto>> CreateShortUrl(IShortUrlService shortUrlService, LongUrlDto longUrl)
    {
        var result = await shortUrlService.CreateShortUrlAsync(longUrl);

        return TypedResults.Created((string?)null, result);
    }
}