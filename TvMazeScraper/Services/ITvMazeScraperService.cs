using System.Threading.Tasks;

namespace TvMazeScraper.Services
{
    public interface ITvMazeScraperService
    {
        Task<bool> ScrapeShowInformation();
    }
}
