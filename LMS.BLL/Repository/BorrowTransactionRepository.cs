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
    public class BorrowTransactionRepository : GenericRepository<BorrowTransaction>, IBorrowTransactionRepository
    {
        ApplicationContext _db = new ApplicationContext();
        public async Task<List<BorrowTransaction>> FindByBook(int bookId)
        {
            var transactionsByBook = await _db.BorrowTransactions.Where(b => b.BookId == bookId).ToListAsync();
            return transactionsByBook;
        }

        public async Task<List<BorrowTransaction>> FindByMember(int memberId)
        {
            var transactionsByMember = await _db.BorrowTransactions.Where(b => b.MemberId == memberId).ToListAsync();
            return transactionsByMember;
        }

        public async Task<bool> ReturnBook(int borrowTransactionId)
        {
            var transaction = await _db.BorrowTransactions.FindAsync(borrowTransactionId);
            if (transaction == null)
                return false;
            transaction.IsActive = false;
            return true;
        }
    }
    public interface IBorrowTransactionRepository
    {
        Task<bool> ReturnBook(int borrowTransactionId);
        Task<List<BorrowTransaction>> FindByBook(int bookId);
        Task<List<BorrowTransaction>> FindByMember(int memberId);

    }
}
