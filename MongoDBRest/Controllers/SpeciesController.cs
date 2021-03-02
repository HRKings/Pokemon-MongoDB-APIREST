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
    public class SpeciesController : ControllerBase
    {
        private readonly SpeciesService _speciesService;

        public SpeciesController(SpeciesService speciesService)
        {
            _speciesService = speciesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Species>>> Get() 
            =>  await _speciesService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSpecies")]
        public async Task<ActionResult<Species>> Get(string id)
            => await _speciesService.Get(id);
        
        [HttpPost]
        public async Task<ActionResult<Species>> Create(SpeciesDto species)
        {
            var newSpecies = new Species
            {
                Name = species.Name,
                CatchRate = species.CatchRate
            };
            var result = await _speciesService.Create(newSpecies);

            return CreatedAtRoute("GetSpecies", new { id = result.ID }, newSpecies);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<ActionResult<Species>> Update(string id, SpeciesDto species)
        {
            var newSpecies = new Species
            {
                ID = id,
                Name = species.Name,
                CatchRate = species.CatchRate
            };
            await _speciesService.Update(id, newSpecies);

            return newSpecies;
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var item = await _speciesService.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            await _speciesService.Remove(item.ID);

            return Ok();
        }
    }
}