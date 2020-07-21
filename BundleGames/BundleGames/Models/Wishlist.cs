using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Wishlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Game> Wishlist_list { get; set; }

        public Wishlist()
        {
            Wishlist_list = new List<Game>();
        }
    }
}