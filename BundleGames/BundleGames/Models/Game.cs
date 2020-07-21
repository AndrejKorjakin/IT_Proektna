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
        public string Name { get; set; }
        public string GameImage { get; set; }
        public string GameInfo { get; set; }
        public string Publisher { get; set; }
        public string Developer { get; set; }





    }
}