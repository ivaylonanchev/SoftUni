using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Medicines.Data.Models.Enums;

namespace Medicines.Data.Models;

public class Medicine
{
    public Medicine()
    {
        PatientsMedicines = new List<PatientMedicine>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(150)]
    public string Name { get; set; }
    [Required]
    [Range(0.01,1000)]
    public decimal Price { get; set; }
    [Required]
    [Range(0,4)]
    public Category Category { get; set; }
    [Required]
    public DateTime ProductionDate { get; set; }
    [Required]
    public DateTime ExpiryDate { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public string Producer { get; set; }
    [Required]
    [ForeignKey(nameof(PharmacyId))]
    public int PharmacyId { get; set; }
    public Pharmacy Pharmacy { get; set; }
    public ICollection<PatientMedicine> PatientsMedicines { get; set; }
}