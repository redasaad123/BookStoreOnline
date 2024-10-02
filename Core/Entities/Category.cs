namespace Core.Entities
{
    public class Category
    {
        public string categoryId { get; set; }

        public string categoryName { get; set; }

        public virtual List<Books> Books  { get; set; }
    }
}
