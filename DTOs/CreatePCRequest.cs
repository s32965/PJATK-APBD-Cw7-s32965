using System.ComponentModel.DataAnnotations;

namespace Cw7.DTOs;

public record CreatePCRequest (
    [Required(ErrorMessage = "PC name is required."), MaxLength(50, ErrorMessage = "PC name must be less than 50 characters.")] string Name,
    [Required(ErrorMessage = "Weight is required.")] float Weight,
    [Required(ErrorMessage = "Warranty duration is required.")] int Warranty,
    [Required(ErrorMessage = "Creation date is required.")] DateTime CreatedAt,
    [Required(ErrorMessage = "Stock quantity is required.")] int Stock
);