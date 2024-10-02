using Core.Entities;
using Cores.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("AccessRoleUser")]
    public class BookMarkController : ControllerBase
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly IUnitOfWork<BookBasket> bookBasket;

        public BookMarkController(DbAppContext context, UserManager<AppUsers> userManager, IUnitOfWork<BookBasket> BookBasket)
        {
            this.context = context;
            this.userManager = userManager;
            this.bookBasket = BookBasket;
        }


        [HttpPost]
        public async Task<IActionResult> AddBookToBasket(string bookId)
        {
            var book = await context.Book.FindAsync(bookId);

            if (book == null)
                return NotFound();

            var user = userManager.GetUserId(HttpContext.User);

            var BookMarkId = context.bookMark.Where(x => x.UserId == user).Select(x => x.BookMarkId).FirstOrDefault();

            var chick = await context.bookMarkBook.AnyAsync(x => x.BookMarkId == BookMarkId && x.BookId == book.Id);


            if (!chick)
            {
                var BookMark = new bookMarkBook
                {
                    BookId = book.Id,
                    BookMarkId = BookMarkId
                };
                await context.AddAsync(BookMark);

                bookBasket.Save();

            }

            return Ok();

        }
        [HttpDelete]
        public async Task<IActionResult> deleteBookfromBasket(string bookId)
        {
            var book = await context.Book.FindAsync(bookId);

            var user = userManager.GetUserId(HttpContext.User);


            var BasketId = context.bookMark.Where(x => x.UserId == user).Select(x => x.BookMarkId).FirstOrDefault();

            var bookremoveId = context.bookMarkBook.Where(x => x.BookMarkId == BasketId && x.BookId == book.Id).Select(x => x.Id).FirstOrDefault();

            var bookremove = await context.bookMarkBook.FindAsync(bookremoveId);

            context.bookMarkBook.Remove(bookremove);

            await context.SaveChangesAsync();

            return Ok();

        }
    }
}
