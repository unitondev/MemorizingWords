using System.ComponentModel.DataAnnotations;

namespace MemorizingWords.MemorizingWords.Domain.Models
{
    public class Word
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string OriginalWord { get; set; }
        [MaxLength(100)]
        public string Translate { get; set; }
    }
}