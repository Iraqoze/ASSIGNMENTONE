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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        //DONE
        [HttpGet("/getcategories")]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategory()
        {
            return await _context.Category.Select(cat=>cat.AsDto()).ToListAsync();
        }

        // GET: api/Categories/5
        //DONE
        [HttpGet("getcategory/{categoryId}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(Guid categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return category.AsDto();
        }

        // PUT: api/Categories/5
        // DONE
        [HttpPut("updatecategory/{categoryId}")]
        public async Task<IActionResult> PutCategory(Guid categoryId, UpdateCategoryDto updateCategoryDto)
        {

            if (!CategoryExists(categoryId))
                return BadRequest();

            Category cat = new Category
            {
                Id = categoryId,
                Title= updateCategoryDto.Title,
                Description=updateCategoryDto.Description
            };

            _context.Entry(cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(categoryId))
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


        // POST: api/Categories
        //DONE
        [HttpPost("/categories/postcategory")]
        public async Task<ActionResult<CategoryDto>> PostCategory(CreateCategoryDto createCategoryDto)
        {
            var category = new Category{
            Id= new Guid(),
            Title=createCategoryDto.Title,
            Description=createCategoryDto.Description,
            };

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Categories/5
        //DONE
        [HttpDelete("deletecategory/{categoryId}")]
        public async Task<IActionResult> DeleteCategory(Guid categoryId)
        {
            var category = await _context.Category.FindAsync(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //DONE
        private bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.Id == id);
        }
    }
}
