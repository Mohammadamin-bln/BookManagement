using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookManagement.Application.Features.Commands.books;
using BookManagement.Application.Services.Interfaces;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Repository.Implements;
using BookManagement.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using static BookManagement.Domain.Enum.Enums;

namespace BookManagement.Application.Services.Implements
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper, IUserRepository userRepository, IReservationRepository reservationRepository)
        {
            _bookRepository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        }

        public async Task<Books> AddBook(AddBookCommand request)

        {
            try
            {
                var model = _mapper.Map<Books>(request);
                var addedBook = await _bookRepository.AddBook(model);
                return addedBook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Books>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<bool> SaveResevation(string username, int bookId, int days)
        {
            var user = await _userRepository.GetUserByName(username);
            if (user == null)
                throw new Exception("User not found.");
            if (user.MemberShipType == MemberShipType.Normal && days > 7)

                throw new Exception("you can reserve for max 7 days");

            if (days > 14)

                throw new Exception("you can reserve only for max 14 days");

            int cost = 5;
            if (user.MemberShipType == MemberShipType.Normal)
            {
                int lastCost = days * cost;
                if (user.Wallet < lastCost)
                {
                    throw new Exception("charge your wallet");
                }
                user.Wallet -= lastCost;
                var book= await  _bookRepository.GetBookById(bookId);
                book.IsReserved = true;
                

            }


            var resevation = await _reservationRepository.ReserveBook(user.Id, bookId, days);


                return resevation != null;

        }
        public async Task<Books?> SearchBook(string bookName)
        {
            return await _bookRepository.GetBookByName(bookName);



            
        }



    }
}
