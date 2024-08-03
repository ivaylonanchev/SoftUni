using System.ComponentModel.DataAnnotations;

namespace TravelAgency.Data.Models;

public class TourPackage
{
    [Key]
    public int Id { get; set; }
    [Required]
    [Range(2,40)]
    public string? PackageName { get; set; } = null!;

    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    public decimal Price { get; set; }
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<TourPackageGuide> TourPackagesGuides { get; set; } = new List<TourPackageGuide>();
}