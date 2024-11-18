using LisbrarySystem.Models;
using System.Security.Policy;

namespace LisbrarySystem.Repo.interfaces
{
    public interface IBorrowRepo
    {
        public List<Borrow> Boroows();
        public void Add(Borrow borrow);
        public void Save();
        public void Task <SaveAsync>();
        public Borrow GetById(int id);
        public void Delete(int id);

    }
}
