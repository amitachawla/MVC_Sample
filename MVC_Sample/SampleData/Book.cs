using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SampleData
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Book name must be filled in")]
        [Display(Description ="Book Name")]
        [StringLength(250)]
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public decimal Price { get; set; }
    }
}
