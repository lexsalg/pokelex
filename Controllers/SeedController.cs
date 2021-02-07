using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using PokeLexApi.Interfaces;

namespace PokeLexApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class SeedController : ControllerBase
    {
        private readonly ILoadDataService _loadDataService;
        private readonly ILogger<PokemonController> _logger;

        public SeedController(ILogger<PokemonController> logger, ILoadDataService loadDataService)
        {
            _logger = logger;
            _loadDataService = loadDataService;
        }

        [HttpGet]
        public OkResult CargarDataDB()
        {
            _loadDataService.LoadData();
            return new OkResult();
        }

        [HttpDelete]
        public OkResult BorrarDataDB()
        {
            _loadDataService.DeleteData();
            return new OkResult();
        }
    }
}
