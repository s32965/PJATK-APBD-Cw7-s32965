namespace Cw7.DTOs;

public record PCListResponse (
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock
);