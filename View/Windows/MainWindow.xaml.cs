using CalorieCalendarProg.Model;
using CalorieCalendarProg.ViewModel;
using System.Windows;
using CalorieCalendarProg.Helpers;

namespace CalorieCalendarProg.View
{
    public partial class MainWindow : Window
    {
        public MainWindow(UserData user)
        {
            InitializeComponent();
            DataContext = new MainViewModel(user);
            ThemeManager.SetTheme(this, "Light"); // alapértelmezett világos
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
