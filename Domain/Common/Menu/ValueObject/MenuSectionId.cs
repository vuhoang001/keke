namespace Domain.Common.Menu.ValueObject;

public class MenuSectionId(Guid value) : Models.ValueObject
{
    private Guid Value { get; } = value;

    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}