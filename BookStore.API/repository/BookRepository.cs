using AutoMapper;
using BookStore.API.Data;
using BookStore.API.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStoreContext context;
        private readonly IMapper mapper;

        public BookRepository(BookStoreContext context,IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var recordes = await context.Books.ToListAsync();
            return mapper.Map<List<BookModel>>(recordes);
        }
        
        public async Task<BookModel> GetBookByIdAsync(int BookId)
        {
            /* var record = await context.Books.Where(x => x.Id == BookId).Select(x => new BookModel()
             {
                 Id=x.Id,
                 Title=x.Title,
                 Description=x.Description
             }).FirstOrDefaultAsync();*/

            var book = await context.Books.FindAsync(BookId);
            return mapper.Map<BookModel>(book);
        }
        public async Task<int> addBookAsync(BookModel bookModel)
        {
            var book = new Books
            {
                Title = bookModel.Title,
                Description = bookModel.Description
            };

            context.Books.Add(book);
            await  context.SaveChangesAsync();

            return book.Id;
        }
        public async Task UpdateBookAsync(int BookId,BookModel bookModel)
        {
            /*var book =await context.Books.FindAsync(BookId);
            if (book!=null)
            {
                book.Title = bookModel.Title;
                book.Description = bookModel.Description;
                await context.SaveChangesAsync();
            */
        var book = new Books
        {
            Id=BookId,
            Title = bookModel.Title,
            Description = bookModel.Description
        };

        context.Books.Update(book);
        await context.SaveChangesAsync();


    }

        public async Task UpdateBookPatchAsync(int BookId, JsonPatchDocument bookModel)
        {
            var book = await context.Books.FindAsync(BookId);
            if(book !=null)
            {
                bookModel.ApplyTo(book);
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteBookAsync(int BookId)
        {
            var book = new Books { Id = BookId };
            var res= context.Books.Remove(book);
            await  context.SaveChangesAsync();
            
        }
    }
}
