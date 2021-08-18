using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ExternalApiBooks.Controllers
{
    [Route("api/v1/books")]
    public class BooksController : ControllerBase
    {
        private readonly string[] _bookGenres = new[] {"Adventure", "Fiction", "Drama", "Novel"};
        private readonly string[] _authorNames = new[] {"Paul", "Emma", "Monika"};
        private readonly string[] _authorLastNames = new[] {"Show", "Blanche", "Redklif"};
        
        [HttpGet("")]
        public List<Book> GetBooks(int numberOfBooks)
        {
            var books = new List<Book>();
            var randomizer = new Random();
            for (var i = 0; i < numberOfBooks; i++)
            {
                var genre = _bookGenres[randomizer.Next(0, 3)];
                var authorName = $"{_authorNames[randomizer.Next(0, 2)]} {_authorLastNames[randomizer.Next(0, 2)]}";
                var price = Math.Round((randomizer.Next(15, 340))/Math.PI, 2);
                var dateOffset = randomizer.Next(10, 500);
                var releaseDate = DateTime.Now.AddDays(-dateOffset);
                books.Add(new Book()
                {
                    Author = authorName,
                    Genre = genre,
                    Price = price,
                    ReleaseDate = releaseDate,
                    Name = $"{genre} of {authorName} released on {releaseDate.DayOfWeek} {releaseDate.Date:d}"
                });

            }
            return books;
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}