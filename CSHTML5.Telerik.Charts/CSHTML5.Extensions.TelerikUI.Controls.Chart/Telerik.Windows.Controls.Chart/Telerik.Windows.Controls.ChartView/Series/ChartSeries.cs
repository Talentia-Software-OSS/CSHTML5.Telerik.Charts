//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Charting;
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Markup;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    //-------------------------------------//
    //------------ ATTRIBUTES -------------//
    //-------------------------------------//
    [ContentProperty("DataPoints")]
    public abstract class ChartSeries : ChartElementPresenter, IChartElementPresenter
    {
        internal const string ChartTypePie = "pie";
        internal const string ChartTypeBar = "bar";
        internal const string ChartTypeLine = "line";
        internal const string ChartTypeArea = "area";
        internal const string ChartTypePolarLine = "polarLine";

        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty TrackBallInfoTemplateProperty = DependencyProperty.Register("TrackBallInfoTemplateProperty", typeof(DataTemplate), typeof(ChartSeries), null);
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSourceProperty", typeof(IEnumerable), typeof(ChartSeries), new PropertyMetadata(null, OnItemsSource_Changed));

        //private ObservableCollection<ChartSeriesLabelDefinition> labelDefinitions;
        //public ObservableCollection<ChartSeriesLabelDefinition> LabelDefinitions => labelDefinitions;

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public DataTemplate TrackBallInfoTemplate
        {
            get { return (DataTemplate)this.GetValue(ChartSeries.TrackBallInfoTemplateProperty); }
            set { this.SetValue(ChartSeries.TrackBallInfoTemplateProperty, (object)value); }
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)this.GetValue(ChartSeries.ItemsSourceProperty); }
            set { this.SetValue(ChartSeries.ItemsSourceProperty, (object)value); }
        }

        /// <summary>
        /// Contains the Chart that will display this series.
        /// </summary>
        public RadChartBase ParentChart { get; set; }

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected ChartSeries()
        {
        }

        public virtual string GetChartType()
        {
            return ChartTypeLine;
        }

        IEnumerable _dataSource;
        public IEnumerable DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                _dataSource = value;
                INotifyCollectionChanged notifyingDataSource = _dataSource as INotifyCollectionChanged;
                if (notifyingDataSource != null)
                {
                    notifyingDataSource.CollectionChanged += new NotifyCollectionChangedEventHandler(NotifyingDataSource_CollectionChanged);
                }
            }
        }

        private static void OnItemsSource_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var chartSeries = d as ChartSeries;
            if (d != null)
            {
                chartSeries.DataSource = (IEnumerable)e.NewValue;
                if (chartSeries.ParentChart.IsLoaded)
                {
                    chartSeries.ParentChart.Refresh();
                }
            }
        }

        private void NotifyingDataSource_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ParentChart.Refresh();
        }

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
