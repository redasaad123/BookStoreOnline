namespace Web.ViewModel
{
    public class BookWithAuthorViewModel 
    {
        public AuthorsViewModel? AuthorsView { get; set; }
        public List<MainBook> Books { get; set; }

    }
}
