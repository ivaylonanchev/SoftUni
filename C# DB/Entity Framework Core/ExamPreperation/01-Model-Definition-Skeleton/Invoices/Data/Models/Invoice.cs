using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models;

public class Invoice
{
    [Key]
    public int Id { get; set; }
    [Required]

    [MinLength(1000000000)]
    [MaxLength(1500000000)]
    public int Number { get; set; }

    [Required]
    public DateTime IssueDate { get; set; }
    [Required]
    public DateTime DueDate { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public CurrencyType CurrencyType { get; set; }
    [Required]

    [ForeignKey(nameof(ClientId))]
    public int ClientId { get; set; }
    public Client? Client { get; set; }
}