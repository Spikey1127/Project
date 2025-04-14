using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CalorieCalendarProg.ViewModel
{
    public class ThemeViewModel : INotifyPropertyChanged
    {
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
                    // A téma beállítást a nézet (Window) intézi, nem a ViewModel
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
