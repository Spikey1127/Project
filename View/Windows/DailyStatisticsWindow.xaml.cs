using System.Windows;
using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.Model;
using CalorieCalendarProg.ViewModel;

namespace CalorieCalendarProg.View.Windows
{
    public partial class DailyStatisticsWindow : Window
    {
        public DailyStatisticsWindow(DailyLog day, UserData user)
        {
            InitializeComponent();
            ThemeManager.SetTheme(this, "Light");
            DataContext = new DailyStatisticsViewModel(day, user);

        }

        private void Dark_Checked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Dark");

        private void Dark_Unchecked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Light");
    }
}
