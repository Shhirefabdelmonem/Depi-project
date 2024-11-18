using LisbrarySystem.Models;

namespace LisbrarySystem.Repo.interfaces
{
    public interface IBuyRepo
    {
        public List<Buy> Buys();
        public void Add(Buy buy);
        public void Save();
        public void Task<SaveAsync>();
    }
}
