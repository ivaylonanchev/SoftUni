using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace NetPay.Data.Models;

public class Household
{
    public Household()
    {
        Expenses = new List<Expense>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string ContactPerson { get; set; } = null!;

    [MinLength(6)]
    [MaxLength(80)]
    public string? Email { get; set; }

    [Required]
    [RegularExpression(@"^\+\d{3}/\d{3}-\d{6}$")]
    [StringLength(15)]
    public string PhoneNumber { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; }
}