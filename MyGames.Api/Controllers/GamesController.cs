using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyGames.Api.Entities;
using MyGames.Api.Helpers;
using MyGames.Api.Models;
using MyGames.Api.Repositories;

//[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace MyGames.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository gameRepository;
        private readonly ILogger<GamesController> logger;
        private readonly IMapper mapper;

        public GamesController(IGameRepository gameRepository,
            ILogger<GamesController> logger,
            IMapper mapper)
        {
            this.gameRepository = gameRepository;
            this.logger = logger;
            this.mapper = mapper;
        }

        //public async Task<ActionResult<IEnumerable<GameDto>>> GetGames(
        //    GamesResourceParameters gamesResourceParameters)
        //{
        //    return null;
        //}

        [HttpGet("{id}", Name = "GetGame")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GameDto>> GetGame(int id)
        {
            var game = await gameRepository.GetGameAsync(id);

            if (game is null) return NotFound();

            var gameDto = mapper.Map<GameDto>(game);
            return Ok(gameDto);
        }

        [HttpPost(Name = "CreateGame")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GameDto>> CreateGame([FromBody] GameCreateDto game)
        {
            var gameEntity = mapper.Map<Game>(game);
            await gameRepository.AddGameAsync(gameEntity);

            if (!await gameRepository.SaveAsync())
                throw new Exception($"Creating game {game.Title} failed on save");

            var gameDto = mapper.Map<GameDto>(gameEntity);

            return CreatedAtRoute("GetGame",
                new { gameEntity.Id }, gameDto);
        }

        [HttpPut("{id}", Name = "UpdateGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<GameDto>> UpdateGame(int id,
            [FromBody] GameUpdateDto game)
        {
            var gameEntity = await gameRepository.GetGameAsync(id);
            if (gameEntity is null) return NotFound();

            mapper.Map(game, gameEntity);

            if (!await gameRepository.SaveAsync())
                throw new Exception($"Updating game {game.Title} failed on save");

            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteGame")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            var gameEntity = await gameRepository.GetGameAsync(id);
            if (gameEntity is null) return NotFound();

            gameRepository.DeleteGame(gameEntity);

            if (!await gameRepository.SaveAsync())
                throw new Exception($"Deleting game {gameEntity.Title} failed on save");

            return NoContent();
        }
    }
}