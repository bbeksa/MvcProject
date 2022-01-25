using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Podaj nazwę!")]
        public string? Name { get; set; }
        
        [ForeignKey("Seazon")]
        public int SeazonId { get; set; }
        
        [Required]
        [Range(1, 10, ErrorMessage = "Możliwa pozycja: 1-10")]
        public int Classification { get; set; }
        
        [ForeignKey("TopId")]
        public int TopPlayerId { get; set; }
        [ForeignKey("JungId")]
        public int JungPlayerId { get; set; }
        [ForeignKey("MidId")]
        public int MidPlayerId { get; set; }
        [ForeignKey("AdcId")]
        public int AdcPlayerId { get; set; }
        [ForeignKey("SuppId")]
        public int SuppPlayerId { get; set; }
        
        
        public virtual Seazon? Seazon { get; set; }
        public virtual Player? TopPlayer { get; set; }
        public virtual Player? JungPlayer { get; set; }
        public virtual Player? MidPlayer { get; set; }
        public virtual Player? AdcPlayer { get; set; }
        public virtual Player? SuppPlayer { get; set; }

    }
}