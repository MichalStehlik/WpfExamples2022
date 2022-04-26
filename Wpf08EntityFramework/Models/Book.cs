using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf08EntityFramework.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; } = "";
        public int Pages { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
