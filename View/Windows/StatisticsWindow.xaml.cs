using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.Model;
using CalorieCalendarProg.ViewModel;
using System.Windows;
using CalorieCalendarProg.Helpers;

namespace CalorieCalendarProg.View.Windows
{
    public partial class StatisticsWindow : Window
    {
        public StatisticsWindow(WeekLog weekLog, double recommendedCalories)
        {
            InitializeComponent();
            DataContext = new StatisticsViewModel(weekLog, recommendedCalories); // Ő tartalmazza az IsDarkMode-t
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
