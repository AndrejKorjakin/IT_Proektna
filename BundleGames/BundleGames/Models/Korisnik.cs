using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Korisnik
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Име")]
        public string Korisnik_Name { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public string Image { get; set; }
        
        [Required]
        [Range(10,99)]
        public int Age { get; set; }
        public int IsAdmin = 0;
        public virtual ICollection<Game> Korisnik_Games { get; set; }

        public Wishlist Korisnik_Wishlist { get; set; }

        
    }
}