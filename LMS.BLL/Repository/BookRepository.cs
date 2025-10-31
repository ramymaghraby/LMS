using LMS.DAL.Database;
using LMS.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Repository
{
    public class BookRepository : GenericRepository<Book>
    {
        ApplicationContext _db = new ApplicationContext();
        public async Task<Book> GetHighestRating()
        {
            var result = await _db.Set<Book>().OrderByDescending(book => book.Rate).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Book> GetLowestRating()
        {
            var result = await _db.Set<Book>().OrderBy(book => book.Rate).FirstOrDefaultAsync();
            return result;
        }
        public async Task<(Book Book, int BorrowCount)> GetMostBorrowed()
        {
            var result = await _db.BorrowTransactions
                .GroupBy(b => b.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    BorrowCount = g.Count()
                })
                .OrderByDescending(x => x.BorrowCount)
                .FirstOrDefaultAsync();
            if (result == null)
                return (null, 0);
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == result.BookId);
            return (book, result.BorrowCount);
        }
        public async Task<(Book Book, int BorrowCount)> GetLeastBorrowed()
        {
            var result = await _db.BorrowTransactions
                .GroupBy(b => b.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    BorrowCount = g.Count()
                })
                .OrderBy(x => x.BorrowCount)
                .FirstOrDefaultAsync();
            if (result == null)
                return (null, 0);
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == result.BookId);
            return (book, result.BorrowCount);
        }
        public async Task<(Book Book, int ReserveCount)> GetMostReserved()
        {
            var result = await _db.ReservationTransactions
                .GroupBy(b => b.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    ReserveCount = g.Count()
                })
                .OrderByDescending(x => x.ReserveCount)
                .FirstOrDefaultAsync();
            if (result == null)
                return (null, 0);
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == result.BookId);
            return (book, result.ReserveCount);
        }
        public async Task<(Book Book, int ReserveCount)> GetLeastReserved()
        {
            var result = await _db.ReservationTransactions
                .GroupBy(b => b.BookId)
                .Select(g => new
                {
                    BookId = g.Key,
                    ReserveCount = g.Count()
                })
                .OrderBy(x => x.ReserveCount)
                .FirstOrDefaultAsync();
            if (result == null)
                return (null, 0);
            var book = await _db.Books.FirstOrDefaultAsync(b => b.Id == result.BookId);
            return (book, result.ReserveCount);
        }

    }

    public interface IBookRepository 
    { 
    }
}
