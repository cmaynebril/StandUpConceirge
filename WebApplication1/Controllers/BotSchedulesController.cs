using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.DB;

namespace WebApplication1.Controllers
{
    public class BotSchedulesController : Controller
    {
        private readonly botContext _context;

        public BotSchedulesController(botContext context)
        {
            _context = context;
        }

        // GET: BotSchedules
        public async Task<IActionResult> Index()
        {
            return View(await _context.BotSchedule.ToListAsync());
        }

        // GET: BotSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botSchedule = await _context.BotSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (botSchedule == null)
            {
                return NotFound();
            }

            return View(botSchedule);
        }

        //// GET: BotSchedules/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: BotSchedules/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,StartDay,TimeOccur,DayOccur,FrequencyOccur")] BotSchedule botSchedule)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(botSchedule);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(botSchedule);
        //}

        // GET: BotSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botSchedule = await _context.BotSchedule.FindAsync(id);
            if (botSchedule == null)
            {
                return NotFound();
            }
            return View(botSchedule);
        }

        // POST: BotSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDay,TimeOccur,DayOccur,FrequencyOccur")] BotSchedule botSchedule)
        {
            if (id != botSchedule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(botSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BotScheduleExists(botSchedule.Id))
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
            return View(botSchedule);
        }

        // GET: BotSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var botSchedule = await _context.BotSchedule
                .FirstOrDefaultAsync(m => m.Id == id);
            if (botSchedule == null)
            {
                return NotFound();
            }

            return View(botSchedule);
        }

        // POST: BotSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var botSchedule = await _context.BotSchedule.FindAsync(id);
            _context.BotSchedule.Remove(botSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BotScheduleExists(int id)
        {
            return _context.BotSchedule.Any(e => e.Id == id);
        }

        // GET: BotSchedules/Create
        public IActionResult Scheduling()
        {
            return View();
        }

        // POST: BotSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Scheduling(BotSchedule botSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(botSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(botSchedule);
        }

        // GET: BotSchedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BotSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleViewModel ScheduleViewModel)
        {
            if (ModelState.IsValid)
            {

                BotSchedule sched = new BotSchedule();
                sched.Id = ScheduleViewModel.ID;
                sched.StartDay = ScheduleViewModel.StartDay;
                sched.TimeOccur = ScheduleViewModel.TimeOccur;
                sched.DayOccur = ScheduleViewModel.DayOccur;
                sched.FrequencyOccur = ScheduleViewModel.FrequencyOccur;
                sched.Respondents = ScheduleViewModel.Respondents;

                sched.WelcomeMsg = ScheduleViewModel.WelcomeMsg;


                _context.Add(sched);

                var SurveyId = _context.BotSchedule.ToList().LastOrDefault();

                for (int i = 0; i < ScheduleViewModel.Question.Length; i++)
                {
                    BotQuestions quest = new BotQuestions();
                    quest.BotScheduleId = sched.Id;
                    quest.Question = ScheduleViewModel.Question[i];
                    _context.Add(quest);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Scheduling));
            }
            return View(ScheduleViewModel);
        }
    }
}
