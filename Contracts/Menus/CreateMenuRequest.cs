﻿namespace Contracts.Menus;

public record CreateMenuRequest(
    string Name,
    string Description,
    List<MenuSection> Sections
);

public record MenuSection(
    string Name,
    string Description,
    List<MenuItem> MenuItems
);

public record MenuItem(
    string Name,
    
    string Description);