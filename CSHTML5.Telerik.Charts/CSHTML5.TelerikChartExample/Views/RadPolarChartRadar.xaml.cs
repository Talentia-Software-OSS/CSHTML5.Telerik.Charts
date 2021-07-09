using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public partial class RadPolarChartRadar : Page
    {
        private PolarChartViewModel<RadPolarChartRadar, RadPieChart.SerieObject> _polarChartViewModel;

        public RadPolarChartRadar()
        {
            this.InitializeComponent();

            // create ViewModel
            _polarChartViewModel = new PolarChartViewModel<RadPolarChartRadar, RadPieChart.SerieObject>(
                this,
                RadPieChart.GetSerie(),
                RadPieChart.GetSerie(),
                RadPieChart.GetSerie()
            );
        }

        private void Button_Click_PolarChart(object sender, RoutedEventArgs e)
        {
            // set piechart data on refresh
            ExamplePolarChart.Refresh();
        }
    }
}