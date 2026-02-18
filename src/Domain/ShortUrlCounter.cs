namespace Domain;

public class ShortUrlCounter : BaseEntity<int>
{
    public ShortUrlCounter()
    {
        Id = 1;
        Counter = 1000000;
    }

    public int Counter { get; private set; }

    public void IncrementCounter()
    {
        Counter += 1;
    }
}
