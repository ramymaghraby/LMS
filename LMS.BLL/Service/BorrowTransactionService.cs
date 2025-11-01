using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LMS.BLL.Service
{
    public class BorrowTransactionService : IBorrowTransactionService
    {
        BorrowTransactionRepository _borrowRepo = new BorrowTransactionRepository();

        public async Task<List<BorrowTransactionDTO>> GetAllBorrowTransactions()
        {
            var transactionsList = await _borrowRepo.GetAll( b => b.IsActive);
            var borrowTransactionsListDTO = new List<BorrowTransactionDTO>();
            foreach (var transaction in transactionsList)
            {
                var transactionDTO = new BorrowTransactionDTO()
                {
                    Id = transaction.Id,
                    BookId = transaction.BookId,
                    IsActive = transaction.IsActive,
                    Book = transaction.Book,
                    BorrowDate = transaction.BorrowDate,
                    CreatedOn = transaction.CreatedOn,
                    DueDate = transaction.DueDate,
                    Member = transaction.Member,
                    MemberId = transaction.MemberId,
                    ReturnDate = transaction.ReturnDate
                };
                borrowTransactionsListDTO.Add(transactionDTO);                
            }
            return borrowTransactionsListDTO;
        }

        public async Task<BorrowTransactionDTO> GetBorrowTransactionById(int transactionId)
        {
            var transaction = await _borrowRepo.GetBy(t => t.Id == transactionId);
            var transactionDTO = new BorrowTransactionDTO() 
            { 
                Id = transaction.Id,
                BookId = transaction.BookId,
                IsActive = transaction.IsActive,
                Book = transaction.Book,
                BorrowDate = transaction.BorrowDate,
                CreatedOn = transaction.CreatedOn,
                DueDate = transaction.DueDate,
                Member = transaction.Member,
                MemberId = transaction.MemberId,
                ReturnDate = transaction.ReturnDate
            };
            return transactionDTO;
        }
        public async Task CreateBorrowTransaction(BorrowTransactionDTO transaction)
        {
            var borrowTransaction = new BorrowTransaction()
            {
                Id = transaction.Id,
                BookId = transaction.BookId,
                IsActive = transaction.IsActive,
                Book = transaction.Book,
                BorrowDate = transaction.BorrowDate, 
                CreatedOn = transaction.CreatedOn,
                DueDate = transaction.DueDate,
                Member = transaction.Member,
                MemberId = transaction.MemberId,
                ReturnDate = transaction.ReturnDate
            };
            await _borrowRepo.CreateAsync(borrowTransaction);
        }
        public async Task UpdateBorrowTransaction(BorrowTransactionDTO transaction)
        {
            var borrowTransaction = new BorrowTransaction()
            {
                Id = transaction.Id,
                BookId = transaction.BookId,
                IsActive = transaction.IsActive,
                Book = transaction.Book,
                BorrowDate = transaction.BorrowDate,
                CreatedOn = transaction.CreatedOn,
                DueDate = transaction.DueDate,
                Member = transaction.Member,
                MemberId = transaction.MemberId,
                ReturnDate = transaction.ReturnDate
            };
            await _borrowRepo.UpdateAsync(borrowTransaction);
        }
        public async Task DeleteBorrowTransaction(BorrowTransactionDTO transaction)
        {
            var borrowTransaction = new BorrowTransaction()
            {
                Id = transaction.Id,
                BookId = transaction.BookId,
                IsActive = transaction.IsActive,
                Book = transaction.Book,
                BorrowDate = transaction.BorrowDate,
                CreatedOn = transaction.CreatedOn,
                DueDate = transaction.DueDate,
                Member = transaction.Member,
                MemberId = transaction.MemberId,
                ReturnDate = transaction.ReturnDate
            };
            await _borrowRepo.UpdateAsync(borrowTransaction);
        }
        public async Task<List<BorrowTransactionDTO>> FindByBook(int bookId)
        {
            var transactionList = await _borrowRepo.FindByBook(bookId);
            var transactionListDTO = new List<BorrowTransactionDTO>();
            if (transactionList == null)
                return new List<BorrowTransactionDTO>();
            foreach (var transaction in transactionListDTO)
            {
                var transactionDTO = new BorrowTransactionDTO() 
                { 
                    Id = transaction.Id,
                    BookId = transaction.BookId,
                    IsActive = transaction.IsActive,
                    Book = transaction.Book,
                    BorrowDate = transaction.BorrowDate,
                    CreatedOn = transaction.CreatedOn,
                    DueDate = transaction.DueDate,
                    Member = transaction.Member,
                    MemberId = transaction.MemberId,
                    ReturnDate = transaction.ReturnDate
                    
                };
                transactionListDTO.Add(transactionDTO);
            }
            
            return transactionListDTO;
        }
        public async Task<List<BorrowTransactionDTO>> FindByMember(int memberId)
        {
            var transactionList = await _borrowRepo.FindByMember(memberId);
            var transactionListDTO = new List<BorrowTransactionDTO>();
            if (transactionList == null)
                return new List<BorrowTransactionDTO>();
            foreach (var transaction in transactionListDTO)
            {
                var transactionDTO = new BorrowTransactionDTO()
                {
                    Id = transaction.Id,
                    BookId = transaction.BookId,
                    IsActive = transaction.IsActive,
                    Book = transaction.Book,
                    BorrowDate = transaction.BorrowDate,
                    CreatedOn = transaction.CreatedOn,
                    DueDate = transaction.DueDate,
                    Member = transaction.Member,
                    MemberId = transaction.MemberId,
                    ReturnDate = transaction.ReturnDate

                };
                transactionListDTO.Add(transactionDTO);
            }

            return transactionListDTO;
        }
        public async Task<bool> ReturnBook(int borrowTransactionId)
        {
            await _borrowRepo.ReturnBook(borrowTransactionId);
            return true;
        }
    }
    public interface IBorrowTransactionService
    {
        Task<List<BorrowTransactionDTO>> GetAllBorrowTransactions();
        Task<BorrowTransactionDTO> GetBorrowTransactionById(int transactionId);
        Task CreateBorrowTransaction(BorrowTransactionDTO transaction);
        Task UpdateBorrowTransaction(BorrowTransactionDTO transaction);
        Task DeleteBorrowTransaction(BorrowTransactionDTO transaction);
        Task<bool> ReturnBook(int borrowTransactionId);
        Task<List<BorrowTransactionDTO>> FindByBook(int bookId);
        Task<List<BorrowTransactionDTO>> FindByMember(int memberId);
    }
}
