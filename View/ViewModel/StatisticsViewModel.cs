using CalorieCalendarProg.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCalendarProg.ViewModel
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {
        private readonly WeekLog _weekLog;
        private readonly double _recommendedCalories;

        public ObservableCollection<DailyLog> DailyLogs { get; set; }
        public ObservableCollection<string> DailyReports { get; set; } = new();

        public StatisticsViewModel(WeekLog weekLog, double recommendedCalories)
        {
            _weekLog = weekLog;
            _recommendedCalories = recommendedCalories;
            DailyLogs = new ObservableCollection<DailyLog>(_weekLog.DailyLogs);
            GenerateReports();
        }

        private void GenerateReports()
        {
            foreach (var day in _weekLog.DailyLogs)
            {
                var diff = day.TotalCalories - _recommendedCalories;
                string status = diff > 0 ? $"+{diff} kalóriával túllépted" : $"{Math.Abs(diff)} kalóriával kevesebbet ettél";
                DailyReports.Add($"{day.Date:dddd}: {day.TotalCalories} kcal ({status})");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
