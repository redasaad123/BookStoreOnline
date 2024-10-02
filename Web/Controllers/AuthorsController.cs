using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModel;
using Web.Method_Helper;

namespace Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;

        public AuthorsController(DbAppContext context , UserManager<AppUsers> userManager , Methods methods)
        {
            this.context = context;
            this.userManager = userManager;
            this.methods = methods;
        }
        public async Task< IActionResult> Index()
        {
            var Author = await context.Author.Select(Auth => new AuthorsViewModel
            {
                AuthorName = Auth.AuthorName,
                AuthorId = Auth.AuthorId,

            }).ToListAsync();


            return View(Author);
            
        }


        public async Task<IActionResult> GetBooksToAuthor(string id)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);



            var bookView =  new BookWithAuthorViewModel
            {
                AuthorsView = context.Author.Where(x => x.AuthorId == id).Select(context => new AuthorsViewModel
                {
                    AuthorId = context.AuthorId,
                    AuthorName = context.AuthorName,
                }).FirstOrDefault(),

                Books =await context.Book.Where(x => x.AuthorId == id).Select(  book => new MainBook
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PdfUrl = book.PdfUrl,
                    Date = book.Date,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Discount = book.Discount,
                    IsOffer = book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),

                    
                }).ToListAsync()

            };


            return View(bookView);







           


        }
    }
}
