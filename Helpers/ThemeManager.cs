using System.Windows;

namespace CalorieCalendarProg.Helpers
{
    public static class ThemeManager
    {
        public static void SetTheme(Window window, string theme)
        {
            var dict = new ResourceDictionary();

            switch (theme)
            {
                case "Dark":
                    dict.Source = new System.Uri("Resources/DarkTheme.xaml", System.UriKind.Relative);
                    break;
                default:
                    dict.Source = new System.Uri("Resources/LightTheme.xaml", System.UriKind.Relative);
                    break;
            }

            window.Resources.MergedDictionaries.Clear();
            window.Resources.MergedDictionaries.Add(dict);
        }
    }
}
