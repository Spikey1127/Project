using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieCalendarProg.Helpers;

namespace CalorieCalendarProg.Model
{
    public class WeekLog
    {
        public List<DailyLog> DailyLogs { get; set; } = new();

        public WeekLog()
        {
            // Alapból hét nap üres naplóval
            for (int i = 0; i < 7; i++)
            {
                DailyLogs.Add(new DailyLog { Date = DateTime.Today.StartOfWeek().AddDays(i) });
            }
        }

        public int WeeklyTotal => DailyLogs.Sum(d => d.TotalCalories);
    }

}
