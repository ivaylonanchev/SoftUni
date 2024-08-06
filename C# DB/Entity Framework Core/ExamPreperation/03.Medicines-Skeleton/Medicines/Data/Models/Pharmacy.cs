using System.ComponentModel.DataAnnotations;

namespace Medicines.Data.Models;

public class Pharmacy
{
    public Pharmacy()
    {
        Medicines = new List<Medicine>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [StringLength(14)]
    [RegularExpression(@"\([0-9]{3}\)\ [0-9]{3}\-[0-9]{4}")]
    public string PhoneNumber { get; set; }
    [Required]
    public bool IsNonStop { get; set; }
    public ICollection<Medicine> Medicines { get; set; }
}