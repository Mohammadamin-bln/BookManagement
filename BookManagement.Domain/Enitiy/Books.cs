using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain.Enitiy
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }

        public bool IsReserved { get; set; } = false;

    }
}
