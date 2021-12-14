using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheesesController : ControllerBase
    {
        private readonly ILogger<CheesesController> _logger;
        private readonly ICheeseRepository _cheeseRepository;

        public CheesesController(ILogger<CheesesController> logger, ICheeseRepository cheeseRepository)
        {
            _logger = logger;
            _cheeseRepository = cheeseRepository;
        }

        /// <summary>
        /// Gets all of the Cheese items.
        /// </summary>
        /// <returns>An array of Cheese items.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Cheeses
        ///
        /// </remarks>
        /// <response code="200">Returns the all of the cheese items.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Cheese>>> Get()
        {
            var cheeses = await _cheeseRepository.GetAll();
            return Ok(cheeses);
        }

        /// <summary>
        /// Returns a single Cheese item.
        /// </summary>
        /// <param name="id">The id of the Cheese item to return.</param>
        /// <returns>A Cheese item</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     GET /Cheeses/1
        ///
        /// </remarks>
        /// <response code="200">Returns the Cheese item for the given [id].</response>
        /// <response code="404">If the [id] is not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Cheese>> Get(uint id)
        {
            try
            {
                var cheese = await _cheeseRepository.Get(id);
                return Ok(cheese);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Cheese with id: {id}, not found");
                return NotFound();
            }
        }

        /// <summary>
        /// Creates a Cheese item.
        /// </summary>
        /// <param name="cheese"></param>
        /// <returns>A newly created Cheese.</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Cheeses
        ///     {
        ///        "id": 1,
        ///        "name": "Gorgonzola",
        ///        "picture": "gorgonzola.jpg"
        ///        "color": "White with blue streaks",
        ///        "price": 5.65
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created item.</response>
        /// <response code="400">If [cheese] param is null.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Cheese>> Post(Cheese cheese)
        {
            if (cheese == null)
            {
                return BadRequest();
            }
            
            var newCheese = await _cheeseRepository.Add(cheese);
            return CreatedAtAction(nameof(Get), new { id = newCheese.Id }, newCheese);
        }

        /// <summary>
        /// Update a Cheese item.
        /// </summary>
        /// <param name="id">The Id of the Cheese item to update.</param>
        /// <param name="cheese">The Cheese item with updated fields. Will return error 400 if Id and cheese.Id are not equal.</param>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /Cheeses/1
        ///     {
        ///        "id": 1,
        ///        "name": "Gorgonzola",
        ///        "picture": "gorgonzola.jpg"
        ///        "color": "White with blue streaks",
        ///        "price": 5.65
        ///     }
        ///
        /// </remarks>
        /// <response code="204">Update was successful.</response>
        /// <response code="400">If [cheese] param is null or if the [id] param and [cheese.Id] param are not equal.</response>
        /// <response code="404">If the [id] is not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutTodoItem(uint id, Cheese cheese)
        {
            if (cheese == null || id != cheese.Id)
            {
                return BadRequest();
            }

            try
            {
                await _cheeseRepository.Update(cheese);
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Cheese with id: {id}, not found");
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Delete a single Cheese item.
        /// </summary>
        /// <param name="id">The id of the Cheese item to delete.</param>
        /// <returns>A Cheese item</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     DELETE /Cheeses/1
        ///
        /// </remarks>
        /// <response code="204">The delete was successful.</response>
        /// <response code="404">If the [id] is not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(uint id)
        {
            try
            {
                await _cheeseRepository.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                _logger.LogError($"Cheese with id: {id}, not found");
                return NotFound();
            }
        }
    }
}