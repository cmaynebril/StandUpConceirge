using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StandUpConceirge.Models.DB;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BotQuestionsAPIController : ControllerBase
    {
        private readonly botContext _context;

        public BotQuestionsAPIController(botContext context)
        {
            _context = context;
        }

        // GET: api/BotQuestionsAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BotQuestions>>> GetBotQuestions()
        {
            //return await _context.BotQuestions.ToListAsync();
            var result = await (from q in _context.BotQuestions
                                select new
                                {
                                    q.Id,
                                    q.Questions,
                                    //BotQuestions = result.SelectMany(r => r.BotQuestions),
                                    q.ScheduleId
                                }).ToListAsync();

            return Ok(result);
        }

        // GET: api/BotQuestionsAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BotQuestions>> GetBotQuestions(int id)
        {
            //var botQuestions = await _context.BotQuestions.FindAsync(id);

            //if (botQuestions == null)
            //{
            //    return NotFound();
            //}

            //return botQuestions;

            var result = await (from q in _context.BotQuestions
                                where q.ScheduleId == id
                                select new
                                {
                                    q.Id,
                                    q.Questions,
                                    q.ScheduleId
                                }).ToListAsync();
            return Ok(result);

        }

        // PUT: api/BotQuestionsAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBotQuestions(int id, BotQuestions botQuestions)
        {
            if (id != botQuestions.Id)
            {
                return BadRequest();
            }

            _context.Entry(botQuestions).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BotQuestionsExists(id))
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

        // POST: api/BotQuestionsAPI
        [HttpPost]
        public async Task<ActionResult<BotQuestions>> PostBotQuestions(BotQuestions botQuestions)
        {
            _context.BotQuestions.Add(botQuestions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBotQuestions", new { id = botQuestions.Id }, botQuestions);
        }

        // DELETE: api/BotQuestionsAPI/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BotQuestions>> DeleteBotQuestions(int id)
        {
            var botQuestions = await _context.BotQuestions.FindAsync(id);
            if (botQuestions == null)
            {
                return NotFound();
            }

            _context.BotQuestions.Remove(botQuestions);
            await _context.SaveChangesAsync();

            return botQuestions;
        }

        private bool BotQuestionsExists(int id)
        {
            return _context.BotQuestions.Any(e => e.Id == id);
        }
    }
}
