using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Libreria.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace Libreria.Controllers
{

    [Route("api/v1/[controller]")]
    public class BooksController : Controller
    {

        private readonly LibraryDbContext _context;

        public BooksController(LibraryDbContext context)
        {
            _context = context;
            _context.Books.Include(book => book.Author);
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            //return _context.Books.Include(c => _context.Authors).ToList();
            //return _context.Books.ToList();
            var result = _context.Books.Include(c => c.Author);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetByIdBook(int id)
        {
            var result = this._context.Books.Include(c => _context.Books).SingleOrDefault(t => t.BookID == id);
            if (id == 0)
            {
                return BadRequest();
            }
            else if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return new NoContentResult();
            }
        }

        [HttpPost]
        public IActionResult AddBooks([FromBody] Book books)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            this._context.Books.Add(books);
            this._context.SaveChanges();
            return Created($"books/{books.BookID}", books);
        }

        [HttpPut("{id}")]
        public IActionResult updateBooks(int id, [FromBody] Book books)
        {
            var up = this._context.Books.FirstOrDefault(ct => ct.BookID == id);
            if (up == null)
            {
                return new NoContentResult();
            }
            else
            {
                up.Description = books.Description;
                up.Genre = books.Genre;
                up.Title = books.Title;
                up.Section = books.Section;
                up.Publisher = books.Publisher;
                up.Year = books.Year;

                _context.SaveChanges();
                return Ok(up);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var target = _context.Books.FirstOrDefault(ct => ct.BookID == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
