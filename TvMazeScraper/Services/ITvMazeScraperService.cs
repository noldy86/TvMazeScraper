using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Data.Models;

namespace TvMazeScraper.Services
{
    public interface ITvMazeScraperService
    {
        Task<bool> ScrapeShowInformation();
    }
}
