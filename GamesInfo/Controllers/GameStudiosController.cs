#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamesInfo.Data;
using GamesInfo.Models;

namespace GamesInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameStudiosController : ControllerBase
    {
        private readonly DataContext _context;

        public GameStudiosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/GameStudios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameStudio>>> GetGameStudios()
        {
            return await _context.GameStudios.ToListAsync();
        }

        // GET: api/GameStudios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameStudio>> GetGameStudio(int id)
        {
            var gameStudio = await _context.GameStudios.FindAsync(id);

            if (gameStudio == null)
            {
                return NotFound();
            }

            return gameStudio;
        }

        // PUT: api/GameStudios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameStudio(int id, GameStudio gameStudio)
        {
            if (id != gameStudio.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameStudio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameStudioExists(id))
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

        // POST: api/GameStudios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GameStudio>> PostGameStudio(GameStudio gameStudio)
        {
            _context.GameStudios.Add(gameStudio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameStudio", new { id = gameStudio.Id }, gameStudio);
        }

        // DELETE: api/GameStudios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGameStudio(int id)
        {
            var gameStudio = await _context.GameStudios.FindAsync(id);
            if (gameStudio == null)
            {
                return NotFound();
            }

            _context.GameStudios.Remove(gameStudio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GameStudioExists(int id)
        {
            return _context.GameStudios.Any(e => e.Id == id);
        }
    }
}
