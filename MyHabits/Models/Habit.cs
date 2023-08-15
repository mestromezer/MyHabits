using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MyHabits.Models
{
    public class Habit
    {
        [Key]
        public int Id { get; set; } // id of habit
        [Required]
        public string _name { get; set; } // the meaning of the habit
        [DataType(DataType.Date)]
        public DateTime _date_of_end { get; set; } = DateTime.Now; // date to start with
        // //(completed at date of start + 30 days)
        public virtual List<DayOfHabit>? _registered_actions { get; set; }//days when the habit action were registered

    }
}
