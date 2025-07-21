using Domain.Common.Menu.ValueObject;
using Domain.Common.Models;

namespace Domain.Common.Menu.Entities;

public class MenuItem(MenuItemId id, string name, string description) : Entity<MenuItemId>(id)
{
    public string Name { get; } = name;

    public string Description { get; } = description;

    public static MenuItem Create(string name, string description)
    {
        return new MenuItem(MenuItemId.CreateUnique(), name, description);
    }
}