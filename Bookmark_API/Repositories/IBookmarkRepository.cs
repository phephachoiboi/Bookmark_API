using Bookmark_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmark_API.Repositories
{
    public interface IBookmarkRepository
    {
        Task<IEnumerable<Bookmark>> Get();

        Task<Bookmark> Get(int id);

        Task<Bookmark> Create(Bookmark bookmark);

        Task Update(Bookmark bookmark);

        Task Delete(int id);

    }
}
