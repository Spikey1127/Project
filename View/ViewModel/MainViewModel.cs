using CalorieCalendarProg.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using CalorieCalendarProg.View.Windows;
using CalorieCalendarProg.View;

namespace CalorieCalendarProg.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public UserData User { get; set; } = new();
        public WeekLog WeeklyLog { get; set; } = new();

        private DailyLog _selectedDay;
        public DailyLog SelectedDay
        {
            get => _selectedDay;
            set { _selectedDay = value; OnPropertyChanged(); }
        }

        public ICommand AddMealCommand { get; set; }
        public ICommand OpenDailyStatsCommand { get; set; }
        public ICommand OpenWeeklyStatsCommand { get; set; }

        private bool _isDarkTheme;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set
            {
                if (_isDarkTheme != value)
                {
                    _isDarkTheme = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainViewModel(UserData user)
        {
            User = user;
            WeeklyLog = new WeekLog();
            SelectedDay = WeeklyLog.DailyLogs.FirstOrDefault();

            AddMealCommand = new RelayCommand(AddMeal);
            OpenDailyStatsCommand = new RelayCommand(_ => OpenDailyStats());
            OpenWeeklyStatsCommand = new RelayCommand(_ => OpenWeeklyStats());
        }

        private void AddMeal(object obj)
        {
            var window = new AddMealWindow();
            bool? result = window.ShowDialog();

            if (result == true && window.NewMeal != null && SelectedDay != null)
            {
                SelectedDay.AddMeal(window.NewMeal);
                OnPropertyChanged(nameof(SelectedDay));
            }
        }

        private void OpenDailyStats()
        {
            if (SelectedDay == null) return;
            var window = new DailyStatisticsWindow(SelectedDay, User);
            window.ShowDialog();
        }

        private void OpenWeeklyStats()
        {
            var daysWithData = WeeklyLog.DailyLogs
                .Where(d => d.Meals.Any())
                .ToList();

            if (!daysWithData.Any())
            {
                MessageBox.Show("Nincs elegendő adat a heti statisztikához.");
                return;
            }

            var window = new WeeklyStatisticsWindow(daysWithData, User.CalculateBMR());
            window.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
