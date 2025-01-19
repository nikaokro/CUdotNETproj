using dotNETproject.DTOs;
using dotNETproject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace dotNETproject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreContext _context;

        public BooksController(BookstoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            return Ok(_context.Books.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult CreateBook([FromBody] CreateBookDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var book = new Book
            {
                Title = dto.Title,
                YearOfPublication = dto.YearOfPublication,
                AuthorName = dto.AuthorName
            };

            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto dto)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            if (dto.Title != null) book.Title = dto.Title;
            if (dto.YearOfPublication.HasValue) book.YearOfPublication = dto.YearOfPublication.Value;
            if (dto.AuthorName != null) book.AuthorName = dto.AuthorName;

            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null) return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
