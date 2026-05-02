using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using VargasLibraryNowApi.Controller;
using VargasLibraryNowApi.MODELS;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VargasLibraryNowApi.Controller
{
    [Route("api/v1/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
            {
            new Book
            {
                Id = 1,
                Title = "Crime and Punishment",
                Author = "Fyodor Dostoevsky",
                Genre = "Drama",
                Available = true,
                PublishedYear = 1866

        },
        new Book
            {
              Id = 2,
                Title = "Lord Of The Rings",
                Author = "J.R.R Tolkien",
                Genre = "Fantasy",
                Available = true,
                PublishedYear = 1954 & 1955

        }
      }; [HttpGet("{id}")]

        public IActionResult GetAll()
        {
            return Ok(new
            {
                Status = "success",
                data = books,
                message = "Books Retrieved"
            });
        }
        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (books == null)
                return NotFound(new
                {
                    Status = "error",
                    data = books,
                    message = "Books not found"

                });
            return Ok(new
            {
                Status = "success",
                data = books,
                message = "Books retreived"

            });
        }
        [HttpPost]
        public IActionResult Create([FromBody] Book newBook)
        {
            newBook.Id = books.Count + 1;
            books.Add(newBook);
            return CreatedAtAction(nameof(GetById),
                new { id = newBook.Id },
                new
                {
                    status = "success",
                    data = newBook,
                    message = "Book Created"

                });

        }
        [HttpPut("{id}")]
        public IActionResult Update(int id,
            [FromBody] Book updatebook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "book not found."
                });

            book.Title = updatebook.Title;
            book.Author = updatebook.Author;
            book.Available = updatebook.Available;
            book.Genre = updatebook.Genre;
            book.PublishedYear = updatebook.PublishedYear;

            return Ok(new
            {
                status = "success",
                data = (object?)null,
                message = "book updated."
            });

        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (books == null)
                return NotFound(new
                {
                    Status = "error",
                    data = books,
                    message = "Books not found"
                });

            
            books.Remove(book);
            return Ok(new
            {
                Status = "success",
                data = books,
                message = "Books deleted."
            });

        }  
    }
}

