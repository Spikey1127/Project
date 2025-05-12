using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.ViewModel;
using System.Windows;

namespace CalorieCalendarProg.View.Windows
{
    public partial class UserProfileWindow : Window
    {
        public UserProfileWindow()
        {
            InitializeComponent();
            DataContext = new UserProfileViewModel(); 
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = (UserProfileViewModel)DataContext;

            if (string.IsNullOrWhiteSpace(vm.Gender) || vm.Age <= 0 || vm.HeightCm <= 0 || vm.WeightKg <= 0)
            {
                MessageBox.Show("Tölts ki minden mezőt!");
                return;
            }

            var user = new Model.UserData
            {
                Age = vm.Age,
                Gender = vm.Gender,
                HeightCm = vm.HeightCm,
                WeightKg = vm.WeightKg
            };

            string theme = (DarkModeCheckBox.IsChecked == true) ? "Dark" : "Light";

            var main = new CalorieCalendarProg.View.MainWindow(user, theme);
            Application.Current.MainWindow = main;
            main.Show();
            this.Close();
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
