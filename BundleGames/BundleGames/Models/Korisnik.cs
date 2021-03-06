﻿using System;
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
        [Required]
        public string Image { get; set; }
        
        [Required]
        [Range(10,99)]
        public int Age { get; set; }
        
        public virtual ICollection<Game> Korisnik_Games { get; } = new List<Game>();
        public virtual ICollection<WishlistGame> WishlistGames { get; } = new List<WishlistGame>();
        public virtual ICollection<GameForBuying> GamesForBuying { get; } = new List<GameForBuying>();
        public virtual ICollection<GamesInShoppingCart> GamesInShoppingCart { get; } = new List<GamesInShoppingCart>();

    }
}