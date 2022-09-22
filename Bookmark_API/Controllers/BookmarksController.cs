using Bookmark_API.Models;
using Bookmark_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmark_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarksController(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Bookmark>> GetBookmarks()
        {
            return await _bookmarkRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Bookmark>> GetBookmarks(int id)
        {
            return await _bookmarkRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Bookmark>> PostBookmarks([FromBody] Bookmark bookmark)
        {
            var newBookmark = await _bookmarkRepository.Create(bookmark);
            return CreatedAtAction(nameof(GetBookmarks), new { id = newBookmark.Id }, newBookmark);
        }

        [HttpPut]
        public async Task<ActionResult> PutBookmarks(int id, [FromBody] Bookmark bookmark)
        {
            if (id != bookmark.Id)
            {
                return BadRequest();
            }

            await _bookmarkRepository.Update(bookmark);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookmarkToDelete = await _bookmarkRepository.Get(id);
            if (bookmarkToDelete == null)
                return NotFound();

            await _bookmarkRepository.Delete(bookmarkToDelete.Id);
            return NoContent();
        }
    }
}
