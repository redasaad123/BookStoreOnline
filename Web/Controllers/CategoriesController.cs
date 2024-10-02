using Core.Entities;
using Humanizer;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Method_Helper;
using Web.ViewModel;

namespace Web.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;

        public CategoriesController(DbAppContext context , UserManager<AppUsers> userManager , Methods methods )
        {
            this.context = context;
            this.userManager = userManager;
            this.methods = methods;
        }

        public async Task<IActionResult> GetBookInHistorical()
        {

            return View(await GetBookInCategory("Historical"));
        }

        public async Task<IActionResult> GetBookInFantasy()
        {

            return View(await GetBookInCategory("Fantasy"));
        }

        public async Task<IActionResult> GetBookInScience()
        {

            return View(await GetBookInCategory("Science"));
        }
        public async Task<IActionResult> GetBookInWar()
        {

            return View(await GetBookInCategory("War"));
        }









        public  async Task< CategoryViwModel> GetBookInCategory(string cat)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);

            var books = context.category.Where(x => x.categoryName.Contains(cat)).Select(cat => new CategoryViwModel
            {
                CategoryId = cat.categoryId,
                CategoryName = cat.categoryName,
                BookInCategories = context.Book.Where(x => x.CategoryId == cat.categoryId).Select(book => new BookInCategoryViewModel
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    categoryId = book.CategoryId,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    Discount = book.Discount,
                    IsOffer = book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),



                }).ToList()
            }).FirstOrDefault();


            return books;
        }
    }
}
