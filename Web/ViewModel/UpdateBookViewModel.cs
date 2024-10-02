namespace Web.ViewModel
{
    public class UpdateBookViewModel : MainBook
    {
        public string IdBook { get; set; }

        public string? AuthorName { get; set; }

        public string? CategoryName { get; set; }

        public IFormFile? PhotoUrl { get; set; }
        public IFormFile? PdfUrl { get; set; }
        public bool offer { get; set; }

    }
}
