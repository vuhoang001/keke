using Domain.Common.Menu.Entities;
using Domain.Common.Menu.ValueObject;
using Domain.Common.Models;

namespace Domain.Common.Menu;

public sealed class Menu(MenuId id, string name, string description) : AggregateRoot<MenuId>(id)
{
    public string Name { get; set; } = name;
    public string Description { get; set; } = description;
    public float AverageRating { get; set; }

    private readonly List<MenuSection> _sections = [];

    public IReadOnlyList<MenuSection> Sections => _sections;
}