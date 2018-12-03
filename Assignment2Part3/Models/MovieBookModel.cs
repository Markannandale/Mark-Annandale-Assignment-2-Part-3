using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment2Part3.Models
{
    public class MovieBookModel : DbContext
    {
        public MovieBookModel(DbContextOptions<MovieBookModel> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
