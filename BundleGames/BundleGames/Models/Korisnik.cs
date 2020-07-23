using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Име")]
        public string Korisnik_Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [Range(10,99)]
        public int Age { get; set; }
        public List<Game> Korisnik_Games { get; set; }

        public Wishlist Korisnik_Wishlist { get; set; }

        public Korisnik()
        {
            
            Korisnik_Games = new List<Game>();
        }
    }
}