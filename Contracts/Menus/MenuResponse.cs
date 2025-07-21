﻿namespace Contracts.Menus;

public record MenuResponse(
    string Id,
    string Name,
    string Description,
    float? AverageRating,
    List<MenuSectionResponse> Sections
);

public record MenuSectionResponse(
    string Id,
    string Name,
    string Description
);

public record MenuItemResponse(
    string Id,
    string Name,
    string Description
);