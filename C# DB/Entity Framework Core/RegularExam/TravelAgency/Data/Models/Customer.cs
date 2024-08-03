using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace TravelAgency.Data.Models;

public class Customer
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [Range(4, 60)] 
    public string? FullName { get; set; } = null!;

    [Required]
    [Range(6,50)]
    public string? Email { get; set; } = null!;

    [Required]
    [StringLength(13)]
    [RegularExpression(@"\+\d{12}")]
    public string? PhoneNumber { get; set; } = null!;

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}