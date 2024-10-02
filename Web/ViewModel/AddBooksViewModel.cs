using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class AddBooksViewModel : MainBook
    {
        public string AuthorName { get; set; }
        public int NumberSales { get; set; }

        public string CategoryName { get; set; }

        [Required]
        public IFormFile PhotoUrl { get; set; }
        public IFormFile PdfUrl { get; set; }
        public bool offer { get; set; }


    }
}
