using System.Windows;
using CalorieCalendarProg.Helpers;
using CalorieCalendarProg.Model;

namespace CalorieCalendarProg.View.Windows
{
    public partial class AddMealWindow : Window
    {
        public Meal NewMeal { get; private set; }

        public AddMealWindow()
        {
            InitializeComponent();
            ThemeManager.SetTheme(this, "Light");
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameBox.Text) && int.TryParse(CaloriesBox.Text, out int cal))
            {
                NewMeal = new Meal { Name = NameBox.Text, Calories = cal };
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Hibás adat!");
            }
        }

        private void Dark_Checked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Dark");

        private void Dark_Unchecked(object sender, RoutedEventArgs e) =>
            ThemeManager.SetTheme(this, "Light");
    }
}
