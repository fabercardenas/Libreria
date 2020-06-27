using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Libreria.Models
{
    [Table("Book")]
    public partial class Book
    {
        [Key]
        public int BookID { get; set; }
        //[ForeignKey("Id_Author")]
        public int AuthorID { get; set; }
        public Author Author { get; set; }
                
        public string Title { get; set; }
        public string Description { get; set; }
        public string Section { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }

        //defininendo caodisd
        
    }
}
