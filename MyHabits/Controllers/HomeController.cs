using Microsoft.AspNetCore.Mvc;
using MyHabits.Models;
using System.Diagnostics;

namespace MyHabits.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<MyHabits.Models.HabitModel> db;// Create database

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Monday()
        {
            if (db != null)
            {
                var data = from elem in db
                           where elem.DayOfWeek == System.DayOfWeek.Monday
                           select elem;
                return View(data);
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateHabit()=>View();
        [HttpPost]
        public async Task<IActionResult> CreateHabit(CreateHabitViewModel model)
        {
            db.Add(new HabitModel(model._name, model.day_of_week));
            return View();
        }
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