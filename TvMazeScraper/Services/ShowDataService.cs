using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TvMazeScraper.Data;
using TvMazeScraper.Data.Models;

namespace TvMazeScraper.Services
{
    public class ShowDataService : IShowDataService
    {
        private readonly IDatabaseService _databaseService;


        public ShowDataService(IDatabaseService databaseService)
        {
            this._databaseService = databaseService;
        }
        public List<Show> GetShowAndCastData(int page, int pageSize)
        {

            var skip = (page - 1) * pageSize;
            var result = _databaseService.GetMazeDbContext().Shows.Include(i => i.Casts).Skip(skip).Take(pageSize).ToList();

           //order by cast birthday
           foreach (var show in result)
           {
               show.Casts = show.Casts.OrderByDescending(o => o.Birthday).ToList();
           }
            
            return result;
        }
    }
}
