using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Method_Helper;
using Web.ViewModel;

namespace Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;

        public SearchController(DbAppContext context , UserManager<AppUsers> userManager , Methods methods)
        {
            this.context = context;
            this.userManager = userManager;
            this.methods = methods;
        }

        public async Task< IActionResult> getbookfromsearch(string term)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId); 
            var supstring = term.Substring(0,4);
            ViewData["Title"] = term;

            var books = new SearchBookViewModel
            {
                searchBooks = await context.Book.Where(x => x.NameBook == term).Select(x => new MainBook
                {
                    NameBook = x.NameBook,
                    Id = x.Id,
                    Date = x.Date,
                    PdfUrl = x.PdfUrl,
                    PhotoUrl = x.PhotoUrl,
                    Price = x.Price,
                    IsClickedInBasket = BookIdInBasket.Contains(x.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(x.Id),

                }).ToListAsync(),

                suggestionBook = await context.Book.Where(x => x.NameBook.Contains(supstring)).Select(x => new MainBook
                {
                    NameBook = x.NameBook,
                    Id = x.Id,
                    Date = x.Date,
                    PdfUrl = x.PdfUrl,
                    PhotoUrl = x.PhotoUrl,
                    Price = x.Price,
                    IsClickedInBasket = BookIdInBasket.Contains(x.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(x.Id),

                }).ToListAsync(),
            };

            return View(books);
            
        }
    }
}
