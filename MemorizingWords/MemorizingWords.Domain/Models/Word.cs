using System.ComponentModel.DataAnnotations;

namespace MemorizingWords.MemorizingWords.Domain.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OriginalWord { get; set; }
        [Required]
        public string Translate { get; set; }
    }
}