using System;
using System.Drawing.Imaging;
using DevExpress.XtraCharts;

namespace ChartConsole {
    class Program {
        static void Main(string[] args) {
            using(ChartContainer container = new ChartContainer()) {
                container.Chart.Titles.Add(new ChartTitle() { Text = "Linux OpenGL test" });
                Random random = new Random();
                for(int i = 0; i < 5; i++){
                    Series series = new Series("Series", ViewType.Area3D);
                    for(int j = 0; j < 20; j++) {
                        series.Points.Add(new SeriesPoint(j, random.Next(100)));
                    }
                    container.Chart.Series.Add(series);
                }
                container.Chart.ExportToImage("Test.png", ImageFormat.Png);
            }
        }
    }
}
