using System.ComponentModel.DataAnnotations;
using Invoices.Data.Models.Enums;

namespace Invoices.Data.Models;

public class Product
{
    [Key]
    public int Id { get; set; }
    [MinLength(9)]
    [MaxLength(30)]
    public string Name { get; set; } = null!;
    [Range(5.00,1000.00)]
    public decimal Price { get; set; }
    public CategoryType CategoryType { get; set; }

    public ICollection<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();
}