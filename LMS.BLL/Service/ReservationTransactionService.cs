using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Service
{
    public class ReservationTransactionService : IReservationTransactionService
    {
        ReservationTransactionRepository _reservationRepo = new ReservationTransactionRepository();
        public async Task<List<ReservationTransactionDTO>> GetAllReservationTransactions()
        {
            var reservations = await _reservationRepo.GetAll(r => r.IsActive);
            var reservationsDTO = new List<ReservationTransactionDTO>();
            if (reservations == null)
                return reservationsDTO;
            foreach (var reservation in reservations)
            {
                var reservationDTO = new ReservationTransactionDTO()
                {
                    CreatedOn = DateTime.Now,
                    Book = reservation.Book,
                    ExpirationDate = reservation.ExpirationDate,
                    Id = reservation.Id,
                    IsActive = reservation.IsActive,
                    Member = reservation.Member,
                    MemberId = reservation.MemberId,
                    ReservationDate = reservation.ReservationDate
                };
                reservationsDTO.Add(reservationDTO);
            }
;
            return reservationsDTO;
        }

        public async Task<ReservationTransactionDTO> GetReservationTransactionById(int memberId)
        {
            var reservation = await _reservationRepo.GetBy(r => r.MemberId == memberId);
            var reservationDTO = new ReservationTransactionDTO()
            {
                CreatedOn = DateTime.Now,
                Book = reservation.Book,
                ExpirationDate = reservation.ExpirationDate,
                Id = reservation.Id,
                IsActive = reservation.IsActive,
                Member = reservation.Member,
                MemberId = reservation.MemberId,
                ReservationDate = reservation.ReservationDate
            }; ;
            return reservationDTO;
        }
        
        public async Task CreateReservationTransaction(ReservationTransactionDTO reservationTransactionDTO)
        {
            var reservation = new ReservationTransaction()
            {
                Id = reservationTransactionDTO.Id,
                MemberId= reservationTransactionDTO.MemberId,
                Book = reservationTransactionDTO.Book,
                BookId = reservationTransactionDTO.BookId,
                CreatedOn= DateTime.Now,
                ExpirationDate= reservationTransactionDTO.ExpirationDate,
                IsActive= reservationTransactionDTO.IsActive,
                Member = reservationTransactionDTO.Member,
                ReservationDate = reservationTransactionDTO.ReservationDate
            };
            await _reservationRepo.CreateAsync(reservation);
        }
        public async Task UpdateReservationTransaction(ReservationTransactionDTO reservationTransactionDTO)
        {
            var reservation = new ReservationTransaction()
            {
                Id = reservationTransactionDTO.Id,
                MemberId = reservationTransactionDTO.MemberId,
                Book = reservationTransactionDTO.Book,
                BookId = reservationTransactionDTO.BookId,
                CreatedOn = DateTime.Now,
                ExpirationDate = reservationTransactionDTO.ExpirationDate,
                IsActive = reservationTransactionDTO.IsActive,
                Member = reservationTransactionDTO.Member,
                ReservationDate = reservationTransactionDTO.ReservationDate
            };
            await _reservationRepo.UpdateAsync(reservation);
        }
        public async Task DeleteReservationTransaction(ReservationTransactionDTO reservationTransactionDTO)
        {
            var reservation = new ReservationTransaction()
            {
                Id = reservationTransactionDTO.Id,
                MemberId = reservationTransactionDTO.MemberId,
                Book = reservationTransactionDTO.Book,
                BookId = reservationTransactionDTO.BookId,
                CreatedOn = DateTime.Now,
                ExpirationDate = reservationTransactionDTO.ExpirationDate,
                IsActive = reservationTransactionDTO.IsActive,
                Member = reservationTransactionDTO.Member,
                ReservationDate = reservationTransactionDTO.ReservationDate
            };
            await _reservationRepo.DeleteAsync(reservation);
        }
        public Task<bool> CancelReservation(int reservationId)
        {
            throw new NotImplementedException();
        }
        public async Task<List<ReservationTransactionDTO>> GetReservationTransactionByBook(int bookId)
        {
            var reservationsByBook = await _reservationRepo.GetReservationTransactionByBook(bookId);
            var reservationsByBookDTO = new List<ReservationTransactionDTO>();
            if (reservationsByBook == null)
                return reservationsByBookDTO;
            foreach (var reservation in reservationsByBook)
            {
                var reservationDTO = new ReservationTransactionDTO()
                {
                    CreatedOn = DateTime.Now,
                    BookId = bookId,
                    Book = reservation.Book,
                    ExpirationDate = reservation.ExpirationDate,
                    Id = reservation.Id,
                    IsActive = reservation.IsActive,
                    Member = reservation.Member,
                    MemberId = reservation.MemberId,
                    ReservationDate = reservation.ReservationDate
                };
                reservationsByBookDTO.Add(reservationDTO);
            }
            ;
            return reservationsByBookDTO;
        }
        public async Task<List<ReservationTransactionDTO>> GetReservationTransactionByMember(int memberId)
        {
            var reservationsByMember = await _reservationRepo.GetReservationTransactionByMember(memberId);
            var reservationsByMemberDTO = new List<ReservationTransactionDTO>();
            if (reservationsByMember == null)
                return reservationsByMemberDTO;
            foreach (var reservation in reservationsByMember)
            {
                var reservationDTO = new ReservationTransactionDTO()
                {
                    CreatedOn = DateTime.Now,
                    Book = reservation.Book,
                    ExpirationDate = reservation.ExpirationDate,
                    Id = reservation.Id,
                    IsActive = reservation.IsActive,
                    Member = reservation.Member,
                    MemberId = reservation.MemberId,
                    ReservationDate = reservation.ReservationDate
                };
                reservationsByMemberDTO.Add(reservationDTO);
            }
            ;
            return reservationsByMemberDTO;
        }
    }
    public interface IReservationTransactionService
    {
        Task<bool> CancelReservation(int reservationId);
        Task<List<ReservationTransactionDTO>> GetReservationTransactionByMember(int memberId);
        Task<List<ReservationTransactionDTO>> GetReservationTransactionByBook(int bookId);
        Task CreateReservationTransaction(ReservationTransactionDTO reservationTransactionDTO);
        Task UpdateReservationTransaction(ReservationTransactionDTO reservationTransactionDTO);
        Task DeleteReservationTransaction(ReservationTransactionDTO reservationTransactionDTO);
        Task<List<ReservationTransactionDTO>> GetAllReservationTransactions();
        Task<ReservationTransactionDTO> GetReservationTransactionById(int memberId);
    }
}
