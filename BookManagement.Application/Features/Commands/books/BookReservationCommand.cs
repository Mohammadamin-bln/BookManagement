using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookManagement.Application.Features.Commands.books
{
    public class BookReservationCommand : IRequest<bool>
    {
        public int BookId { get; set; }
        public int Days { get; set; }
    }
}
