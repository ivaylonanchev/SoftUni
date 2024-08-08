﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cadastre.Data.Models;

public class PropertyCitizen
{
    [Required]
    [ForeignKey(nameof(PropertyId))]
    public int PropertyId { get; set; }
    public Property Property { get; set; }
    [Required]
    [ForeignKey(nameof(CitizenId))]
    public int CitizenId { get; set; }
    public Citizen Citizen { get; set; }

}