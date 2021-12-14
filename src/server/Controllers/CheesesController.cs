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

        [HttpGet(Name = "GetCheeses")]
        public async Task<IEnumerable<Cheese>> Get()
        {
            var cheeses = await _cheeseRepository.GetAll();
            return cheeses;
        }
    }
}