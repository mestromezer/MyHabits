using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHabits.Data;
using MyHabits.Models;
using System.Diagnostics;

namespace MyHabits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<Habit> habits;
        static public DateTime FindDate(System.DayOfWeek day_of_week)
        {
            var today = DateTime.Today;
            while (today.DayOfWeek != day_of_week) { today = today.AddDays(-1); }
            return today.Date;
        }

        public HomeController(ILogger<HomeController> logger, MyHabitsContext context)
        {
            _logger = logger;
            _context = context;
            //_jsonFileHabitService = jsonFileHabitService;
        }

        private readonly MyHabitsContext _context;

        /*public HabitsController(MyHabitsContext context)
        {
            _context = context;
        }*/

        // GET: Habits
        public async Task<IActionResult> Index()
        {
            var dates = new List<DateTime>();
            var monday = FindDate(System.DayOfWeek.Monday);
            for (int i = 0; i < 7; i++)
            {
                dates.Add(monday.AddDays(i));
            }
            ViewBag.dates = dates;
            return _context.Habit != null ?
                        View(await _context.Habit.ToListAsync()) :
                        Problem("Entity set 'MyHabitsContext.Habit'  is null.");
        }

        // GET: Habits/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Habit == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit
                .FirstOrDefaultAsync(m => m._id == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // GET: Habits/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("_id,_name,_date_of_start")] Habit habit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habit);
        }

        // GET: Habits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Habit == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit.FindAsync(id);
            if (habit == null)
            {
                return NotFound();
            }
            return View(habit);
        }

        // POST: Habits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("_id,_name,_date_of_start")] Habit habit)
        {
            if (id != habit._id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabitExists(habit._id))
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
            return View(habit);
        }

        // GET: Habits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Habit == null)
            {
                return NotFound();
            }

            var habit = await _context.Habit
                .FirstOrDefaultAsync(m => m._id == id);
            if (habit == null)
            {
                return NotFound();
            }

            return View(habit);
        }

        // POST: Habits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Habit == null)
            {
                return Problem("Entity set 'MyHabitsContext.Habit'  is null.");
            }
            var habit = await _context.Habit.FindAsync(id);
            if (habit != null)
            {
                _context.Habit.Remove(habit);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabitExists(int id)
        {
            return (_context.Habit?.Any(e => e._id == id)).GetValueOrDefault();
        }

        /*public IActionResult Index()
        {
            
            return View();
        }*/
        public IActionResult HabitOptions(int id)
        {
            var habit = habits.Where(el => el._id == id);
            return View(habit);
        }
        [HttpGet]
        public IActionResult CreateHabit()=>View();
        [HttpPost]
        /*public IActionResult CreateHabit(CreateHabitViewModel model)
        {
            //db.Add(new Habit(model._name,"random bro"));
            return View();
        }*/
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}