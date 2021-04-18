using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MemorizingWords.MemorizingWords.BL.Interfaces;
using MemorizingWords.MemorizingWords.Domain.Models;
using Microsoft.Data.SqlClient;

namespace MemorizingWords.MemorizingWords.BL
{
    public class ParserFromFileToDbContent : IParserFromFileToDbContent
    {
        private List<WordFromFile> _arrayOfPairsFromFile;

        public ParserFromFileToDbContent()
        {
            _arrayOfPairsFromFile = new List<WordFromFile>();
        }
        
        public void ParseFromFileToDbContent()
        {
            //TODO add return List<T>, dont initialize _arrayFrom..., just return from this method  
            RecordWordsFromFileToList();

            for (int i = 0; i < _arrayOfPairsFromFile.Count; i++)
            {
                CreateSqlQueryString(_arrayOfPairsFromFile[i]);   
            }
        }

        private void CreateSqlQueryString(WordFromFile wordFromFile)
        {
            string query = $"INSERT INTO Words VALUES('{wordFromFile.OriginalWord}', '{wordFromFile.Translate}')";
            string connectionString = @"Server=localhost;Database=WordsDB;Trusted_Connection=True";
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                reader.Close();
                connection.Close();
            }
        }
        
        private string[] SplitString(string source)
        {
            //TODO add regular expression
            string[] splittedStrings = source.Split(new char[]{'-', '–'}, 
                2, StringSplitOptions.RemoveEmptyEntries);
            return splittedStrings;
        }
        
        private void AddPairFromSpliitedLineToList(string[] splittedLine)
        {
            var PairFromFile = new WordFromFile()
            {
                OriginalWord = splittedLine[0],
                Translate = splittedLine[1]
            };
            _arrayOfPairsFromFile.Add(PairFromFile);
        }
        
        private void RecordWordsFromFileToList()
        {
            string path = @"C:\Users\uniton\Desktop\words.txt";

            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string lineFromFile;
                    while ((lineFromFile = streamReader.ReadLine()) != null)
                    {
                        string[] splittedLine = SplitString(lineFromFile);
                        
                        AddPairFromSpliitedLineToList(splittedLine);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}