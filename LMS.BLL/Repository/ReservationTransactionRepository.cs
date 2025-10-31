using LMS.DAL.Database;
using LMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Repository
{
    public class ReservationTransactionRepository : GenericRepository<ReservationTransaction>, IReservationTransactionRepository
    {
        ApplicationContext _db = new ApplicationContext();
        public async Task<bool> CancelReservation(int reservationId)
        {
            var reservation = await _db.ReservationTransactions.FindAsync(reservationId);
            if (reservation == null) 
                return false;
            reservation.IsActive = false;
            return true;
        }

        public async Task<List<ReservationTransaction>> GetReservationTransactionByBook(int bookId)
        {
            var reservation = await _db.ReservationTransactions.Where(r => r.BookId == bookId).ToListAsync();
            return reservation;
        }

        public async Task<List<ReservationTransaction>> GetReservationTransactionByMember(int memberId)
        {
            var reservation = await _db.ReservationTransactions.Where(r => r.MemberId == memberId).ToListAsync();
            return reservation;
        }
    }
    public interface IReservationTransactionRepository
    {
        Task<bool> CancelReservation(int reservationId);
        Task<List<ReservationTransaction>> GetReservationTransactionByMember(int memberId);
        Task<List<ReservationTransaction>> GetReservationTransactionByBook(int bookId);
    }
}
