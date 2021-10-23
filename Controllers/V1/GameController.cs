using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using ApiGameCatalog.InputModel;
using ApiGameCatalog.ViewModel;

namespace ApiGameCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<GameViewModel>>> getGame()
        {
            return Ok();
        }

        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<GameViewModel>> getGame(Guid gameId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> insertGame(GameInputModel game)
        {
            return Ok();
        }

        [HttpPut("{game:guid}")]
        public async Task<ActionResult> updateGame(Guid gameId, GameInputModel game)
        {
            return Ok();
        }

        [HttpPatch("{gameId:guid}/price/{price:double}")]
        public async Task<ActionResult> updateGame(Guid gameId, double price)
        {
            return Ok();
        }

        [HttpDelete("{gameId:guid}")] 
        public async Task<ActionResult> deleteGame(Guid gameId)
        {
            return Ok();
        }
    }
}