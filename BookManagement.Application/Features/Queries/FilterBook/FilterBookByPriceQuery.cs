using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;
using MediatR;

namespace BookManagement.Application.Features.Queries.FilterBook
{
    public class FilterBookByPriceQuery : IRequest<List<Books>>
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
