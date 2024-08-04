﻿using Boardgames.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace Boardgames.DataProcessor.ImportDto;

public class ImportSellersDto
{
    [Required]
    [MinLength(5)]
    [MaxLength(20)]
    public string? Name { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string? Address { get; set; } = null!;

    [Required]
    public string? Country { get; set; } = null!;

    [Required]
    [RegularExpression(@"\w{3}\.[a-zA-Z\-]+\.com$")]
    public string? Website { get; set; } = null!;

    public int[] Boardgames { get; set; }
}