using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MvcProject.Helpers;

namespace MvcProject.Models
{
    public class Seazon
    {
        public int SeazonId { get; set; }
        [SezName(ErrorMessage = "Podaj nazwę! Format: Spring/Summer + rok")]
        [StringLength(50, MinimumLength = 3)]
        [Required(ErrorMessage = "Podaj nazwę! Format: Spring/Summer + rok")]
        public string Name { get; set; }
        [ForeignKey("LeagueId")]
        [Required]
        public int LeagueId { get; set; }

        public virtual League? League { get; set; }
        public virtual ICollection<Team>? Teams { get; set; }
        
        
        public string DataTextFieldLabel
        {
            get
            {
                if (League != null)
                {
                    return (League.Name + ": " + Name);
                }
                else
                {
                    return (Name);
                }
            }
        }
    }
}