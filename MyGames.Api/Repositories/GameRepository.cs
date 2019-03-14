using Microsoft.EntityFrameworkCore;
using MyGames.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly MyGamesContext context;

        public GameRepository(MyGamesContext context)
        {
            this.context = context;
        }

        public async Task AddGameAsync(Game game)
        {
            await context.Games.AddAsync(game);
        }

        public void DeleteGame(Game game)
        {
            context.Games.Remove(game);
        }

        public bool GameExists(int id)
        {
            return context.Games.Any(g => g.Id == id);
        }

        public async Task<Game> GetGameAsync(int id)
        {
            var game = await context.Games
                .FirstOrDefaultAsync(g => g.Id == id);
            return game;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() >= 0;
        }

        public void UpdateGame(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
