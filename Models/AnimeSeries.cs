namespace Anime_store.Models
{
    public class AnimeSeries
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int YearOfRelease { get; set; }
        public string Description { get; set; } = string.Empty;
        public List<Genre> Genres { get; set; } = new List<Genre>();
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Studio> Studio { get; set; } = new List<Studio>();
        public List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
