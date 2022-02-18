#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieEntWebAPI.Data;
using MovieEntWebAPI.Dtos;
using MovieEntWebAPI.Extensions;
using MovieEntWebAPI.Models;

namespace MovieEntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Movies
        //DON
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovie()
        {
            return await _context.Movie.Select(movie=>movie.AsDto()).ToListAsync();
        }

        // GET: api/Movies/5
        //DONE
        [HttpGet("{movieId}")]
        public async Task<ActionResult<MovieDto>> GetMovie(Guid movieId)
        {
            var movie = await _context.Movie.FindAsync(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return movie.AsDto();
        }

        // PUT: api/Movies/5       
        [HttpPut("{movieId}")]
        public async Task<IActionResult> PutMovie(Guid movieId, UpdateMovieDto updateMovieDto)
        {
            if (!MovieExists(movieId))
                return BadRequest("Movie Id Doesn't Exist");
            if (!CategoryExists(updateMovieDto.CategoryId))
                return BadRequest("Category Id Doesn't Exist");

            Movie movie = new Movie
            {
                Id = movieId,
                Title = updateMovieDto.Title,
                Description = updateMovieDto.Description,
                ReleaseDate = updateMovieDto.ReleaseDate,
                VideoLink = updateMovieDto.VideoLink,
                ThumbnailImage = updateMovieDto.ThumbnailImage,
                CategoryId=updateMovieDto.CategoryId
            };

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(movieId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Movies
        //DONE
        [HttpPost("{categoryId}")]
        public async Task<ActionResult<Movie>> PostMovie(Guid categoryId, CreateMovieDto createMovieDto)
        {
            if (!CategoryExists(categoryId))
                return BadRequest("Category Id Doesn't Exist");

            var movie = new Movie
            {
                Id = Guid.NewGuid(),
                Title = createMovieDto.Title,
                Description = createMovieDto.Description,
                ReleaseDate = createMovieDto.ReleaseDate,
                VideoLink = createMovieDto.VideoLink,
                CategoryId = categoryId,
                ThumbnailImage = createMovieDto.ThumbnailImage
            };

            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(Guid movieId)
        {
            var movie = await _context.Movie.FindAsync(movieId);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //DONE
        private bool MovieExists(Guid id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
        //DONE
        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
