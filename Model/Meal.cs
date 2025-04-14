using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalendarProg.Model
{
    public class Meal
    {
        public string Name { get; set; }
        public int Calories { get; set; }
        public DateTime Time { get; set; } = DateTime.Now;
    }
}
