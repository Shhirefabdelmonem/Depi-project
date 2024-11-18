using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LisbrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        private readonly IBookRepo bookRepo;

        public HomeController(ILogger<HomeController> logger, Context context,IBookRepo bookRepo)
        {
            _logger = logger;
            _context = context;
            this.bookRepo = bookRepo;
        }


        public IActionResult AllBooks()
        {
            var bookList = bookRepo.GetAll();

            return View(bookList);
        }
        public IActionResult Details(int id)
        {
            var book = bookRepo.GetById(id);
            return View(book);
        }
        public IActionResult AllType(string type)
        {
            var booklist = bookRepo.Alltype(type);
            return View(booklist);
        }

        public IActionResult search(string inpt)
        {
            var matchingBooks = bookRepo.Search(inpt);

            return View(matchingBooks);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
