using LisbrarySystem.Models;
using LisbrarySystem.Repo.interfaces;
using LisbrarySystem.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LisbrarySystem.Controllers
{
   // [Authorize(Roles ="AdminsRole, UserRole")]
    public class PurrchaseController : Controller
    {
        private readonly Context _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBookRepo bookrepo;
        private readonly IBuyRepo buyRepo;
        private readonly IBorrowRepo borrowRepo;

        public PurrchaseController(Context context, UserManager<ApplicationUser> userManager,IBookRepo bookrepo,IBuyRepo buyRepo,IBorrowRepo borrowRepo)
        {
            _context = context;
            _userManager = userManager;
            this.bookrepo = bookrepo;
            this.buyRepo = buyRepo;
            this.borrowRepo = borrowRepo;
        }

        public async Task<IActionResult> Buy(int id)
        {
            var book = await bookrepo.Findasync(id);
            if (book == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Get the current user's ID

            var viewModel = new BuyConfirmationViewModel
            {
                UserId = userId,
                BookId = book.id,
                BookTitle = book.name,
                bookPrice = book.price
            };

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> buy(BuyConfirmationViewModel model)
        {


            var buy = new Buy
            {
                UserId = model.UserId,
                BookId = model.BookId
            };

            buyRepo.Add(buy);
            await _context.SaveChangesAsync();

            // Optionally, redirect to a success page or back to the book details
            return RedirectToAction("AllBooks", "Home"); // Adjust as necessary

        }
        public async Task<IActionResult> Borrow(int id)
        {
            var book = await bookrepo.Findasync(id);
            if (book == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var viewModel = new BorrowViewModel
            {
                UserId = userId,
                BookId = book.id,
                BookTitle = book.name,
                borrowdate = DateTime.Now.AddDays(10),
            };

            return View(viewModel); // Create a new Borrow view
        }
        [HttpPost]
        public async Task<IActionResult> Borrow(BorrowViewModel model)
        {

            var borrow = new Borrow
            {
                UserId = model.UserId,
                BookId = model.BookId,
                BorrowDate = DateTime.Now // Set the borrow date
            };

            borrowRepo.Add(borrow);
            await _context.SaveChangesAsync();

            return RedirectToAction("AllBooks", "Home"); // Adjust as needed


        }
        public IActionResult MyBorrowedBooks()
        {
            var userId = _userManager.GetUserId(User);
            var borrowedBooks = borrowRepo.Boroows();

            return View(borrowedBooks);
        }

        //[Authorize(Roles = "UserRole")]
        public IActionResult MyBoughtBooks()
        {
            var userId = _userManager.GetUserId(User);
            var boughtBooks = buyRepo.Buys();
            return View(boughtBooks);
        }
        public IActionResult returnBook(int id)
        {
           borrowRepo.Delete(id);
            borrowRepo.Save();
            return RedirectToAction("MyBorrowedBooks", "Purrchase");


        }

    }
}
