using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Constants;
using TvMazeScraper.Data;
using TvMazeScraper.Data.Models;
using TvMazeScraper.Constants;

namespace TvMazeScraper.Services
{
    public class TvMazeScraperService : ITvMazeScraperService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IDatabaseService _databaseService;

        public TvMazeScraperService(IHttpClientFactory httpClientFactory, IDatabaseService databaseService)
        {
            _httpClientFactory = httpClientFactory;
            _databaseService = databaseService;
        }

        public async Task<bool> ScrapeShowInformation()
        {
            //?page=0
            var client = _httpClientFactory.CreateClient(TvMazeConstants.TvMazeShowsApiEndpoint);

            int index = GetPageIndex();

            while (index >= 0)
            {
                var response = await client.GetAsync($"?page={index}");
                index++;

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    index = -1;
                } else
                {
                    string content = await response.Content.ReadAsStringAsync();
                    List<Show> shows = JsonConvert.DeserializeObject<List<Show>>(content); 

                    //add cast info and store
                    foreach(var show in shows)
                    {
                        var cast = await ScrapeCastInformation(show.ShowId);
                        show.Casts = cast;
                        _databaseService.GetMazeDbContext().Shows.Add(show);
                    }

                    //safe per page
                    Console.WriteLine("Save changes on index {0}", index);
                    _databaseService.GetMazeDbContext().SaveChanges();
                    
                }
            }
          
            return true;
        }

        public async Task<List<Cast>> ScrapeCastInformation(int showId)
        {
            var result = new List<Cast>();

            //http://api.tvmaze.com/shows/1/cast
            var castClient = _httpClientFactory.CreateClient(TvMazeConstants.TvMazeCastApiEndpoint);
            var castResponse = await castClient.GetAsync($"shows/{showId}/cast");

            if (castResponse.IsSuccessStatusCode)
            {
                string content = await castResponse.Content.ReadAsStringAsync();

                var contentJObjects = JArray.Parse(content);

                var persons = contentJObjects.Children()["person"];

                List<Cast> cast = new List<Cast>();

                foreach (var person in persons)
                {
                    var castMember = new Cast();
                    castMember.CastId = person.Value<int>("id");
                    castMember.Name = person.Value<string>("name");

                    if (DateTime.TryParse(person.Value<string>("birthday"), out var birthDay))
                    {
                        castMember.Birthday = birthDay;
                    }

                    cast.Add(castMember);
                }

                result.AddRange(cast);
            }

            return result;
        }
        /// <summary>
        /// Due to failing scraper attempts I want to pickup where we left off.
        /// https://www.tvmaze.com/api#show-index
        /// </summary>
        /// <returns></returns>
        public int GetPageIndex()
        {
            var maxShowId = _databaseService.GetMazeDbContext().Shows.DefaultIfEmpty().Max(m => m.ShowId);
            return maxShowId / 250;
        }
    }
}
