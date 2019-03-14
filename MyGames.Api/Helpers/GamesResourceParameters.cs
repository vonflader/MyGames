using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Helpers
{
    public class GamesResourceParameters
    {
        public int GameNumber { get; set; } = 5;
        public string Genre { get; set; }
        public string Platform { get; set; }        
    }
}
