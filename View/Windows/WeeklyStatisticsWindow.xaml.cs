using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.Model;
using CalorieCalendarProg.ViewModel;
using System.Collections.Generic;
using System.Windows;
using CalorieCalendarProg.Helpers;

namespace CalorieCalendarProg.View.Windows
{
    public partial class WeeklyStatisticsWindow : Window
    {
        public WeeklyStatisticsWindow(List<DailyLog> days, double recommendedCalories)
        {
            InitializeComponent();
            DataContext = new WeeklyStatisticsViewModel(days, recommendedCalories); // Ő is tartalmazza az IsDarkMode-t
        }

        private void DarkModeCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            ThemeManager.SetTheme(this, "Dark");
        }

        private void DarkModeCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            ThemeManager.SetTheme(this, "Light");
        }


    }
}
