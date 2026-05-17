using System.ComponentModel.DataAnnotations;

namespace Cw7.DTOs;

public record UpdatePCRequest (
    [Required(ErrorMessage = "PC name is required."), MaxLength(50, ErrorMessage = "PC name must be less than 50 characters.")] string Name,
    [Required(ErrorMessage = "Weight is required.")] float Weight,
    [Required(ErrorMessage = "Warranty duration is required.")] int Warranty,
    [Required(ErrorMessage = "Stock quantity is required.")] int Stock
);