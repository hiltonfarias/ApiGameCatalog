using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using ApiGameCatalog.InputModel;
using ApiGameCatalog.ViewModel;
using ApiGameCatalog.Service;
using ApiGameCatalog.Exceptions;

namespace ApiGameCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;

        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameViewModel>>> getGame(
            [FromQuery, Range(1,int.MaxValue)] int page = 1, 
            [FromQuery, Range(1,50)] int quantity = 5
            )
        {
            var games = await _gameService.GetGames(page,quantity);
            if (games.Count() == 0)
                return NoContent();
            return Ok(games);
        }

        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<GameViewModel>> getGame([FromRoute] Guid gameId)
        {
            var game = await _gameService.GetGame(gameId);
            if (game == null)
                return NoContent();
            return Ok(game);
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> insertGame([FromBody] GameInputModel gameInputModel)
        {
            try
            {
                var game = await _gameService.Insert(gameInputModel);
                return Ok(game);
            }
            catch (GameAlreadyRegisteredException exception )
            {
                return UnprocessableEntity("There is already a game with this name for this producer.");
            }
        }

        [HttpPut("{game:guid}")]
        public async Task<ActionResult> updateGame([FromRoute] Guid gameId, [FromBody] GameInputModel gameInputModel)
        {
            try
            {
                await _gameService.Update(gameId,gameInputModel);
                return Ok();
            }
            catch (GameNotRegiteredException exception)
            {    
                return NotFound("Game not exist.");
            }
        }

        [HttpPatch("{gameId:guid}/price/{price:double}")]
        public async Task<ActionResult> updateGame([FromRoute] Guid gameId, [FromRoute] double price)
        {
            try
            {
                await _gameService.Update(gameId, price); 
                return Ok();
            }
            catch (GameNotRegiteredException exception)
            {
                return NotFound("Game not exist.");
            }
        }

        [HttpDelete("{gameId:guid}")] 
        public async Task<ActionResult> deleteGame(Guid gameId)
        {
            try
            {
                await _gameService.Remove(gameId); 
                return Ok();
            }
            catch (GameNotRegiteredException exception)
            {
                return NotFound("Game not exist");
            }
        }
    }
}