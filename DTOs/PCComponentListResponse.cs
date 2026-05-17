namespace Cw7.DTOs;

public record PCComponentListResponse (
    string ComponentCode,
    string ComponentName,
    int Amount,
    string ManufacturerName,
    string TypeName
);