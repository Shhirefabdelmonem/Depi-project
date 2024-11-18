using LisbrarySystem.Migrations;
using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace LisbrarySystem.Repo.impelementation
{
    public class BookRepo : IBookRepo
    {
        Context context;
        public BookRepo(Context _context)
        {
            context = _context;
        }
        public void Add(Book book)
        {
            context.Add(book);
        }

        public List<Book> Alltype(string type)
        {
          return context.Books.Where(b => b.gener == type).ToList();
        }

        public void Delete(int id)
        {
            var book =GetById(id);
            context.Remove(book);
        }

        public async Task<Book> Findasync(int id)
        {
           return await context.Books.FindAsync(id);
        }

        public List<Book> GetAll()
        {
            return context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return context.Books.FirstOrDefault(b => b.id == id);
        }

        public void Save()
        {
           context.SaveChanges();
        }

        public List<Book> Search(string search)
        {
            return context.Books.Where(p => p.name.Contains(search)).ToList();
        }

        public void Update(Book book)
        {
            context.Update(book);
        }
    }
}
