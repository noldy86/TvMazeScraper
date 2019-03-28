using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TvMazeScraper.Models;
using TvMazeScraper.Services;

namespace TvMazeScraper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        public IShowDataService ShowDataService { get; set; }
        public ShowController(IShowDataService showDataService)
        {
            this.ShowDataService = showDataService;
        }

        [HttpGet]
        public IActionResult ShowsWithCast(int page = 1, int pageSize = 50)
        {
            //check if page is 1 or bigger
            if (page < 1)
            {
                return BadRequest();
            }

            var showData = ShowDataService.GetShowAndCastData(page, pageSize);

            //convert EF type to ShowResponse type
            var result = new List<ShowResponse>();
            foreach (var show in showData)
            {
                result.Add(new ShowResponse(show));
            }

            return Ok(result);
        }
    }
}