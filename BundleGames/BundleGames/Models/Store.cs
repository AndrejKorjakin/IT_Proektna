﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string StoreName { get; set; }

        public List<Game> StoreGames { get; set; }
        public Store()
        {
            StoreGames = new List<Game>();
        }
    }
}