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

    public class BasketController : ControllerBase
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly IUnitOfWork<BookBasket> bookBasket;

        public BasketController(DbAppContext context , UserManager<AppUsers> userManager , IUnitOfWork<BookBasket> BookBasket)
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

            var BasketId = context.basket.Where(x => x.UserId == user).Select(x => x.BasketId).FirstOrDefault();

            var chick = await context.BookBasket.AnyAsync(x=>x.BasketId == BasketId && x.BookId==book.Id);


            if (!chick)
            {
                var BookBasket = new BookBasket
                {
                    BookId = book.Id,
                    BasketId = BasketId
                };
                await context.AddAsync(BookBasket);

                bookBasket.Save();

            }

            return Ok();

        }


        [HttpDelete]
        public async Task<IActionResult> deleteBookfromBasket(string bookId)
        {
            var book = await context.Book.FindAsync(bookId);

            var user = userManager.GetUserId(HttpContext.User);


            var BasketId = context.basket.Where(x => x.UserId == user).Select(x => x.BasketId).FirstOrDefault();

            var bookremoveId = context.BookBasket.Where(x => x.BasketId == BasketId && x.BookId == book.Id).Select(x=>x.Id).FirstOrDefault();

            var bookremove = await context.BookBasket.FindAsync(bookremoveId);

            context.BookBasket.Remove(bookremove);

            await context.SaveChangesAsync();

            return Ok();

        }

    }
}
