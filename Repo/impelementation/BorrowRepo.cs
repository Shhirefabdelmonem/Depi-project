using LisbrarySystem.Migrations;
using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace LisbrarySystem.Repo.impelementation
{
    public class BorrowRepo:IBorrowRepo
    {
        Context context;
        public BorrowRepo(Context _context)
        {
            context = _context;
        }

        public void Add(Borrow borrow)
        {
            context.Add(borrow);
        }

        public List<Borrow> Boroows()
        {
           return context.Borrows.Include(b=>b.Book).Include(b=>b.User).ToList();

        }

        public void Save()
        {
            context.SaveChanges();
        }

        public Borrow GetById(int id)
        {

            return context.Borrows.FirstOrDefault(b => b.Id == id);
        }

        public async void Task<SaveAsync>()
        {
            await context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var book = GetById(id);
            context.Remove(book);
        }
    }
}
