using System.IO;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using DevExpress.Utils;
using DevExpress.XtraCharts;
using DevExpress.XtraPrinting;

namespace ChartConsole {
    class Program {
        const string OutputPath = "Output";

        static void Main(string[] args) {
            using(ChartContainer container = new ChartContainer()) {
                container.Size = new Size(500, 500);
                container.Chart.Titles.Add(new ChartTitle() { Text = "Linux OpenGL test very very long title a b c aaaaaaaaaaaaaaaaaaa bbbbbbbbbbbbbbbbbbbb cccccccccccccccccccccc dddddddddddddddddddddddddddddd"});
                container.Chart.Titles[0].WordWrap = true;
                container.Chart.Titles[0].Alignment = StringAlignment.Near;
                Random random = new Random(0);
                container.Chart.Legend.Visibility = DefaultBoolean.False;
                for (int i = 0; i < 1; i++) {
                    Series series = new Series("Series", ViewType.Pie);
                    series.Label.TextPattern = "{S} : {A} : {V} : {VP}";
                    PieSeriesView view = (PieSeriesView)series.View;
                    view.MinAllowedSizePercentage = 80;
                    for (int j = 0; j < 10; j++) {
                        series.Points.Add(new SeriesPoint(j.ToString() + " Long Argument", random.Next(100)));
                    }
                    container.Chart.Series.Add(series);
                }

                if (!Directory.Exists(OutputPath))
                    Directory.CreateDirectory(OutputPath);

                container.Chart.ExportToImage(OutputPath + "/Test.png", ImageFormat.Png);
                PdfExportOptions options = new PdfExportOptions();
                options.ConvertImagesToJpeg = false;
                container.Chart.ExportToPdf(OutputPath + "/Test.pdf", options);

                Console.WriteLine("Done.");
            }
        }
    }
}
