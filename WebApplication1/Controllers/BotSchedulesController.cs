using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StandUpConceirge.Models.DB;
using StandUpConceirge.Models;
using static StandUpConceirge.Models.ScheduleViewModel;

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
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            var respondentsList = _context.BotUsers.ToList();
            var dropdownRespondentsList = new List<SelectListItem>();
            foreach (var respondents in respondentsList)
            {
                dropdownRespondentsList.Add(new SelectListItem { Value = respondents.Id.ToString(), Text = respondents.Name.ToString() });
            }
            ViewBag.RespondentsList = dropdownRespondentsList;

            //return View(await _context.BotSchedule.ToListAsync());
            return View();
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
            var respondentsList = _context.BotUsers.ToList();
            var dropdownRespondentsList = new List<SelectListItem>();
            foreach (var users in respondentsList)
            {
                dropdownRespondentsList.Add(new SelectListItem { Value = users.Name.ToString(), Text = users.Name.ToString() });
            }
            ViewBag.respondentsList = dropdownRespondentsList;
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
                var schedID = _context.BotSchedule.ToList().Count();
                for (int j = 0; j < ScheduleViewModel.Respondents.Length; j++)
                {
                    BotSchedule sched = new BotSchedule();
                    sched.Id = ScheduleViewModel.ID;
                    sched.StartDay = ScheduleViewModel.StartDay;
                    sched.TimeOccur = ScheduleViewModel.TimeOccur;

                    sched.Monday = ScheduleViewModel.Monday.ToString().Substring(0, 1);
                    sched.Tuesday = ScheduleViewModel.Tuesday.ToString().Substring(0, 1);
                    sched.Wednesday = ScheduleViewModel.Monday.ToString().Substring(0, 1);
                    sched.Thursday = ScheduleViewModel.Thursday.ToString().Substring(0, 1);
                    sched.Friday = ScheduleViewModel.Friday.ToString().Substring(0, 1);
                    sched.Saturday = ScheduleViewModel.Saturday.ToString().Substring(0, 1);
                    sched.Sunday = ScheduleViewModel.Sunday.ToString().Substring(0, 1);

                    sched.Creator = "Chris";
                    sched.ScheduleId = schedID;

                    sched.FrequencyOccur = ScheduleViewModel.FrequencyOccur;
                    sched.WelcomeMsg = ScheduleViewModel.WelcomeMsg;
                    sched.Respondents = ScheduleViewModel.Respondents[j];

                    _context.Add(sched);
                    await _context.SaveChangesAsync();
                }

                for (int i = 0; i < ScheduleViewModel.Question.Length; i++)
                {

                    BotQuestions quest = new BotQuestions();
                    quest.BotScheduleId = schedID;
                    quest.Question = ScheduleViewModel.Question[i];
                    _context.Add(quest);
                    await _context.SaveChangesAsync();
                }

                //var SurveyId = _context.BotSchedule.ToList().LastOrDefault();



                return RedirectToAction(nameof(Scheduling));
            }
            return View(ScheduleViewModel);
        }
    }
}
