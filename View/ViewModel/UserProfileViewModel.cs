using CalorieCalendarProg.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CalorieCalendarProg.ViewModel
{
    public class UserProfileViewModel : UserData
    {
        public ICommand SaveCommand { get; }

        public UserProfileViewModel()
        {
            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object obj)
        {
            if (string.IsNullOrWhiteSpace(Gender) || Age <= 0 || HeightCm <= 0 || WeightKg <= 0)
            {
                MessageBox.Show("Kérlek, tölts ki minden mezőt helyesen.");
                return;
            }

            Application.Current.Properties["UserData"] = this;

            if (obj is Window window)
            {
                window.Close(); 
            }

            var main = new CalorieCalendarProg.View.MainWindow(new UserData
            {
                Age = Age,
                Gender = Gender,
                HeightCm = HeightCm,
                WeightKg = WeightKg
            });

            main.Show();
        }



    }
}

