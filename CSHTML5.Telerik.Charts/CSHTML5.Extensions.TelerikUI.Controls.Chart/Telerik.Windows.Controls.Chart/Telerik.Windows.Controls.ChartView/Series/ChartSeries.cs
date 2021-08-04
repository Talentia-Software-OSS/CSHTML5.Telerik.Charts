//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Charting;
using System.Windows;
using System.Windows.Markup;
using System.Collections;
using System.Collections.Specialized;
using System;
using System.Windows.Media;
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
        internal const string ChartTypeColumn = "column";
        internal const string ChartTypeLine = "line";
        internal const string ChartTypeArea = "area";
        internal const string ChartTypePolarLine = "polarLine";
        internal const string ChartTypeRadarLine = "radarLine";

        public static readonly DependencyProperty SeriesNameProperty = DependencyProperty.Register("SeriesNameProperty", typeof(string), typeof(ChartSeries), null);
        public static readonly DependencyProperty KendoTooltipProperty = DependencyProperty.Register("KendoTooltipProperty", typeof(KendoTooltip), typeof(ChartSeries), null);
        public static readonly DependencyProperty KendoLabelProperty = DependencyProperty.Register("KendoLabelProperty", typeof(KendoLabel), typeof(ChartSeries), null);
        public static readonly DependencyProperty KendoBorderProperty = DependencyProperty.Register("KendoBorderProperty", typeof(KendoBorder), typeof(ChartSeries), new PropertyMetadata(KendoBorder.NoBorder));
        public static readonly DependencyProperty SeriesColorProperty = DependencyProperty.Register("SeriesColorProperty", typeof(Brush), typeof(ChartSeries), null);

        public string SeriesName
        {
            get { return (string)this.GetValue(ChartSeries.SeriesNameProperty); }
            set { this.SetValue(ChartSeries.SeriesNameProperty, (object)value); }
        }

        public KendoTooltip Tooltip
        {
            get { return (KendoTooltip)this.GetValue(ChartSeries.KendoTooltipProperty); }
            set { this.SetValue(ChartSeries.KendoTooltipProperty, (object)value); }
        }

        public KendoLabel Label
        {
            get { return (KendoLabel)this.GetValue(ChartSeries.KendoLabelProperty); }
            set { this.SetValue(ChartSeries.KendoLabelProperty, (object)value); }
        }

        public KendoBorder Border
        {
            get { return (KendoBorder)this.GetValue(ChartSeries.KendoBorderProperty); }
            set { this.SetValue(ChartSeries.KendoBorderProperty, (object)value); }
        }

        public Brush SeriesColor
        {
            get { return (Brush)this.GetValue(ChartSeries.SeriesColorProperty); }
            set { this.SetValue(ChartSeries.SeriesColorProperty, (object)value); }
        }

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
                // remove event listeneres on the old datasource
                var oldDataSource = _dataSource;
                INotifyCollectionChanged notifyingDataSource = oldDataSource as INotifyCollectionChanged;
                if (notifyingDataSource != null)
                {
                    notifyingDataSource.CollectionChanged -= new NotifyCollectionChangedEventHandler(NotifyingDataSource_CollectionChanged);
                }

                // set to the new datasource and notify change
                _dataSource = value;
                notifyingDataSource = _dataSource as INotifyCollectionChanged;
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
            if (ParentChart.IsLoaded)
                ParentChart.Refresh();
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
