using MemorizingWords.MemorizingWords.DAL;
using MemorizingWords.MemorizingWords.Domain.Models;

namespace MemorizingWords.MemorizingWords.BL.Interfaces
{
    
    public interface IMemoLogic
    {
        public void Initialize();
        public bool CheckState();
        public void StopState();
        public Word ConsoleOutput(MemorizingWordsDbContext dbContext);
        public void ConsoleInput(Word word);
        public int GetLastIdInDb();
    }
}