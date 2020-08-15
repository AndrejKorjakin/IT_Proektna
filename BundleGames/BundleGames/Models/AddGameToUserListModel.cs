using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BundleGames.Models
{
    public class AddGameToUserListModel
    {
        public int Id { get; set; }

        public int GameId { get; set; }
        public int UserId { get; set; }

    }
}