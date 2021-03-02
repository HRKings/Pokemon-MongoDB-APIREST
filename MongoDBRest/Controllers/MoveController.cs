using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDBRest.Dto;
using MongoDBRest.Models;
using MongoDBRest.Services;

namespace MongoDBRest.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class MoveController : ControllerBase
    {
        private readonly MoveService _moveService;

        public MoveController(MoveService moveService)
        {
            _moveService = moveService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Move>>> Get()
            => await _moveService.Get();

        [HttpGet("{id:length(24)}", Name = "GetMove")]
        public async Task<ActionResult<Move>> Get(string id)
            => await _moveService.Get(id);

        [HttpPost]
        public async Task<ActionResult<Move>> Create(MoveDto move)
        {
            var newMove = new Move
            {
                Name = move.Name,
                Attack = move.Attack, 
                Accuracy = move.Accuracy
            };
            var result = await _moveService.Create(newMove);

            return CreatedAtRoute("GetMove", new {id = result.ID}, newMove);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Move>> Update(string id, MoveDto move)
        {
            var updatedMove = new Move
            {
                ID = id,
                Name = move.Name,
                Attack = move.Attack, 
                Accuracy = move.Accuracy
            };
            await _moveService.Update(id, updatedMove);

            return updatedMove;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _moveService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            await _moveService.Remove(item.ID);

            return Ok();
        }
    }
}