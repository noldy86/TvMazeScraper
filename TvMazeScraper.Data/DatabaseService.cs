namespace TvMazeScraper.Data
{
    public class DatabaseService : IDatabaseService
    {
        public MazeDbContext MazeDbContext{get;set;}

        public DatabaseService(MazeDbContext dbContext)
        {
            MazeDbContext = dbContext;
        }

        public MazeDbContext GetMazeDbContext()
        {
            return MazeDbContext;
        }
    }
}
