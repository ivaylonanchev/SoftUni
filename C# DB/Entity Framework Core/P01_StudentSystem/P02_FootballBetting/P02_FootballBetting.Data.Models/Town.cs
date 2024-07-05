using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02_FootballBetting.P02_FootballBetting.Data.Models
{
    public class Town
    {
        [Key]
        public int TownId { get; set; }
        public string Name { get; set; }
        public int CountyId { get; set; }
        [ForeignKey(nameof(CountyId))]
        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; }
    }
}
