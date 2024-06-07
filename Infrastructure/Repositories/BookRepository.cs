using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            var books = await _appDbContext.Books.ToListAsync();
            return books;
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            var book = await _appDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            return book;
        }
        public async Task AddAsync(Book book)
        {
            _appDbContext.Books.Add(book);
            await _appDbContext.SaveChangesAsync();
        }
        public async Task UpdateAsync(Book book)
        {
            _appDbContext.Entry(book).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var book = await _appDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                _appDbContext.Books.Remove(book);
                await _appDbContext.SaveChangesAsync();
            }
        }
    }
}
