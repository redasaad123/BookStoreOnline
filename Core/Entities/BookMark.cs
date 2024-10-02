using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BookMark 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string BookMarkId { get; set; }

        public string? UserId { get; set; }
    }
}
