using System;
using System.Linq;
using MemorizingWords.MemorizingWords.DAL;

namespace MemorizingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MemorizingWordsDbContext();
                
            var word = context.Words.FirstOrDefault(word1 => word1.Id == 1)?.OriginalWord;
                Console.WriteLine(word);
            
        }
    }
}