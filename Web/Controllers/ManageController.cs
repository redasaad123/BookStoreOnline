using Core.Entities;
using Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Method_Helper;
using Web.ViewModel;

namespace Web.Controllers
{
    public class ManageController : Controller
    {
        private readonly DbAppContext context;
        private readonly UserManager<AppUsers> userManager;
        private readonly Methods methods;
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting;



        public ManageController(DbAppContext context, UserManager<AppUsers> userManager, Methods methods, Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting)
        {
            this.context = context;
            this.userManager = userManager;
            this.methods = methods;
            this.hosting = hosting;
        }
        public IActionResult Add()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Add(AddBooksViewModel model)
        {
            string? author_Id = "";
            string? category_Id = "";
            var errors = ModelState.Values.SelectMany(r => r.Errors);
            if (!ModelState.IsValid)
                return View(model);

            if (!(await context.Author.AnyAsync(x => x.AuthorName == model.AuthorName)))
            {
                var author = new Authors
                {
                    AuthorId = Guid.NewGuid().ToString(),
                    AuthorName = model.AuthorName,
                };
                author_Id = author.AuthorId;
                await context.AddAsync(author);

            }
            else
            {
                author_Id = await context.Author.Where(x => x.AuthorName == model.AuthorName).Select(x => x.AuthorId).FirstOrDefaultAsync();
            }



            if (!(await context.category.AnyAsync(x => x.categoryName == model.CategoryName)))
            {
                var category = new Category
                {
                    categoryId = Guid.NewGuid().ToString(),
                    categoryName = model.CategoryName,

                };
                category_Id = category.categoryId;
                await context.AddAsync(category);

            }
            else
            {
                category_Id = await context.category.Where(x => x.categoryName == model.CategoryName).Select(x => x.categoryId).FirstOrDefaultAsync();
            }


            if (model.PhotoUrl != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, @"img.html");
                string fullPath = Path.Combine(uploads, model.PhotoUrl.FileName);
                model.PhotoUrl.CopyTo(new FileStream(fullPath, FileMode.Create));

            }

            if (model.PdfUrl != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, @"pdf books");
                string fullPath = Path.Combine(uploads, model.PdfUrl.FileName);
                model.PdfUrl.CopyTo(new FileStream(fullPath, FileMode.Create));

            }

            if (!(await context.Book.AnyAsync(x => x.NameBook == model.NameBook)))
            {
                var book = new Books
                {
                    Id = Guid.NewGuid().ToString(),
                    NameBook = model.NameBook,
                    NumberOfPage = model.NumberOfPage,
                    NumberSales = 0,
                    PhotoUrl = model.PhotoUrl.FileName,
                    PdfUrl = model.PdfUrl.FileName,
                    offer = model.offer,
                    Description = model.Description,
                    Date = DateTime.Now,
                    releaseYears = model.releaseYears,
                    AuthorId = author_Id,
                    CategoryId = category_Id,
                    Discount = model.offer ? model.Discount : 0,
                    Price = model.Price,
                };
                await context.AddAsync(book);

            }

            await context.SaveChangesAsync();

            return RedirectToAction("Add");



        }

        public async Task<IActionResult> BooksToUpdateOrDelete(string term)
        {

            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);
            if (term == null)
            {

                var book = await context.Book.Select(book => new ItemBook
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    PdfUrl = book.PdfUrl,
                    IsOffer = book.offer,
                    Discount = book.Discount,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),

                }).ToListAsync();

                return View(book);

            }
            else
            {
                var book = await context.Book.Where(x => x.NameBook.Contains(term)).Select(book => new ItemBook
                {
                    Id = book.Id,
                    NameBook = book.NameBook,
                    PhotoUrl = book.PhotoUrl,
                    Price = book.Price,
                    PdfUrl = book.PdfUrl,
                    IsOffer = book.offer,
                    Discount = book.Discount,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),

                }).ToListAsync();

                return View(book);
            }








        }
        public async Task<IActionResult> Update(string id)
        {
            var userId = userManager.GetUserId(HttpContext.User);

            var BookIdInBasket = await methods.BasketBookId(userId);
            var BookIdInBookmark = await methods.BookmarkBookId(userId);

            var BookName = await context.Book.AnyAsync(x => x.Id == id);

            if (!BookName)
                return NotFound("This Book Not Found !");


            var bookmodel = await context.Book.Where(x => x.Id == id)
                .Select(book => new UpdateBookViewModel
                {
                    IdBook = book.Id,
                    NameBook = book.NameBook,
                    NumberOfPage = book.NumberOfPage,
                    AuthorName = context.Author.Where(x => x.AuthorId == book.AuthorId).Select(x => x.AuthorName).FirstOrDefault(),
                    CategoryName = context.category.Where(x => x.categoryId == book.CategoryId).Select(x => x.categoryName).FirstOrDefault(),
                    Description = book.Description,
                    Discount = book.Discount,
                    Price = book.Price,
                    releaseYears = book.releaseYears,
                    NumberSales = book.NumberSales,
                    offer = book.offer,
                    IsClickedInBasket = BookIdInBasket.Contains(book.Id),
                    IsClickedInBookMark = BookIdInBookmark.Contains(book.Id),
                }).FirstOrDefaultAsync();


            return View(bookmodel);

        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateBookViewModel model)
        {
            var errors = ModelState.Values.SelectMany(r => r.Errors);
            if (!ModelState.IsValid)
                return View(model);

            var author = await context.Author.Where(x => x.AuthorName == model.AuthorName).FirstOrDefaultAsync();

            if (author == null)
            {
                author.AuthorName = model.AuthorName;
            }

            var category = await context.category.Where(x => x.categoryName == model.CategoryName).FirstOrDefaultAsync();

            if (category == null)
            {
                category.categoryName = model.CategoryName;
            }



            var book = await context.Book.Where(x => x.Id == model.IdBook).FirstOrDefaultAsync();

            var bookname = await context.Book.Where(x => x.NameBook == model.NameBook).FirstOrDefaultAsync();



            if (bookname != null && bookname.Id != model.IdBook)
            {
                ModelState.AddModelError("NameBook", " NameBook Is already exists ");
                return View(model);
            }

            book.NameBook = model.NameBook;
            book.NumberOfPage = model.NumberOfPage;
            book.releaseYears = model.releaseYears;
            book.NumberSales = model.NumberSales;
            book.offer = model.offer;
            book.Price = model.Price;
            book.Date = model.Date;
            book.Description = model.Description;
            book.Discount = model.Discount;

            if (model.PhotoUrl != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, @"img.html");
                string fullPath = Path.Combine(uploads, model.PhotoUrl.FileName);
                model.PhotoUrl.CopyTo(new FileStream(fullPath, FileMode.Create));
                book.PhotoUrl = model.PhotoUrl.FileName;


            }

            if (model.PdfUrl != null)
            {
                string uploads = Path.Combine(hosting.WebRootPath, @"pdf books");
                string fullPath = Path.Combine(uploads, model.PdfUrl.FileName);
                model.PdfUrl.CopyTo(new FileStream(fullPath, FileMode.Create));
                book.PdfUrl = model.PdfUrl.FileName;

            }

            context.Update(book);
            await context.SaveChangesAsync();
            return RedirectToAction("BooksToUpdateOrDelete");


        }




    }
}
