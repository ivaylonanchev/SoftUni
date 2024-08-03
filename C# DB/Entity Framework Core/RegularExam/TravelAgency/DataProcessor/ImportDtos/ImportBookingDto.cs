using System.ComponentModel.DataAnnotations;

namespace TravelAgency.DataProcessor.ImportDtos;

public class ImportBookingDto
{
    [Required]
    public string? BookingDate  { get; set; } = null!;
    public string? CustomerName { get; set; } = null!;
    public string? TourPackageName { get; set; } = null!;
}