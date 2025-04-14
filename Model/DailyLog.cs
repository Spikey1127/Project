using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalendarProg.Model
{
    public class DailyLog : INotifyPropertyChanged
    {
        public DateTime Date { get; set; }

        public ObservableCollection<Meal> Meals { get; set; } = new();

        public int TotalCalories => Meals.Sum(m => m.Calories);

        public void AddMeal(Meal meal)
        {
            Meals.Add(meal);
            OnPropertyChanged(nameof(TotalCalories));
        }

        public override string ToString() => Date.ToString("dddd");

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
