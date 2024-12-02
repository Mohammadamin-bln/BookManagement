using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Commands
{
    public class AddBookCommand : IRequest<string>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int Price { get; set; }
    }
}
