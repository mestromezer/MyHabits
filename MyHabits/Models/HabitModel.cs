using System.Diagnostics.Metrics;

namespace MyHabits.Models
{
    public class HabitModel
    {
        private readonly System.DayOfWeek day_of_week;
        public System.DayOfWeek DayOfWeek
        {
            get { return day_of_week; }
        }
        static private int counter;
        private int GenerateId()
        {
            return ++counter;
        }
        private readonly byte _id;

        public int ID
		{
			get { return _id; }
		}
        private readonly string _name;
        public string Name
        {
            get { return _name; }
        }
        public HabitModel(string name, System.DayOfWeek day_of_week)
        {
            if (name != null) { _name = name; }
            else { _name = "NO_NAME"; }

            if (counter < 200) { _id = (byte)GenerateId(); }
            else { _id = 0; } // Create Error "overloaded"

            this.day_of_week = day_of_week;
        }
    }
}
