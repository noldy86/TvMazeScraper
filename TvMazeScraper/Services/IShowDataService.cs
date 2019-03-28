using System.Collections.Generic;
using TvMazeScraper.Data.Models;

namespace TvMazeScraper.Services
{
    public interface IShowDataService
    {
        List<Show> GetShowAndCastData(int page, int pageSize);
    }
}
