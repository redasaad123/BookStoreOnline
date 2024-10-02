using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class ItemBook : MainBook
    {

        


        
 
        
        public string? AuthorName { get; set; }

        public string AuthorId { get; set; }

        public string? CategoryName { get; set; }
        public string CategoryId { get; set; }

        public List<MainBook> Books { get; set; }

    }
}
