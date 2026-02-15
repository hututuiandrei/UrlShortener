namespace Application.ShortUrls;

public class ShortUrlDto
{
    public int Id { get; init; }

    public required string Url { get; init; }

    public required string ShortCode { get; init; }

    public DateTime CreatedAt { get; init; }

    public DateTime UpdatedAt { get; init; }
}