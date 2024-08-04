using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Boardgames.Data.Models.Enums;

namespace Boardgames.Data.Models;

public class Boardgame
{
    public Boardgame()
    {
        BoardgamesSellers = new List<BoardgameSeller>();
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MinLength(10)]
    [MaxLength(20)]
    public string? Name { get; set; } = null!;
    [Required]
    [Range(1,10)]
    public double Rating { get; set; }
    [Required]
    [Range(2018,2023)]
    public int YearPublished { get; set; }

    [Required]
    [Range(0,4)]
    public CategoryType CategoryType { get; set; }

    [Required] 
    public string Mechanics { get; set; }

    [Required]
    [ForeignKey(nameof(CreatorId))]
    public int CreatorId { get; set; }
    public Creator Creator { get; set; }

    public ICollection<BoardgameSeller> BoardgamesSellers { get; set; } 
}