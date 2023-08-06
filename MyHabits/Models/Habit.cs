using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Text.Json;

namespace MyHabits.Models
{
    public class Habit
    {
        //each habit is meant to be done daily
        [Key]
        public int _id { get; set; } // id of habit
        [Required]
        public string _name { get; set; } // the meaning of the habit
        [DataType(DataType.Date)] // date to start with
        public DateTime _date_of_start { get; set; }// //(completed at date of start + 1 month)
    }
}
