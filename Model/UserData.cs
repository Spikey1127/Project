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
        public double HeightCm { get; set; }
        public double WeightKg { get; set; }
        public string Gender { get; set; } 

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
