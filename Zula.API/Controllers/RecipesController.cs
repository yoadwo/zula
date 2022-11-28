using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Zula.API.Handlers;
using Zula.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Zula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly ILogger<RecipesController> _logger;
        private readonly IRecipesHandler _recipesHandler;

        public RecipesController(ILogger<RecipesController> logger, IRecipesHandler recipesHandler)
        {
            _logger = logger;
            _recipesHandler = recipesHandler;
        }

        // GET: api/<RecipesController>
        [HttpGet]
        public async Task<IEnumerable<Recipe>> Get([FromQuery][Required] string query)
        {
            return await _recipesHandler.GetAllRecipesAsync(query);
        }

        // GET api/<RecipesController>/5
        [HttpGet("{id}")]
        public async Task<Recipe> Get(int id)
        {
            return await _recipesHandler.GetRecipeAsync(id);
        }

        // POST api/<RecipesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
