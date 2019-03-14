using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Helpers
{
    public class GamesResourceParameters
    {
        public int NumberOfRecords { get; set; } = 10;
        public string Genre { get; set; }
        public string Platform { get; set; }        
    }
}
