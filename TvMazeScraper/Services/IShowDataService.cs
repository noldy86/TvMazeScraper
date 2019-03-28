using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvMazeScraper.Data.Models;
using TvMazeScraper.Models;

namespace TvMazeScraper.Services
{
    public interface IShowDataService
    {
        List<Show> GetShowAndCastData(int page, int pageSize);
    }
}
