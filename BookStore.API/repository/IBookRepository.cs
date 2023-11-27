using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.repository
{
    public interface IBookRepository
    {
        Task<List<BookModel>> GetAllBooksAsync();
        Task<BookModel> GetBookByIdAsync(int BookId);
        Task<int> addBookAsync(BookModel bookModel);
        Task UpdateBookAsync(int BookId, BookModel bookModel);
        Task UpdateBookPatchAsync(int BookId, JsonPatchDocument bookModel);
        Task DeleteBookAsync(int BookId);

    }
}
