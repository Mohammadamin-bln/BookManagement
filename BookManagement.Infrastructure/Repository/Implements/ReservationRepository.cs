using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookManagement.Domain.Enitiy;
using BookManagement.Infrastructure.Context;
using BookManagement.Infrastructure.Repository.Interfaces;

namespace BookManagement.Infrastructure.Repository.Implements
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Reservation> ReserveBook(int userId, int bookId, int days )
        {
            var reservation = new Reservation
            {
                BookId = bookId,
                UserId = userId,
                ReservedUntill = DateTime.UtcNow.AddDays( days )
            };

            _context.Reservation.Add( reservation );
            await _context.SaveChangesAsync();
            return reservation;

        }
    }
}
