using System.ComponentModel.DataAnnotations;

namespace MyHabits.Models
{
    public class CreateHabitViewModel
    {
        [Required]
        public System.DayOfWeek day_of_week;
        [Required]
        public  string _name;
    }
}
