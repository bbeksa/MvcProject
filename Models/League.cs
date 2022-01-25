using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MvcProject.Helpers;

namespace MvcProject.Models
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        
        [LeagName(Maximum = 5, ErrorMessage = "Max 5 znaków, akceptowalne tylko wielkie litery.")]
        [Required(ErrorMessage = "Podaj nazwę!")]
        public string? Name { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Podaj lokalizację, wielką literą!")]
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Podaj lokalizację!")]
        public string? Localization { get; set; }
        public virtual ICollection<Seazon>? Seazons { get; set; }
    }
}