using System;
using System.Linq;
using MemorizingWords.MemorizingWords.BL;
using MemorizingWords.MemorizingWords.DAL;
using MemorizingWords.MemorizingWords.Domain.Models;
using Microsoft.Data.SqlClient;

namespace MemorizingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            MemoLogic repository = new MemoLogic();
            MemorizingWordsDbContext context = new MemorizingWordsDbContext();
            
            repository.Initialize();
            
            while (repository.CheckState())
            {
                Word word = repository.ConsoleOutput(context);
                
                repository.ConsoleInput(word);
            }
        }
    } 
}
