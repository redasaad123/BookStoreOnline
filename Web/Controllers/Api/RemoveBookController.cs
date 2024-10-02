using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RemoveBookController : ControllerBase
    {
        private readonly DbAppContext context;

        public RemoveBookController(DbAppContext context)
        {
            this.context = context;
        }

        [HttpDelete]
        public async Task< ActionResult> Delete(string id)
        {
            var book = context.Book.Where(x=> x.Id == id).FirstOrDefault();
            if (book == null)
                return NotFound();

            context.Remove(book);
            await context.SaveChangesAsync();
            return Ok();

            

        }
    }
}
