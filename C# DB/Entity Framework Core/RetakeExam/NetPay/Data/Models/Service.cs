using System.ComponentModel.DataAnnotations;

namespace NetPay.Data.Models;

public class Service
{
    public Service()
    {
        Expenses = new List<Expense>();
        SuppliersServices = new List<SupplierService>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(30)]
    public string ServiceName { get; set; } = null!;
    public ICollection<Expense> Expenses { get; set; }
    public ICollection<SupplierService> SuppliersServices { get; set; }
}