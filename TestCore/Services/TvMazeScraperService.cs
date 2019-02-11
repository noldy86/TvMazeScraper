using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestCore.Services
{
    public class TvMazeScraperService : ITvMazeScraperService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TvMazeScraperService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public bool ScrapeShowInformation()
        {
            return true;
        }

        public bool ScrapeCastInformation()
        {
            return true;
        }
    }
}
