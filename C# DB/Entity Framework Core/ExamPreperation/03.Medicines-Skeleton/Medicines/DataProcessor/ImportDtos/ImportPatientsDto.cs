using Medicines.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos;

public class ImportPatientsDto
{
    public int[] Medicines { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(100)]
    public string FullName { get; set; }
    [Required]
    [Range(0, 2)]
    public int AgeGroup { get; set; }
    [Required]
    [Range(0, 1)]
    public int Gender { get; set; }
}