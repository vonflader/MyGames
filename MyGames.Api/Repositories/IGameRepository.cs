using MyGames.Api.Entities;
using MyGames.Api.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Repositories
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> GetGamesAsync(GamesResourceParameters gamesResourceParameters);
        Task<Game> GetGameAsync(int id);
        Task<Game> GetRandomGameAsync(GamesResourceParameters gamesResourceParameters);
        Task AddGameAsync(Game game);
        void DeleteGame(Game game);
        void UpdateGame(Game game);
        bool GameExists(int id);
        Task<bool> SaveAsync();
    }
}
