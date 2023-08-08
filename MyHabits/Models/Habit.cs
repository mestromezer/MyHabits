using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MyHabits.Models
{
    public class Habit
    {
        public int Id { get; set; } // id of habit
        [Required]
        public string _name { get; set; } // the meaning of the habit
        /*[DataType(DataType.Date)] // date to start with
        public DateTime _date_of_start { get; set; } = DateTime.Now;*/
        // //(completed at date of start + 1 month)
        [NotMapped]
        public DatesOfHabit _dates_of_habit { get; set; } = new DatesOfHabit(DateTime.Now);
        /*Habit() 
        {
            _dates_of_habit = new DatesOfHabit(_date_of_start);
        }*/
    }
}
