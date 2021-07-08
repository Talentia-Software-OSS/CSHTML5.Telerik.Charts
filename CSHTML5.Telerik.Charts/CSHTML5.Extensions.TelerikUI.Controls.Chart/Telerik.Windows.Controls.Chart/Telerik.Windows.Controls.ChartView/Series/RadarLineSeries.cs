
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class RadarLineSeries : CategoricalStrokedSeries
    {
        internal const string ChartStyleSmooth= "smooth";

        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty ShowLabelsProperty = DependencyProperty.Register("ShowLabelsProperty", typeof(RadarLineSeries), typeof(bool), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public DataPointBinding ShowLabels
        {
            get { return (DataPointBinding)this.GetValue(RadarLineSeries.ShowLabelsProperty); }
            set { this.SetValue(RadarLineSeries.ShowLabelsProperty, (object)value); }
        }

        public override string GetChartType()
        {
            return ChartTypePolarLine;
        }

        internal string GetChartStyle()
        {
            return ChartStyleSmooth;
        }
    }
}
