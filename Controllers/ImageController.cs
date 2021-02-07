using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeLexApi.Interfaces;


namespace PokeLexApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        private readonly ILogger<PokemonController> _logger;

        public ImageController(ILogger<PokemonController> logger, IImageRepository imageRepository)
        {
            _logger = logger;
            _imageRepository = imageRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var bytes = await _imageRepository.GetPokemonImage(id);
            return File(bytes.ContentImage, "image/png");
        }
    }
}
