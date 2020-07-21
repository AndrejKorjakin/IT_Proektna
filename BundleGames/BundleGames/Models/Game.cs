using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Game
    {
        
        [Key]
        public int Id { get; set; }
        public string GameName { get; set; }
        public string GameImage { get; set; }
        public float GameCena { get; set; }
        public string GameInfo { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }

        public List<string> Tags { get; set; }

        public Game()
        {
            Tags = new List<string>();
        }


    }
}