using BookManagement.Domain.Enitiy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.Features.Queries.SortBooks
{
    public class SortBookByPriceQuery : IRequest<List<Books>>
    {
    }
}
