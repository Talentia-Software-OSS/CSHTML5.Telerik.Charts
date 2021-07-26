using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public partial class RadPieChart : Page
    {
        public class SerieObject
        {
            public string Category { get; set; }
            public double SerieValue { get; set; }
            public string Color { get; set; }
        }

        private ChartViewModel<RadPieChart, SerieObject> _chartViewModel;

        public RadPieChart()
        {
            this.InitializeComponent();
            // create ViewModel
            var items = GetSerie();
            _chartViewModel = new ChartViewModel<RadPieChart, SerieObject>(this, items);
        }

        private void Button_Click_PieChart(object sender, RoutedEventArgs e)
        {
            // set piechart data on refresh
            ExamplePieChart.Refresh();
            ExamplePieChart2.Refresh();
        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {
            _chartViewModel.Items.Add(new SerieObject() { Category = "North africa", SerieValue = 13.6, Color = "#033939" });
        }

        public static RadObservableCollection<SerieObject> GetSerie()
        {
            RadObservableCollection<SerieObject> serie = new RadObservableCollection<SerieObject>();
            

            serie.Add(new SerieObject() { Category = "Asia", SerieValue = 53.8, Color = "#9de219" });
            serie.Add(new SerieObject() { Category = "Europe", SerieValue = 16.1, Color = "#90cc38" });
            serie.Add(new SerieObject() { Category = "Latin America", SerieValue = 11.3, Color = "#068c35" });
            serie.Add(new SerieObject() { Category = "Africa", SerieValue = 9.6, Color = "#006634" });
            serie.Add(new SerieObject() { Category = "Middle East", SerieValue = 5.2, Color = "#004d38" });
            serie.Add(new SerieObject() { Category = "North America", SerieValue = 3.6, Color = "#033939" });
            

            return serie;
        }
    }
}
