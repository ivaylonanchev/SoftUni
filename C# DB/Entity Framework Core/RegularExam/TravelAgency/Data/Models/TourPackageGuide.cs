using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.Extensions.Options;

namespace TravelAgency.Data.Models;

public class TourPackageGuide
{
    [Required]
    [ForeignKey(nameof(TourPackageId))]
    public int TourPackageId { get; set; }
    public TourPackage TourPackage { get; set; }

    [Required]
    [ForeignKey(nameof(GuideId))]
    public int GuideId { get; set; }
    public Guide? Guide { get; set; }
}