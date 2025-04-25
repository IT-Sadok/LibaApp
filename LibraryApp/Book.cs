using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    public class Book
    {
        public string Title { get; set; } //test2
        public string Author { get; set; }
        public int Year { get; set; }
        public string Code { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
