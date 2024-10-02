using Core.Entities;
using Cores.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;
using Web.Method_Helper;
using Web.Models;
using Web.ViewModel;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<AppUsers> UserManager;
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork<Authors> author;
        private readonly IUnitOfWork<Books> book;
        private readonly IUnitOfWork<Category> category;
        private readonly IUnitOfWork<MessageUsers> MessageUsers;
        private readonly DbAppContext context;

        public HomeController(UserManager<AppUsers> user,UserManager <AppUsers> userManager , Methods methods, ILogger<HomeController> logger, IUnitOfWork<Authors> Author, IUnitOfWork<Books> Book, IUnitOfWork<Category> Category, DbAppContext context)
        {
            author = Author;
            book = Book;
            category = Category;
            this.context = context;
            UserManager = user;
            this.userManager = userManager;
            this.methods = methods;
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);



            var books = new MultipleModelView
            {
                mainBookWithDates = book.Entity.GetAll().Select(book => new MainBookWithDate
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PdfUrl = book.PdfUrl,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Date = book.Date,
                    Discount = book.Discount,
                    IsOffer= book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),



                }).OrderByDescending(b => b.Date).Take(10),
                Books = book.Entity.GetAll().Select(book => new MainBook
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PdfUrl = book.PdfUrl,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Date = book.Date,
                    Discount = book.Discount,
                    IsOffer = book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),

                }),
                MainBookWithOffer = book.Entity.GetAll().Select(book => new MainBookWithOffer
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PdfUrl = book.PdfUrl,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Date = book.Date,
                    IsOffer = book.offer,
                    Discount = book.Discount,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),


                }).Where(o => o.IsOffer == true),

            };

            return View(books);

        }



        public async Task<  IActionResult> Details(string Id)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);

            var books = context.Book.Where(x=>x.Id==Id).Select( book => new ItemBook
            {
                Id = book.Id,
                NameBook = book.NameBook,
                PdfUrl = book.PdfUrl,
                PhotoUrl = book.PhotoUrl,
                Price = book.Price,
                AuthorId = book.AuthorId,
                CategoryId = book.CategoryId,
                Description = book.Description,
                NumberOfPage   = book.NumberOfPage,
                releaseYears = book.releaseYears,
                IsOffer = book.offer,
                Discount = book.Discount ,
                IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),
                AuthorName = context.Author.Where(x=>x.AuthorId==book.AuthorId).Select(x=>x.AuthorName).FirstOrDefault(),
                CategoryName = context.category.Where(x => x.categoryId == book.CategoryId).Select(x => x.categoryName).FirstOrDefault(),
                Books = context.Book.Select(book => new MainBook
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PdfUrl = book.PdfUrl,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Date = book.Date,
                    Discount = book.Discount,
                    IsOffer = book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),


                }).ToList()

            }).FirstOrDefault();

            return View(books);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> contact(MessageViewModel model)
        {
            

            var errors = ModelState.Values.SelectMany(r => r.Errors);
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            var message = new MessageUsers
            {
                MessageId = Guid.NewGuid().ToString(),
                name = model.name,
                email = model.email,
                subject = model.subject,
                message = model.message,

            };

            await  context.AddAsync(message);

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
