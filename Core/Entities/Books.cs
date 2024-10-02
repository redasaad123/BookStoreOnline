using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Books
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public string Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string NameBook { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Required]
        [ForeignKey("Authors")]
        public string AuthorId { get; set; }
        public int NumberSales { get; set; }



        public virtual Authors Authors { get; set; }
        [Required]

        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }



        public DateTime? Date { get; set; }

        public string? Description { get; set; }
        [Required]
        public string? PhotoUrl { get; set; }
        public string? PdfUrl { get; set; }
        public string? NumberOfPage { get; set; }
        public string? releaseYears { get; set; }

        public bool offer { get; set; }

        public double? Discount { get; set; }




    }
}
