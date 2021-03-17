using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nuclear_server.Repositories;

namespace nuclear_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GeostampController : ControllerBase
    {
        private readonly ILogger<GeostampController> _logger;
        private readonly GeostampRepository _repo;

        public GeostampController(ILogger<GeostampController> logger)
        {
            _logger = logger;
            // In a more complex project this would be an interface we code to, not a concrete class.
            // Wed also have more robust logging etc.
            _repo = new GeostampRepository();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Geostamp))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Geostamp))]
        public IActionResult Post(Geostamp stamp)
        {
            return _repo.InsertGeostamp(stamp) ? Ok(stamp) : BadRequest();
        }
    }
}