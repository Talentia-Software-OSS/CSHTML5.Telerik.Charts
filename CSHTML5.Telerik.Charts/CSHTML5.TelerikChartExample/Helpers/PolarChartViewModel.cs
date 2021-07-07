using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public class PolarChartViewModel<TChartPage, TChartSeries> : NotifierBase
        where TChartPage : Page
    {
        RadObservableCollection<TChartSeries> _series1 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series1
        {
            get { return _series1; }
            set { _series1 = value; OnPropertyChanged("Series1"); }
        }

        RadObservableCollection<TChartSeries> _series2 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series2
        {
            get { return _series2; }
            set { _series2 = value; OnPropertyChanged("Series2"); }
        }

        RadObservableCollection<TChartSeries> _series3 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series3
        {
            get { return _series3; }
            set { _series3 = value; OnPropertyChanged("Series3"); }
        }

        public PolarChartViewModel(
            TChartPage page, 
            RadObservableCollection<TChartSeries> series1,
            RadObservableCollection<TChartSeries> series2,
            RadObservableCollection<TChartSeries> series3
        )
        {
            page.DataContext = this;

            this.Series1 = series1;
            this.Series2 = series2;
            this.Series3 = series3;
        }
    }
}
