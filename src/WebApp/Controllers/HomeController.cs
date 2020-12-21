using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISpiritService spiritService;

        public HomeController(ILogger<HomeController> logger, ISpiritService spiritService)
        {
            _logger = logger;
            this.spiritService = spiritService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        /// <summary>
        /// Retrieve list of all spirits.
        /// </summary>
        /// <remarks>
        ///     Dapper is used while retrieving data from DB.
        /// </remarks>
        /// <returns>list of Spirit objects</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("dapper/spirits")]
        public IActionResult GetSpiritsByDapper()
        {
            _logger.LogDebug("Fetching spirits by dapper.");
            var spirits = spiritService.GetSpiritsByDapper();

            if (spirits.Any())
                return Ok(spirits);

            return new NoContentResult();
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("ef/spirits")]
        public IActionResult GetSpiritsByEf()
        {
            _logger.LogDebug("Fetching spirits by EF Core.");
            var spirits = spiritService.GetSpiritsByEf();

            if (spirits.Any())
                return Ok(spirits);

            return new NoContentResult();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
