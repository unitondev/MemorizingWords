﻿using System;
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
            IMemoLogic repository = new MemoLogic();
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
