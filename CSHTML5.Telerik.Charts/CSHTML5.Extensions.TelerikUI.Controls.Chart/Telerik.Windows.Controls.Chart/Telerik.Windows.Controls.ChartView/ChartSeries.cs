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
        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSourceProperty", typeof(IEnumerable), typeof(ChartSeries), null);
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
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected ChartSeries()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
