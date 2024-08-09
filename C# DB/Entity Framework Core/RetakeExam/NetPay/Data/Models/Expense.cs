using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NetPay.Data.Models.Enums;

namespace NetPay.Data.Models;

public class Expense
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string ExpenseName { get; set; } = null!;

    [Required]
    [Range(0.01, 100000)]

    public decimal Amount { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    [Range(0,3)]
    public PaymentStatus PaymentStatus { get; set; }

    [Required]
    [ForeignKey(nameof(HouseholdId))]
    public int HouseholdId { get; set; }
    public Household Household { get; set; }

    [Required]
    [ForeignKey(nameof(ServiceId))]
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}