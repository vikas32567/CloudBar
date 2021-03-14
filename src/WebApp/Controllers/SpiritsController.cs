using WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace WebApp.Controllers
{
    public class SpiritsController : Controller
    {
        private readonly ISpiritService spiritService;
        private readonly ILogger<SpiritsController> logger;

        public SpiritsController(ISpiritService spiritService, ILogger<SpiritsController> logger)
        {
            this.spiritService = spiritService;
            this.logger = logger;
        }


        [HttpGet("spirits")]
        public IActionResult Index()
        {
            logger.LogDebug("Fetching spirits by EF Core.");
            var spirits = spiritService.GetSpiritsByEf().Select(s => new SpiritViewModel(s)).ToList();

            if (spirits.Any())
                return View(spirits);

            return new NoContentResult();
        }

        [HttpGet("spirits/add")]
        public IActionResult AddSpirit()
        {
            var spirit = new SpiritViewModel();
            return View(spirit);
        }

        [HttpPost("spirits/add")]
        public async Task<IActionResult> AddSpirit([FromForm]SpiritViewModel spirit)
        {
            if (!ModelState.IsValid)
                return View(spirit);
            
            await spiritService.AddSpirit(spirit.ToSpirit());

            return RedirectToAction("Index");
        }


        [HttpGet("spirits/{spiritId}/update")]
        public IActionResult UpdateSpirit(long spiritId)
        {
            var spirit = spiritService.GetSpirit(spiritId);
            return View(new SpiritViewModel(spirit));
        }

        [HttpPost("spirits/{spiritId}/update")]
        public async Task<IActionResult> UpdateSpirit([FromForm]SpiritViewModel spirit)
        {
            if (!ModelState.IsValid)
                return View(spirit);

            await spiritService.UpdateSpirit(spirit.ToSpirit());

            return RedirectToAction("Index");
        }

    }
}