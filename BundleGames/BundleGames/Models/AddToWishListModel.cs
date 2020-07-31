using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class AddToWishListModel
    {
        public int GameId { get; set; }
        public int WishlistId { get; set; }
        public int KorisnikId { get; set; }
        public List<Game> WishListGames { get; set; }

        public AddToWishListModel()
        {
            WishListGames = new List<Game>();
        }
    }
}