using System;
using System.Linq;
using MemorizingWords.MemorizingWords.DAL;
using MemorizingWords.MemorizingWords.Domain.Models;
using Microsoft.Data.SqlClient;

namespace MemorizingWords
{
    class Program
    {
        static void Main(string[] args)
        {
            bool state = true;
            var context = new MemorizingWordsDbContext();
            Random random = new Random();
            Console.WriteLine("Enter \"t\" for see translate, \"x\" to exit, any button for continue\n\n");

            while (state)
            {
                int randomId = random.Next(1, GetLastId() + 1);
                var word = context.Words.FirstOrDefault(word => word.Id == randomId);
                Console.WriteLine(word.Translate);
                
                CheckPressedButton(ref state, word);
            }
        }

        static void CheckPressedButton(ref bool state, Word word)
        {
            var key = Console.ReadKey(true);
            if (key.KeyChar == 't')
            {
                Console.WriteLine($"Translate - {word.OriginalWord}\n\n");
            }
            else if (key.KeyChar == 'x')
            {
                state = false;
            }
            else Console.WriteLine("\n");
        }
        static int GetLastId()
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