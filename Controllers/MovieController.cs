using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSA.Phase2.AmazingApi.model;
using MSA.Phase2.AmazingApi.models;

namespace MSA.Phase2.AmazingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly MovieContext _dbContext;

        /// <summary>
        /// This is the movie controller which offers CRUD operations to manage the movies information
        /// </summary>
        public MoviesController(MovieContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Provides all movie information
        /// </summary>
        /// <returns>A list of of type Movie</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }
            return await _dbContext.Movies.ToListAsync();
        }

        /// <summary>
        /// Provides movie information for a given id
        /// </summary>
        /// <returns>A an object of type Movie</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_dbContext.Movies == null)
            {
                return NotFound();
            }
            var movie = await _dbContext.Movies.FindAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }
}
