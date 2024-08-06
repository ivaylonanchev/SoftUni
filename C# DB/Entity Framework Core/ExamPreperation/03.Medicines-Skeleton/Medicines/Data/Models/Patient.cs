using System.ComponentModel.DataAnnotations;
using Medicines.Data.Models.Enums;

namespace Medicines.Data.Models;

public class Patient
{
    public Patient()
    {
        PatientsMedicines = new List<PatientMedicine>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string FullName { get; set; }
    [Required]
    [Range(0,2)]
    public AgeGroup AgeGroup { get; set; }
    [Required]
    [Range(0,1)]
    public Gender Gender { get; set; }
    public ICollection<PatientMedicine> PatientsMedicines { get; set; }
}