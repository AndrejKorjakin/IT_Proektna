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
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        [Range(5,99)]
        public int Age { get; set; }

        public List<Game> Korisnik_wishlist { get; set; }

        public Korisnik()
        {
            Korisnik_wishlist = new List<Game>();
        }
    }
}