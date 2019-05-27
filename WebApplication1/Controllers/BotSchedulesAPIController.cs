using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandUpConceirge.Models;
using StandUpConceirge.Models.DB;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotSchedulesAPIController : ControllerBase
    {
        private readonly botContext _context;

        public BotSchedulesAPIController(botContext context)
        {
            _context = context;
        }

        // GET: api/BotSchedules1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BotSchedule>>> GetBotSchedule()
        {
            var result = await (from s in _context.BotSchedule
                                select new
                                {
                                    s.Id,
                                    s.Date,
                                    s.Time,
                                    s.Frequency,
                                    s.Day
                                }).ToListAsync();

            return Ok(result);
            //return await _context.BotSchedule.ToListAsync();
        }

        // GET: api/BotSchedules1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BotSchedule>> GetBotSchedule(int id)
        {
            //var botSchedule = await _context.BotSchedule.FindAsync(id);

            //if (botSchedule == null)
            //{
            //    return NotFound();
            //}
            var result = await (from s in _context.BotSchedule
                                where s.Id == id
                                select new
                                {
                                    s.Id,
                                    s.Date,
                                    s.Time,
                                    s.Frequency,
                                    s.Day
                                }).ToListAsync();

            return Ok(result);
        }

        // PUT: api/BotSchedules1/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBotSchedule(int id, BotSchedule botSchedule)
        {
            if (id != botSchedule.Id)
            {
                return BadRequest();
            }

            _context.Entry(botSchedule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotScheduleExists(id))
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

        // POST: api/BotSchedules1
        [HttpPost]
        public async Task<ActionResult<BotSchedule>> PostBotSchedule(BotSchedule botSchedule)
        {
            _context.BotSchedule.Add(botSchedule);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBotSchedule", new { id = botSchedule.Id }, botSchedule);
        }

        // DELETE: api/BotSchedules1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BotSchedule>> DeleteBotSchedule(int id)
        {
            var botSchedule = await _context.BotSchedule.FindAsync(id);
            if (botSchedule == null)
            {
                return NotFound();
            }

            _context.BotSchedule.Remove(botSchedule);
            await _context.SaveChangesAsync();

            return botSchedule;
        }

        private bool BotScheduleExists(int id)
        {
            return _context.BotSchedule.Any(e => e.Id == id);
        }
    }
}
