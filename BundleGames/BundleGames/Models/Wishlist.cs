using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Wishlist_Name { get; set; }
        public List<Game> Wishlist_Games { get; set; }

        public Wishlist()
        {
            Wishlist_Games = new List<Game>();
        }
    }
}