using System.Windows;
using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.Model;

namespace CalorieCalendarProg.View.Windows
{
    public partial class DailyStatisticsWindow : Window
    {
        public DailyStatisticsWindow(DailyLog day, UserData user)
        {
            InitializeComponent();
            ThemeManager.SetTheme(this, "Light");

            StatsText.Text = $"Összes kalória: {day.TotalCalories} kcal\n" +
                             $"BMR: {user.CalculateBMR()} kcal\n" +
                             $"Különbség: {day.TotalCalories - user.CalculateBMR()} kcal";
        }

        private void Dark_Checked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Dark");

        private void Dark_Unchecked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Light");
    }
}
