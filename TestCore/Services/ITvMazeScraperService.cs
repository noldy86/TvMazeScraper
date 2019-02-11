using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestCore.Services
{
    public interface ITvMazeScraperService
    {
        bool ScrapeShowInformation();

        bool ScrapeCastInformation();
    }
}
