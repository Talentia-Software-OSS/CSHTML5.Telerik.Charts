
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class RadarLineSeries : PolarLineSeries
    {
        public override string GetChartType()
        {
            return ChartTypeRadarLine;
        }

        internal override string GetChartStyle()
        {
            return "";
        }
    }
}
