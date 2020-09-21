using System;
using System.Linq;
using MemorizingWords.MemorizingWords.BL.Interfaces;
using MemorizingWords.MemorizingWords.DAL;
using MemorizingWords.MemorizingWords.Domain.Models;
using Microsoft.Data.SqlClient;

namespace MemorizingWords.MemorizingWords.BL
{
    public class MemoLogic : IMemoLogic
    {
        private bool _state;
        private Random _random;
        private int _lowerLimit = 1;
        private int _upperLimit;

        public void Initialize()
        {
            _state = true;
            _random = new Random();
            _upperLimit = GetLastIdInDb() + 1;

            Console.WriteLine("Do you want to change range of words?\ny - yes, n - no\n");
            var key = Console.ReadKey();

            if (key.KeyChar == 'y')
            {
                Console.WriteLine($"\nEnter lower limit. No more than the upper limit {_upperLimit}");
                string lowerLimitString = Console.ReadLine();

                if (lowerLimitString == null)
                {
                    throw new ArgumentNullException();
                }

                _lowerLimit = int.Parse(lowerLimitString);
                
                if (_lowerLimit >= _upperLimit)
                {
                    _lowerLimit = 1;
                    Console.WriteLine("Lower limit exceeds the upper limit. Lower limit is set by default: 1");
                }
                
            }

            Console.WriteLine("\nEnter \"t\" for see translate, \"x\" to exit, any button for continue\n\n");
        }

        public bool CheckState()
        {
            return _state;
        }

        public void StopState()
        {
            _state = false;
        }

        public Word ConsoleOutput(MemorizingWordsDbContext dbContext)
        {
            int randomId = _random.Next(_lowerLimit, _upperLimit);
            var word = dbContext.Words.FirstOrDefault(word => word.Id == randomId);
            Console.WriteLine(word.Translate);
            return word;
        }

        public void ConsoleInput(Word word)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 't')
            {
                Console.WriteLine($"Translate - {word.OriginalWord}\n\n");
            }
            else if (key.KeyChar == 'x')
            {
                StopState();
            }
            else Console.WriteLine("\n");
        }

        public int GetLastIdInDb()
        {
            int lastId = 0;
            string query = "SELECT IDENT_CURRENT('Words') AS Count";
            string connectionString = @"Server=localhost;Database=WordsDB;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    lastId = (int) (decimal) reader[0];
                }

                reader.Close();
                connection.Close();
            }

            return lastId;
        }
    }
}