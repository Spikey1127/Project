using CalorieCalendarProg.Model;
using LiveCharts.Wpf;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CalorieCalendarProg.ViewModel
{
    public class DailyStatisticsViewModel
    {
        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }

        public DailyStatisticsViewModel(DailyLog day, UserData user)
        {
            int bmr = (int)user.CalculateBMR();
            int actual = day.TotalCalories;

            // Színezés
            Brush barColor = GetColor(actual, bmr);

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Kalóriabevitel",
                    Values = new ChartValues<int> { actual },
                    Fill = barColor
                },
                new ColumnSeries
                {
                    Title = "Ajánlott (BMR)",
                    Values = new ChartValues<int> { bmr },
                    Fill = Brushes.Gray
                }
            };

            Labels = new List<string> { day.Date.ToString("dddd") };
        }

        private Brush GetColor(int actual, int bmr)
        {
            if (actual > bmr + 200)
                return Brushes.Red; // 🟥 túllépés
            if (actual < bmr - 200)
                return Brushes.Goldenrod; // ⚠️ alulmúlás
            return Brushes.Green; // 🟩 optimális
        }
    }
}
