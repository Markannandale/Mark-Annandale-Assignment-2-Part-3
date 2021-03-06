﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Assignment2Part3.Models;

namespace Assignment2Part3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // db
        private MovieBookModel db;

        public MoviesController(MovieBookModel db)
        {
            this.db = db;
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return db.Movies.OrderBy(a => a.MovieTitle);
        }

        // GET: api/movies/4
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Movie movie = db.Movies.SingleOrDefault(a => a.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // POST: api/movies
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Movies.Add(movie);
            db.SaveChanges();
            return CreatedAtAction("Post", new { id = movie.MovieId });
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Movie movie)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return AcceptedAtAction("Put", movie);
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.SingleOrDefault(a => a.MovieId == id);

            if (movie == null)
            {
                return NotFound();
            }

            db.Movies.Remove(movie);
            db.SaveChanges();
            return Ok();
        }
    }
}
