using Core.Entities;
using Cores.Interfaces;
using Infrastructure;
using Infrastructure.Migrations.DbApp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.ViewModel;
using Web.Method_Helper;
using static System.Reflection.Metadata.BlobBuilder;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Web.Controllers
{
    [Authorize("AccessRoleUser")]
    public class BasketBookController : Controller
    {
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;
        private readonly DbAppContext context;

        public BasketBookController(UserManager<AppUsers> user, Methods methods, DbAppContext context)
        {

            this.context = context;
            userManager = user;
            this.methods = methods;
        }
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookBasketId = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);

            var books = BookBasketId.Select(id => new BasketViewModel

            {
                Books = context.Book.Select(book => new bookBasketItem
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    Price = book.Price,
                    PdfUrl = book.PdfUrl,
                    PhotoUrl = book.PhotoUrl,
                    Date = book.Date,
                    Discount = book.Discount,
                    IsOffer = book.offer,
                    IsClickedInBasket = BookBasketId.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),

                }).Where(x => x.Id == id).FirstOrDefault()
            }).ToList();


            return View(books);
        }





    }
}

