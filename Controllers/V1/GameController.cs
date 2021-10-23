using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiGameCatalog.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<object>>> getGame()
        {
            return Ok();
        }

        [HttpGet("{gameId:guid}")]
        public async Task<ActionResult<object>> getGame(Guid gameId)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<object>> insertGame(object game)
        {
            return Ok();
        }

        [HttpPut("{game:guid}")]
        public async Task<ActionResult> updateGame(Guid gameId, object game)
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