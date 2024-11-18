using LisbrarySystem.Models;

namespace LisbrarySystem.Repo.interfaces
{
    public interface IBookRepo
    {
        public void Add(Book book);
        public void Update(Book book);
        public void Delete(int id);
        public List<Book> GetAll();
        public Book GetById(int id);
        public List<Book> Alltype(string type);
        public List<Book> Search(string search);
        public Task<Book> Findasync(int id);
        public void Save();

    }
}
