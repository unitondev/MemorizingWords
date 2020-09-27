using System;
using MemorizingWords.MemorizingWords.BL;
using MemorizingWords.MemorizingWords.BL.Interfaces;
using MemorizingWords.MemorizingWords.DAL;
using MemorizingWords.MemorizingWords.Domain.Models;

namespace MemorizingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoLogic repository = new MemoLogic();
            IParserFromStringToDb parser = new ParserFromStringToDb();
            MemorizingWordsDbContext context = new MemorizingWordsDbContext();
            
            //parser.ParseFromStringToDb();
  
            repository.Initialize();
            
             while (repository.CheckState())
             {
                 Word word = repository.ConsoleOutput(context);
                 
                 repository.ConsoleInput(word);
             }
        }
    } 
}
