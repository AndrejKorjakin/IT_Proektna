﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class GameForBuying
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public int KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public GameForBuying()
        {

        }
        public GameForBuying(int korisnik_Id)
        {
            KorisnikId = korisnik_Id;
        }
    }
}