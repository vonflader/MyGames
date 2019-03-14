using MyGames.Api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.Api.Repositories
{
    public interface IGameRepository
    {
        Task<Game> GetGameAsync(int id);
        Task AddGameAsync(Game game);
        void DeleteGame(Game game);
        void UpdateGame(Game game);
        bool GameExists(int id);
        Task<bool> SaveAsync();
    }
}
