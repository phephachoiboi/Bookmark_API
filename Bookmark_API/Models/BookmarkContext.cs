using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmark_API.Models
{
    public class BookmarkContext : DbContext
    {
        public BookmarkContext(DbContextOptions<BookmarkContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Bookmark> Bookmarks { get; set; }
    }
}
