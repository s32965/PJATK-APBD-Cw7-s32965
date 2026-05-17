namespace Cw7.DTOs;

public record ManufacturerResponse(
    int Id,
    string Abbreviation,
    string FullName,
    DateOnly FoundationDate
    );