using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient.DataClassification;

namespace NetPay.Data.Models;

public class Supplier
{
    public Supplier()
    {
        SuppliersServices = new List<SupplierService>();
    }
    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(60)]
    public string SupplierName { get; set; } = null!;
    public ICollection<SupplierService> SuppliersServices { get; set; }
}