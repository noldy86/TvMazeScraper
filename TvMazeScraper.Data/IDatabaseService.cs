namespace TvMazeScraper.Data
{
    public interface IDatabaseService
    {
        MazeDbContext GetMazeDbContext();
    }
}
