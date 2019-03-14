using Microsoft.EntityFrameworkCore;
using MyGames.Api.Entities;
using MyGames.Api.Helpers;
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

        public async Task<IEnumerable<Game>> GetGamesAsync(GamesResourceParameters gamesResourceParameters)
        {
            var games = GetFilteredGames(gamesResourceParameters);

            var gamesToReturn = await games
                .OrderBy(g => g.Title)
                .Take(gamesResourceParameters.NumberOfRecords)
                .AsNoTracking()
                .ToListAsync();

            return gamesToReturn;
        }

        public async Task<Game> GetRandomGameAsync(GamesResourceParameters gamesResourceParameters)
        {
            var games = await GetFilteredGames(gamesResourceParameters).ToListAsync();
            if (games is null) return null;

            var random = new Random();
            int randomElementId = random.Next(games.Count());

            var game = games[randomElementId];
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

        private IQueryable<Game> GetFilteredGames(GamesResourceParameters gamesResourceParameters)
        {
            var games = context.Games.AsQueryable();

            if (!string.IsNullOrEmpty(gamesResourceParameters.Genre))
            {
                var genreWhereClause = gamesResourceParameters.Genre
                    .Trim().ToLowerInvariant();

                games = games.Where(g => g.Genre.ToLowerInvariant() == genreWhereClause);
            }

            if (!string.IsNullOrEmpty(gamesResourceParameters.Platform))
            {
                var platformWhereClause = gamesResourceParameters.Platform
                    .Trim().ToLowerInvariant();

                games = games.Where(p => p.Platform.ToLower() == platformWhereClause);
            }

            return games;
        }
    }
}
