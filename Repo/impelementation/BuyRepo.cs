using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using Microsoft.EntityFrameworkCore;

namespace LisbrarySystem.Repo.impelementation
{
    public class BuyRepo : IBuyRepo
    {
        Context context;
        public BuyRepo(Context _context)
        {
            context = _context;
        }
        public void Add(Buy  buy)
        {
           context.Add(buy);
        }

        public List<Buy> Buys()
        {
            return context.Buys.Include(b => b.Book).Include(b => b.User).ToList();
        }

        public void Save()
        {
           context.SaveChanges();
        }

        public async void Task<SaveAsync>()
        {
           await context.SaveChangesAsync();
        }
    }
}
