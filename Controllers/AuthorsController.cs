using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Libreria.Models;
using Microsoft.AspNetCore.Authorization;

namespace Libreria.Controllers
{

    [Route("api/v1/[controller]")]
    
    public class AuthorsController : Controller
    {
        private readonly LibraryDbContext _context;

        public AuthorsController(LibraryDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public IEnumerable<Author> Get()
        {
            return _context.Authors.ToList();

        }

        //Search by ID
        [HttpGet("{id:int}")]
        [Authorize]
        public IActionResult GetAuthorById(int id)
        {

            var author = this._context.Authors.SingleOrDefault(ct => ct.ID == id);
            if (author != null)
            {
                return Ok(author);
            }
            else
            {
                return NotFound();
            }

        }

        //Search by Name 

        [HttpGet("{name}")]
        public IActionResult GetAuthorByName(string name)
        {
            var info = this._context.Authors.SingleOrDefault(ct => ct.Name == name);

            if (info == null)
            {
                return new NoContentResult();
            }
            else
            {
                return Ok(info);
            }
        }

        //AddAuthors
        [HttpPost]
        public IActionResult AddAuthors([FromBody] Author author)
        {

            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            this._context.Authors.Add(author);
            this._context.SaveChanges();
            return Created($"authors/{author.ID}", author);
        }

        //UpdateAuthors
        [HttpPut("{id}")]
        public IActionResult PutAuthors(int id, [FromBody] Author author)
        {

            var target = _context.Authors.FirstOrDefault(ct => ct.ID == id);
            if (target == null)
            {
                return NotFound();
            }
            else
            {
                target.ID = author.ID;
                //target.Name = author.Name;
                target.Last_Name = author.Last_Name;
                target.Email = author.Email;

                _context.Authors.Update(target);
                _context.SaveChanges();
                return new NoContentResult();
            }

        }

        //Delete Authors
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthors(int id)
        {
            var target = _context.Authors.FirstOrDefault(ct => ct.ID == id);
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                _context.Authors.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}