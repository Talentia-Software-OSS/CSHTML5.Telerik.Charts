using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public partial class RadPieChart : Page
    {
        public class PieSerieObj
        {
            public string Category { get; set; }
            public double Value { get; set; }
            public string Color { get; set; }
        }

        RadObservableCollection<PieSerieObj> ChartBindedSerie = GetSerie();

        public RadPieChart()
        {
            this.InitializeComponent();
        }

        private void Button_Click_PieChart(object sender, RoutedEventArgs e)
        {
            ExamplePieChart.Series[0].ItemsSource = ChartBindedSerie;
            // set piechart data on refresh
            ExamplePieChart.Refresh();
        }

        private static RadObservableCollection<PieSerieObj> GetSerie()
        {
            RadObservableCollection<PieSerieObj> serie = new RadObservableCollection<PieSerieObj>();
            
            serie.Add(new PieSerieObj() { Category = "Asia", Value = 53.8, Color = "#9de219" });
            serie.Add(new PieSerieObj() { Category = "Europe", Value = 16.1, Color = "#90cc38" });
            serie.Add(new PieSerieObj() { Category = "Latin America", Value = 11.3, Color = "#068c35" });
            serie.Add(new PieSerieObj() { Category = "Africa", Value = 9.6, Color = "#006634" });
            serie.Add(new PieSerieObj() { Category = "Middle East", Value = 5.2, Color = "#004d38" });
            serie.Add(new PieSerieObj() { Category = "North America", Value = 3.6, Color = "#033939" });

            return serie;
        }
    }
}
