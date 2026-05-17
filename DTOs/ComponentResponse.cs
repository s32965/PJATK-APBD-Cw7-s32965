namespace Cw7.DTOs;

public record ComponentResponse(
    string ComponentCode,
    string ComponentName,
    string Description,
    ManufacturerResponse Manufacturer,
    TypeResponse Type
    );