namespace Domain.Common.Menu.ValueObject;

public class MenuItemId(Guid value) : Models.ValueObject
{
    private Guid Value { get; } = value;

    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}