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
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty TrackBallInfoTemplateProperty = DependencyProperty.Register("TrackBallInfoTemplateProperty", typeof(DataTemplate), typeof(ChartSeries), null);
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSourceProperty", typeof(IEnumerable), typeof(ChartSeries), new PropertyMetadata(null, OnItemsSource_Changed));

        private ObservableCollection<ChartSeriesLabelDefinition> labelDefinitions;
        public ObservableCollection<ChartSeriesLabelDefinition> LabelDefinitions => labelDefinitions;

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
            return "line";
        }

        private static void OnItemsSource_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ChartSeries)d).ParentChart.Refresh();
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
