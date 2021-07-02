using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public class ChartViewModel<TChartPage, TChartSeries> : NotifierBase 
        where TChartPage: Page
    {
        public ChartViewModel(TChartPage page, RadObservableCollection<TChartSeries> items)
        {
            page.DataContext = this;
            //page.ExamplePieChart.DataContext = this;
            //page.ExamplePieChart.Series[0].DataContext = this;
            this.Items = items;
        }

        RadObservableCollection<TChartSeries> _items = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
    }

}
