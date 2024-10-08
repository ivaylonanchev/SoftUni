﻿using Cadastre.Data.Enumerations;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos;

public class ImportCitizenDto
{
    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(2)]
    [MaxLength(30)]
    public string LastName { get; set; } = null!;

    [Required]
    public string BirthDate { get; set; } = null!;

    [Required]
    [EnumDataType(typeof(MaritalStatus))]
    public string MaritalStatus { get; set; } = null!;

    [Required]
    [JsonProperty(nameof(Properties))]
    public int[] Properties { get; set; } = null!;
}