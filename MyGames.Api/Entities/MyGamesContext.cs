using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Entities
{
    public class MyGamesContext : DbContext
    {
        public MyGamesContext(DbContextOptions<MyGamesContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Game> Games { get; set; }
    }
}
