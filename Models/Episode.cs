namespace Anime_store.Models
{
    public class Episode
    {
        public int Id { get; set; }
        public int EpisodeNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}
