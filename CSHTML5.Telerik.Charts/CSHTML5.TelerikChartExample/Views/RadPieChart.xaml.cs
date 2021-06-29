using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class PieSerieObj
    {
        public string Category { get; set; }
        public double Value { get; set; }
        public string Color { get; set; }
    }

    public partial class RadPieChart : Page
    {

        private ChartViewModel _chartViewModel;

        public RadPieChart()
        {
            this.InitializeComponent();
            var items = GetSerie();
            _chartViewModel = new ChartViewModel(this, items);
        }

        private void Button_Click_PieChart(object sender, RoutedEventArgs e)
        {
             // set piechart data on refresh
            ExamplePieChart.Refresh();
        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {            
            _chartViewModel.Items.Add(new PieSerieObj() { Category = "North africa", Value = 13.6, Color = "#033939" });
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

    public class ChartViewModel : NotifierBase
    {
        public ChartViewModel(RadPieChart page, RadObservableCollection<PieSerieObj> items)
        {
            page.DataContext = this;
            //page.ExamplePieChart.DataContext = this;
            page.ExamplePieChart.Series[0].DataContext = this;
            this.Items = items;
        }

        RadObservableCollection<PieSerieObj> _items = new RadObservableCollection<PieSerieObj>();
        public RadObservableCollection<PieSerieObj> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }
    }

    public class NotifierBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Fires the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            // work on a local (threadsafe between the if and the call)
            PropertyChangedEventHandler handler = _propertyChangedHandler;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        PropertyChangedEventHandler _propertyChangedHandler;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { _propertyChangedHandler += value; }
            remove { _propertyChangedHandler -= value; }
        }
    }

}
