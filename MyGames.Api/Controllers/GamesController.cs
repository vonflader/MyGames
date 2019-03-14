using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.Api.Repositories;

//[assembly: ApiConventionType(typeof(DefaultApiConventions))]
namespace MyGames.Api.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameRepository gameRepository;

        public GamesController(IGameRepository gameRepository)
        {
            this.gameRepository = gameRepository;
        }
    }
}