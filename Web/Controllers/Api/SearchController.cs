using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly DbAppContext context;

        public SearchController(DbAppContext context)
        {
            this.context = context;
        }



        [HttpGet("search")]

        public async Task<IActionResult> search()
        {
            var term  = HttpContext.Request.Query["term"].ToString();

            var  bookName = await context.Book.Where(x=>x.NameBook.Contains(term)).Select(x=>x.NameBook).ToListAsync();


            return Ok(bookName);


        }
    }
}
