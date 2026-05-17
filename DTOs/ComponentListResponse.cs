namespace Cw7.DTOs;

public record ComponentListResponse (
    int Amount,
    ICollection<ComponentResponse> Components
);