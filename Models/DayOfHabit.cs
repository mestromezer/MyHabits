using System.ComponentModel.DataAnnotations;

namespace MyHabits.Models
{
    public class DayOfHabit
    {
        [Key]
        // Id of the day.
        public int Id { get; set; }
        // Date of the day.
        public DateTime _date { get; set; }
    }
}
