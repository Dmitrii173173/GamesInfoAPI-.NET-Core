#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamesInfo;
using GamesInfo.Data;

namespace GamesInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameСategoryController : ControllerBase
    {
        private readonly DataContext _context;

        public GameСategoryController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GameСategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameСategory>>> GetGameСategories()
        {
            return await _context.GameСategories.ToListAsync();
        }

        // GET: api/GameСategory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameСategory>> GetGameСategory(int id)
        {
            var gameСategory = await _context.GameСategories.FindAsync(id);

            if (gameСategory == null)
            {
                return NotFound();
            }

            return gameСategory;
        }

        // PUT: api/GameСategory/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameСategory(int id, GameСategory gameСategory)
        {
            if (id != gameСategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameСategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameСategoryExists(id))
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

        // POST: api/GameСategory
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameСategory>> PostGameСategory(GameСategory gameСategory)
        {
            _context.GameСategories.Add(gameСategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameСategory", new { id = gameСategory.Id }, gameСategory);
        }

        // DELETE: api/GameСategory/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameСategory(int id)
        {
            var gameСategory = await _context.GameСategories.FindAsync(id);
            if (gameСategory == null)
            {
                return NotFound();
            }

            _context.GameСategories.Remove(gameСategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameСategoryExists(int id)
        {
            return _context.GameСategories.Any(e => e.Id == id);
        }
    }
}
