using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public List<Game> GamesForBuying { get; set; }

        public ShoppingCart()
        {
            GamesForBuying = new List<Game>();
        }

    }
}