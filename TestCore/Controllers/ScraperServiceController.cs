using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCore.Services;

namespace TestCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperServiceController : ControllerBase
    {
        private ITvMazeScraperService TvMazeScraperService { get; set; }

        public ScraperServiceController(ITvMazeScraperService tvMazeScraperService)
        {
            this.TvMazeScraperService = tvMazeScraperService;
        }

        public IActionResult ShowInformation()
        {
            var success = TvMazeScraperService.ScrapeShowInformation();

            if (!success)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}