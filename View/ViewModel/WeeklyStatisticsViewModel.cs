using CalorieCalendarProg.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace CalorieCalendarProg.ViewModel
{
    public class WeeklyStatisticsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> DailyReports { get; set; } = new();
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }

        public WeeklyStatisticsViewModel(List<DailyLog> days, double recommendedCalories)
        {
            var actualCalories = new ChartValues<int>();
            var recommendedCaloriesList = new ChartValues<int>();
            Labels = new List<string>();

            foreach (var day in days.Where(d => d.TotalCalories > 0))
            {
                var diff = day.TotalCalories - recommendedCalories;
                string status = diff > 0 ? $"+{diff} kalóriával túllépted" : $"{-diff} kalóriával kevesebbet ettél";
                DailyReports.Add($"{day.Date:dddd}: {day.TotalCalories} kcal ({status})");

                actualCalories.Add(day.TotalCalories);
                recommendedCaloriesList.Add((int)recommendedCalories);
                Labels.Add(day.Date.ToString("dddd"));
            }

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Kalóriabevitel",
                    Values = actualCalories,
                    Fill = Brushes.SteelBlue
                },
                new ColumnSeries
                {
                    Title = "Ajánlott (BMR)",
                    Values = recommendedCaloriesList,
                    Fill = Brushes.Gray
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
