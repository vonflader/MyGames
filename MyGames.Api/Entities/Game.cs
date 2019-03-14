using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string Genre { get; set; }
        public string Platform { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float? Score { get; set; }
    }
}
