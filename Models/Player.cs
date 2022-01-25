using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProject.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Podaj imię!")]
        public string? FirstName { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [StringLength(60, MinimumLength = 2)]
        [Required(ErrorMessage = "Podaj nazwisko!")]
        public string? LastName { get; set; }
        
        [StringLength(60, MinimumLength = 2)]
        public string? Nickname { get; set; }
        
        [Required(ErrorMessage = "Wybierz role!")]
        public string Role { get; set; }
        
        [Required]
        [Range(16, 60, ErrorMessage = "Akceptowalny wiek: 16-60")]
        public int Age { get; set; }
        
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
        [Required(ErrorMessage = "Podaj kraj pochodzenia!")]
        [StringLength(30)]
        public string? CountryOfBirth { get; set; }
        
        public string DataTextFieldLabel
        {
            get
            {
                if (Nickname != null)
                {
                    return (FirstName + " \"" + Nickname + "\" " + LastName);
                }
                else
                {
                    return (FirstName + LastName);
                }
            }
        }
    }
}