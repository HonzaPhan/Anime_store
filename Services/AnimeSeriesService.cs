using Anime_store.Data;
using Anime_store.Interfaces;
using Anime_store.Models;

namespace Anime_store.Services
{
    public class AnimeSeriesService : DbService<AnimeSeries>, IAnimeSeriesService
    {
        public AnimeSeriesService(ApplicationDbContext context) : base(context)
        {
        }
    }
}
