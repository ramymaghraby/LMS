using LMS.BLL.Model;
using LMS.BLL.Repository;
using LMS.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BLL.Service
{
    public class BookService : IBookService
    {
        BookRepository _bookRepo = new BookRepository();
        public async Task<List<BookDTO>> GetAllBooks()
        {
            var booksList = await _bookRepo.GetAll(b => b.IsActive == true);
            var booksListDTO = new List<BookDTO>();

            foreach (var item in booksList)
            {
                var bookDTO = new BookDTO()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author,
                    ISBN = item.ISBN,
                    PublishedYear = item.PublishedYear,
                    Rate = item.Rate,
                    CategoryId = item.CategoryId,
                    IsAvailable = item.IsAvailable
                };
                booksListDTO.Add(bookDTO);
            }
            return booksListDTO;
        }

        public async Task<BookDTO> GetBookById(int bookId)
        {
            var book =await _bookRepo.GetBy(b => b.Id == bookId);
            var bookDTO = new BookDTO()
            {
                Id = bookId,
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Rate = book.Rate,
                CategoryId = book.CategoryId,
                IsAvailable = book.IsAvailable
            };
            return bookDTO;
        }
        public async Task CreateBook(BookDTO bookDTO)
        {
            var book = new Book()
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                ISBN = bookDTO.ISBN,
                PublishedYear = bookDTO.PublishedYear,
                    
                Rate = bookDTO.Rate,
                CategoryId = bookDTO.CategoryId,
                IsAvailable = bookDTO.IsAvailable

            };
            await _bookRepo.CreateAsync(book);
        }
        public async Task UpdateBook(BookDTO bookDTO)
        {
            var book = new Book()
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                ISBN = bookDTO.ISBN,
                PublishedYear = bookDTO.PublishedYear,

                Rate = bookDTO.Rate,
                CategoryId = bookDTO.CategoryId,
                IsAvailable = bookDTO.IsAvailable

            };
            await _bookRepo.UpdateAsync(book);
        }
        public async Task DeleteBook(BookDTO bookDTO)
        {
            var book = new Book()
            {
                Id = bookDTO.Id,
                Title = bookDTO.Title,
                Author = bookDTO.Author,
                ISBN = bookDTO.ISBN,
                PublishedYear = bookDTO.PublishedYear,

                Rate = bookDTO.Rate,
                CategoryId = bookDTO.CategoryId,
                IsAvailable = bookDTO.IsAvailable

            };
            await _bookRepo.DeleteAsync(book);
        }
        public async Task<(BookDTO, int)> GetLeastBorrowedBook()
        {
            var book = await _bookRepo.GetLeastBorrowed();
            var bookDTO = new BookDTO() 
            { 
                Author = book.Book.Author,
                Id = book.Book.Id,
                Title = book.Book.Title,
                CategoryId= book.Book.CategoryId,
                CreatedOn = book.Book.CreatedOn,
                IsActive = book.Book.IsActive,
                IsAvailable = book.Book.IsAvailable,
                ISBN= book.Book.ISBN,
                PublishedYear = book.Book.PublishedYear, 
                Rate = book.Book.Rate
            };
            return (bookDTO, book.BorrowCount);
        }
        public async Task<BookDTO> GetLeastRatedBook()
        {
            var book = await _bookRepo.GetLowestRating();
            var bookDTO = new BookDTO()
            {
                Author = book.Author,
                Id = book.Id,
                Title = book.Title,
                CategoryId = book.CategoryId,
                CreatedOn = book.CreatedOn,
                IsActive = book.IsActive,
                IsAvailable = book.IsAvailable,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Rate = book.Rate
            };
            return bookDTO;
        }
        public async Task<(BookDTO, int)> GetLeastReservedBook()
        {
            var book = await _bookRepo.GetLeastReserved();
            var bookDTO = new BookDTO()
            {
                Author = book.Book.Author,
                Id = book.Book.Id,
                Title = book.Book.Title,
                CategoryId = book.Book.CategoryId,
                CreatedOn = book.Book.CreatedOn,
                IsActive = book.Book.IsActive,
                IsAvailable = book.Book.IsAvailable,
                ISBN = book.Book.ISBN,
                PublishedYear = book.Book.PublishedYear,
                Rate = book.Book.Rate
            };
            return (bookDTO, book.ReserveCount);
        }
        public async Task<(BookDTO, int)> GetTopBorrowedBook()
        {
            var book = await _bookRepo.GetMostBorrowed();
            var bookDTO = new BookDTO()
            {
                Author = book.Book.Author,
                Id = book.Book.Id,
                Title = book.Book.Title,
                CategoryId = book.Book.CategoryId,
                CreatedOn = book.Book.CreatedOn,
                IsActive = book.Book.IsActive,
                IsAvailable = book.Book.IsAvailable,
                ISBN = book.Book.ISBN,
                PublishedYear = book.Book.PublishedYear,
                Rate = book.Book.Rate
            };
            return (bookDTO, book.BorrowCount);
        }
        public async Task<BookDTO> GetTopRatedBook()
        {
            var book = await _bookRepo.GetHighestRating();
            var bookDTO = new BookDTO()
            {
                Author = book.Author,
                Id = book.Id,
                Title = book.Title,
                CategoryId = book.CategoryId,
                CreatedOn = book.CreatedOn,
                IsActive = book.IsActive,
                IsAvailable = book.IsAvailable,
                ISBN = book.ISBN,
                PublishedYear = book.PublishedYear,
                Rate = book.Rate
            };
            return bookDTO;
        }
        public async Task<(BookDTO, int)> GetTopReservedBook()
        {
            var book = await _bookRepo.GetMostReserved();
            var bookDTO = new BookDTO()
            {
                Author = book.Book.Author,
                Id = book.Book.Id,
                Title = book.Book.Title,
                CategoryId = book.Book.CategoryId,
                CreatedOn = book.Book.CreatedOn,
                IsActive = book.Book.IsActive,
                IsAvailable = book.Book.IsAvailable,
                ISBN = book.Book.ISBN,
                PublishedYear = book.Book.PublishedYear,
                Rate = book.Book.Rate
            };
            return (bookDTO, book.ReserveCount);
        }
    }
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(int bookId);
        Task CreateBook(BookDTO bookDTO);
        Task UpdateBook(BookDTO bookDTO);
        Task DeleteBook(BookDTO bookDTO);
        Task<BookDTO> GetTopRatedBook();
        Task<BookDTO> GetLeastRatedBook();
        Task<(BookDTO, int)> GetTopReservedBook();
        Task<(BookDTO, int)> GetLeastReservedBook();
        Task<(BookDTO, int)> GetTopBorrowedBook();
        Task<(BookDTO, int)> GetLeastBorrowedBook();
    }
}
