using System.ComponentModel.DataAnnotations.Schema;

namespace MyHabits.Models
{
    public class DatesOfHabit
    {
        private readonly Dictionary<DateTime, bool> _dates_of_habit;
        public DatesOfHabit()
        {
            _dates_of_habit = new Dictionary<DateTime, bool>();
        }
        public DatesOfHabit(DateTime date_of_start)
        {
            _dates_of_habit = FindoutDates(date_of_start);
            foreach(var date in _dates_of_habit) 
                Console.WriteLine($"{date.Key.Date.ToShortDateString()} : {date.Value}");
        }
        private Dictionary<DateTime, bool> FindoutDates(DateTime date_of_start)
        {
            var curretn_date = date_of_start;

            var days = new Dictionary<DateTime, bool>();

            int days_c = 0;

            while (days_c < 30)
            {
                days[curretn_date.Date] = false; days_c++;
                curretn_date = curretn_date.AddDays(1);
            }

            return days;
        }
        public IEnumerable<bool> ThisWeekChecksPoints()
        {
            var today = DateTime.Today;

            while (today.DayOfWeek != System.DayOfWeek.Monday)
            {
                today = today.AddDays(-1);
            }

            do
            {
                yield return _dates_of_habit[today.Date];
                today = today.AddDays(1);
            } while (today.Date.DayOfWeek != System.DayOfWeek.Monday);
        }
    }
}
