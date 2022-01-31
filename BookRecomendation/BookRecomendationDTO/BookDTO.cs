using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRecomendationDTO
{
    public class BookDTO
    {
        public int book_isbn { get; set; }
        public int rating { get; set;}
        public string review { get; set; }   
    }
}
