using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayerApi.Data;
using PlayerApi.Model;

namespace PlayerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerApiContext _context;

        public PlayersController(PlayerApiContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayersModel>>> GetPlayersModel()
        {
            return await _context.PlayersModel.ToListAsync();
        }

        // GET: api/Players/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlayersModel>> GetPlayersModel(int id)
        {
            var playersModel = await _context.PlayersModel.FindAsync(id);

            if (playersModel == null)
            {
                return NotFound();
            }

            return playersModel;
        }

        // PUT: api/Players/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlayersModel(int id, PlayersModel playersModel)
        {
            if (id != playersModel.PlayerId)
            {
                return BadRequest();
            }

            _context.Entry(playersModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayersModelExists(id))
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

        // POST: api/Players
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PlayersModel>> PostPlayersModel(PlayersModel playersModel)
        {
            _context.PlayersModel.Add(playersModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlayersModel", new { id = playersModel.PlayerId }, playersModel);
        }

        // DELETE: api/Players/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PlayersModel>> DeletePlayersModel(int id)
        {
            var playersModel = await _context.PlayersModel.FindAsync(id);
            if (playersModel == null)
            {
                return NotFound();
            }

            _context.PlayersModel.Remove(playersModel);
            await _context.SaveChangesAsync();

            return playersModel;
        }

        private bool PlayersModelExists(int id)
        {
            return _context.PlayersModel.Any(e => e.PlayerId == id);
        }
    }
}
