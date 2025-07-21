namespace Domain.Common.Menu.ValueObject;

public class MenuId(Guid value) : Models.ValueObject
{
    public Guid Value { get; } = value;

    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}