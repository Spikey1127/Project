using CalorieCalendarProg.View;
using System.Windows;
using CalorieCalendarProg.View.Windows;


namespace CalorieCalendarProg
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var profileWindow = new UserProfileWindow();
            profileWindow.Show();
        }
    }
}
