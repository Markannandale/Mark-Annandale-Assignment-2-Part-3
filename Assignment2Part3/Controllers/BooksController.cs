using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2Part3.Models;

namespace Assignment2Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        // db
        private MovieBookModel db;

        public BooksController(MovieBookModel db)
        {
            this.db = db;
        }

        // GET: api/books
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return db.Books.OrderBy(a => a.BookTitle);
        }

        // GET: api/books/4
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Book book = db.Books.SingleOrDefault(a => a.BookId == id);

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = book.BookId });
        }

        // PUT: api/books/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Book book)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Put", book);
        }

        // DELETE: api/books/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Book book = db.Books.SingleOrDefault(a => a.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();
            return Ok();
        }
    }
}
