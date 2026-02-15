namespace Domain;

public class BaseEntity<TKey> where TKey : struct
{
    public TKey Id { get; set; }

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }
}