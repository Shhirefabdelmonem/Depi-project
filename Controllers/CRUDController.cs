using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LisbrarySystem.Controllers
{
    [Authorize(Roles = "AdminsRole")]
    public class CRUDController : Controller
    {
        private readonly Context _context;
        private readonly IBookRepo bookRepo;
        private readonly IBorrowRepo borrowRepo;
        private readonly IBuyRepo buyRepo;

        public CRUDController(Context context,IBookRepo bookRepo,IBorrowRepo borrowRepo,IBuyRepo buyRepo)
        {

            _context = context;
            this.bookRepo = bookRepo;
            this.borrowRepo = borrowRepo;
            this.buyRepo = buyRepo;
        }
        public IActionResult Delete(int id)
        {
            bookRepo.Delete(id);
            bookRepo.Save();
            return RedirectToAction("AllBooks", "Home");
        }


        public IActionResult Update(int id)
        {
            var book = bookRepo.GetById(id);
            return View(book);
        }
        [HttpPost]
        public IActionResult Update(Book model)
        {

            bookRepo.Update(model);
            bookRepo.Save();
            return RedirectToAction("AllBooks", "Home");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Book model)
        {
            bookRepo.Update(model);
            bookRepo.Save();
            return RedirectToAction("AllBooks", "Home");
        }
        public IActionResult AdminBorrowedBooks()
        {
            var borrowedBooks = borrowRepo.Boroows();

            return View(borrowedBooks);
        }


        public IActionResult AdminBoughtBooks()
        {
            var boughtBooks = buyRepo.Buys();

            return View(boughtBooks);
        }

    }
}
