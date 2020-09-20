using MemorizingWords.MemorizingWords.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace MemorizingWords.MemorizingWords.DAL
{
    public class MemorizingWordsDbContext : DbContext
        {
            public DbSet<Word> Words { get; set; }
        
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost;Database=WordsDB;Trusted_Connection=True;");
            }
        }
}