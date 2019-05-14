using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandUpConceirge.Models.DB;

namespace WebApplication1.Controllers
{
    public class BotQuestionsController : Controller
    {
        private readonly botContext _context;

        public BotQuestionsController(botContext context)
        {
            _context = context;
        }

        // GET: BotQuestions
        public async Task<IActionResult> Index()
        {
            return View(await _context.BotQuestions.ToListAsync());
        }

        // GET: BotQuestions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botQuestions = await _context.BotQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (botQuestions == null)
            {
                return NotFound();
            }

            return View(botQuestions);
        }

        // GET: BotQuestions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BotQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BotQuestions botQuestions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(botQuestions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(botQuestions);
        }

        // GET: BotQuestions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botQuestions = await _context.BotQuestions.FindAsync(id);
            if (botQuestions == null)
            {
                return NotFound();
            }
            return View(botQuestions);
        }

        // POST: BotQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Question,BotScheduleId")] BotQuestions botQuestions)
        {
            if (id != botQuestions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(botQuestions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotQuestionsExists(botQuestions.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(botQuestions);
        }

        // GET: BotQuestions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botQuestions = await _context.BotQuestions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (botQuestions == null)
            {
                return NotFound();
            }

            return View(botQuestions);
        }

        // POST: BotQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var botQuestions = await _context.BotQuestions.FindAsync(id);
            _context.BotQuestions.Remove(botQuestions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotQuestionsExists(int id)
        {
            return _context.BotQuestions.Any(e => e.Id == id);
        }
    }
}
