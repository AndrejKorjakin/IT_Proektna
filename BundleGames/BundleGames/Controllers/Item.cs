using BundleGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Controllers
{
    public class Item

    {

        public int Id { get; set; }
        public Game game = new Game();

        
        
        public Item()
        {

        }

        public Item(Game game)
        {
            this.game = game;

        }
    }

    
}