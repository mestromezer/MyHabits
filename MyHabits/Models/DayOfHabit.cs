using System.ComponentModel.DataAnnotations;

namespace MyHabits.Models
{
    public class DayOfHabit
    {
        [Key]
        public int Id { get; set; }
        public DateTime _date { get; set; }
        public bool _if_action { get; set; }
    }
}
