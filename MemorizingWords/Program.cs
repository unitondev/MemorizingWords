using System;
using System.Linq;
using MemorizingWords.MemorizingWords.DAL;

namespace MemorizingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            bool state = true;
            var context = new MemorizingWordsDbContext();
            Random random = new Random();
            
            while (state)
            {
                int randomNumber = random.Next(1, 98);
                var word = context.Words.FirstOrDefault(word1 => word1.Id == randomNumber)?.Translate;
                
                Console.WriteLine(word);
                Console.ReadKey();
                Console.WriteLine();
            }
            
            
            
            
        }
    }
}