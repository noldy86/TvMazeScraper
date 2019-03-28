using Microsoft.AspNetCore.Mvc;
using TvMazeScraper.Services;

namespace TvMazeScraper.Controllers
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

        [HttpGet]
        public IActionResult Scrape()
        {
            var success = TvMazeScraperService.ScrapeShowInformation();

            if (!success.Result)
            {
                return BadRequest();
            }
            return Ok();
        }

    }
}