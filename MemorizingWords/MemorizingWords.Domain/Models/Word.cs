namespace MemorizingWords.MemorizingWords.Domain.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string OriginalWord { get; set; }
        public string Translate { get; set; }
    }
}