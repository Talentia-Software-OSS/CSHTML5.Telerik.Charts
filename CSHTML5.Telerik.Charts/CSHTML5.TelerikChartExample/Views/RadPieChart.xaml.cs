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

    // TODO: remove chart info
    public class ChartInfo
    {
        public string Label { get; set; }
        public double Value { get; set; }
        public string Color { get; set; }
    }

    public class PlannedTimeByCycleChartViewModel : INotifyCollectionChanged, INotifyPropertyChanged
    {
        #region NotifyPropertyChanged
        event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            this.InitializeComponent();
            var items = GetSerie();
            _chartViewModel = new ChartViewModel(this, items);
        }
        #endregion


        
        //#region DependencyProperty

        //public static readonly DependencyProperty HoursByCycleDataProperty = DependencyProperty.Register("HoursByCycle", typeof(ObservableCollection<ChartInfo>), typeof(PlannedTimeByCycleChartViewModel), new PropertyMetadata(null));

        //#endregion

        //#region Fields
        //public RadObservableCollection<ChartInfo> HoursByCycle
        //{
        //    get
        //    {
        //        return (RadObservableCollection<ChartInfo>)this.GetValue(HoursByCycleDataProperty);
        //    }
        //    set
        //    {
        //        this.SetValue(HoursByCycleDataProperty, value);
        //    }
        //}
        //#endregion


        private RadObservableCollection<ChartInfo> _items;

        /// <summary>
        /// Gets or sets the process contexts.
        /// </summary>
        /// <value>The process contexts.</value>
        public RadObservableCollection<ChartInfo> Items
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
            NotifyCollectionChangedEventHandler handler = this.CollectionChanged;
            if (handler != null)
            {
                handler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }

        /// <summary>
        /// Occurs when the items list of the collection has changed, or the collection is reset.
        /// </summary>
        public event NotifyCollectionChangedEventHandler CollectionChanged;


        #region Constructors
        public PlannedTimeByCycleChartViewModel()
        {
            Items = GetSerie();
        }

        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }
        #endregion

        public static RadObservableCollection<ChartInfo> GetSerie()
        {
            RadObservableCollection<ChartInfo> serie = new RadObservableCollection<ChartInfo>();

            serie.Add(new ChartInfo() { Label = "Asia", Value = 53.8, Color = "#9de219" });
            serie.Add(new ChartInfo() { Label = "Europe", Value = 16.1, Color = "#90cc38" });
            serie.Add(new ChartInfo() { Label = "Latin America", Value = 11.3, Color = "#068c35" });
            serie.Add(new ChartInfo() { Label = "Africa", Value = 9.6, Color = "#006634" });
            serie.Add(new ChartInfo() { Label = "Middle East", Value = 5.2, Color = "#004d38" });
            serie.Add(new ChartInfo() { Label = "North America", Value = 3.6, Color = "#033939" });

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
