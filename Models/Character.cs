namespace Anime_store.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<AnimeSeries> AnimeSeries { get; set; } = new List<AnimeSeries>();
    }
}
