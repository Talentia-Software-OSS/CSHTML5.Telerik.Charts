using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public class CartesianChartViewModel<TChartPage, TChartSeries> : PolarChartViewModel<TChartPage, TChartSeries>
        where TChartPage : Page
    {
        RadObservableCollection<TChartSeries> _series4 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series4
        {
            get { return _series4; }
            set { _series4 = value; OnPropertyChanged("Series4"); }
        }

        public CartesianChartViewModel(
            TChartPage page, 
            RadObservableCollection<TChartSeries> series1,
            RadObservableCollection<TChartSeries> series2,
            RadObservableCollection<TChartSeries> series3,
            RadObservableCollection<TChartSeries> series4
        ) : base(page, series1, series2, series3)
        {
            this.Series4 = series4;
        }
    }
}
