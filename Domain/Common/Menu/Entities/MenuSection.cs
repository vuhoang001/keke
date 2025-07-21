using Domain.Common.Menu.ValueObject;
using Domain.Common.Models;

namespace Domain.Common.Menu.Entities;

public class MenuSection(MenuSectionId id, string name, string description) : Entity<MenuSectionId>(id)
{
    public string Name { get; } = name;
    public string Description { get; } = description;
    private readonly List<MenuItem> _items = [];

    private IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

    public static MenuSection Create(string name, string description)
    {
        return new MenuSection(MenuSectionId.CreateUnique(), name, description);
    }
}