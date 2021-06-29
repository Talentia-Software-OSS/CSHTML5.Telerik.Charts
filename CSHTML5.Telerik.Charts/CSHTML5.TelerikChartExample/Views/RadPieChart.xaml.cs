using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    public partial class RadPieChart : Page
    {
        private PlannedTimeByCycleChartViewModel _plannedTimeByCycleChartViewModel = new PlannedTimeByCycleChartViewModel();
        public RadPieChart()
        {
            InitializeComponent();
            
            this.DataContext = _plannedTimeByCycleChartViewModel;
        }
        
        private void Button_Click_PieChart(object sender, RoutedEventArgs e)
        {
            //ExamplePieChart.Series[0].ItemsSource = ChartBindedSerie;
            // set piechart data on refresh
            //_plannedTimeByCycleChartViewModel.HoursByCycle = PlannedTimeByCycleChartViewModel.GetSerie();
            this.DataContext = _plannedTimeByCycleChartViewModel;
            ExamplePieChart.Refresh();
        }

    }

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
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
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
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
                OnCollectionChanged();
            }
        }

        private void OnCollectionChanged()
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

}
