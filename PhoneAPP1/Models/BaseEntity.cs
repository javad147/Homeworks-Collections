public class BaseEntity
{
    private static int _idCounter = 1;

    public int Id { get; private set; }

    public BaseEntity()
    {
        Id = _idCounter++;
    }
}
