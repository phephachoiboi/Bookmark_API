using Bookmark_API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmark_API.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly BookmarkContext _context;

        public BookmarkRepository(BookmarkContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Bookmark>> Get()
        {
            return await _context.Bookmarks.ToListAsync();
        }

        public async Task<Bookmark> Get(int id)
        {
            return await _context.Bookmarks.FindAsync(id);
        }

        public async Task<Bookmark> Create(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            await _context.SaveChangesAsync();

            return bookmark;
        }

        public async Task Update(Bookmark bookmark)
        {
            _context.Entry(bookmark).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var bookmarkToDelete = await _context.Bookmarks.FindAsync(id);
            _context.Bookmarks.Remove(bookmarkToDelete);
            await _context.SaveChangesAsync();
        } 
    }
}
