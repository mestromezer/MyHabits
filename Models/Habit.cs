using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MyHabits.Models
{
    public class Habit
    {
        [Key]
        // Id of habit.
        public int Id { get; set; } 
        [Required]
        // The meaning of the habit.
        public string _name { get; set; } 
        [DataType(DataType.Date)]
        // Date to start with.
        // Habit will be completed at date of start + 30 days.
        public DateTime _date_of_end { get; set; } = DateTime.Now;
        // Days when the habit action were registered.
        public virtual List<DayOfHabit>? _registered_actions { get; set; }
    }
}
