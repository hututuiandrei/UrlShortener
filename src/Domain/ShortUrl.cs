namespace Domain;

public class ShortUrl : BaseEntity<int>
{
    public required string ShortCode { get; set; }

    public required string Url { get; set; }
}