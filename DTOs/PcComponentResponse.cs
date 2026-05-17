namespace Cw7.DTOs;

public record PcComponentResponse(
    int Id,
    string Name,
    float Weight,
    int Warranty,
    DateTime CreatedAt,
    int Stock,
    IEnumerable<ComponentListResponse> Components
    );