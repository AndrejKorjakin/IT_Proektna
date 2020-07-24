using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class PopustGames
    {
        public int Id { get; set; }

        public List<Game> PopustGamesList {get;set;}
        public float NovaCena { get; set; }
        public int PopustGame { get; set; }

        public PopustGames()
        {
            PopustGamesList = new List<Game>();
        }
    }
}