using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyHabits.Data;
using MyHabits.Models;
using System.Diagnostics;

namespace MyHabits.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyHabitsContext _context; // Database
    static public DateTime FindDateOfMonday(System.DayOfWeek day_of_week)
    {
        // Returns date of current week's first day (monday)
        var today = DateTime.Today;
        while (today.DayOfWeek != day_of_week)
        {
            today = today.AddDays(-1);
        }
        return today.Date;
    }

    public HomeController(ILogger<HomeController> logger, MyHabitsContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var dates = new List<DateTime>();
        var monday = FindDateOfMonday(System.DayOfWeek.Monday);
        for (var i = 0; i < 7; i++)
        {
            dates.Add(monday.AddDays(i));
        }
        IEnumerable<Habit>? data = await _context.Habit.ToListAsync();
        ViewBag.dates = dates;
        return View(data);
    }
    public IActionResult Create() => View();

    [HttpPost]
    // CSS protection.
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("_id,_name")] Habit habit)
    {
        if (ModelState.IsValid)
        {
            habit.RegisteredActions = new List<DayOfHabit>();

            _context.Add(habit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(habit);
    }
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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,_name")] Habit habit)
    {
        if (id != habit.Id)
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
                if (!HabitExists(habit.Id))
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
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Habit == null)
        {
            return NotFound();
        }
        var habit = await _context.Habit
            .FirstOrDefaultAsync(m => m.Id == id);
        if (habit == null)
        {
            return NotFound();
        }
        return View(habit);
    }

    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Habit == null)
        {
            return Problem(
                "Entity set 'MyHabitsContext.Habit'  is null."
                );
        }
        var habit = await _context.Habit.FindAsync(id);
        if (habit != null)
        {
            _context.Habit.Remove(habit);
        }
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool HabitExists(int id) =>
        (_context.Habit?.Any(e => e.Id == id)).GetValueOrDefault();
    public async Task<IActionResult> Register() => _context.Habit != null ?
                    View(await _context.Habit.ToListAsync()) :
                    Problem("Entity set 'MyHabitsContext.Habit'  is null.");
    public async Task<IActionResult> RegisterAction(int id)
    {
        if (_context.Habit == null)
        {
            NotFound();
        }

        var to_reg_habit = await _context.Habit.FindAsync(id);

        if (to_reg_habit == null)
            throw new Exception("Can't find the habit");

        var day = new DayOfHabit()
        {
            Date = DateTime.Today
        };

        if (to_reg_habit.RegisteredActions == null)
            throw new Exception("List of registered actions was not initialized");

        to_reg_habit.RegisteredActions.Add(day);

        if (day.Date == to_reg_habit.DateOfEnd)
        {
            try
            {
                ViewData["_name_of_deleted"] = to_reg_habit.Name;
                _context.Remove(to_reg_habit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Could not update data to database");
            }
            return View(to_reg_habit);
        }
        else
        {
            try
            {
                _context.Update(to_reg_habit);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new Exception("Could not update data to database");
            }
            return View();
        }
    }
    public IActionResult Privacy() =>
        View();

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true
        )]
    public IActionResult Error() =>
        View(
            new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            });
}