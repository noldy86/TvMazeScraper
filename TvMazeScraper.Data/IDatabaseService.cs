using System;
using System.Collections.Generic;
using System.Text;

namespace TvMazeScraper.Data
{
    public interface IDatabaseService
    {
        MazeDbContext GetMazeDbContext();
    }
}
