using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalendarProg.Model
{
    public class UserData
    {
        public int Age { get; set; }
        public double HeightCm { get; set; } // cm
        public double WeightKg { get; set; } // kg
        public string Gender { get; set; } // "Male" or "Female"

        // Alap kalóriaszükséglet kiszámítása (BMR) – Mifflin-St Jeor képlet
        public double CalculateBMR()
        {
            if (Gender == "Férfi")
            {
                return 10 * WeightKg + 6.25 * HeightCm - 5 * Age + 5;
            }
            else if (Gender == "Nő")
            {
                return 10 * WeightKg + 6.25 * HeightCm - 5 * Age - 161;
            }
            else
            {
                throw new InvalidOperationException("Érvénytelen");
            }
        }
    }
}
