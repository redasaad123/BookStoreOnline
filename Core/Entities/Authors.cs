using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Authors
    {
        [Required]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AuthorId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 3)]
        [Display(Name = "First Name")]
        public string AuthorName { get; set; }

        [Required]

        public virtual List<Books> Books { get; set; }


    }
}
