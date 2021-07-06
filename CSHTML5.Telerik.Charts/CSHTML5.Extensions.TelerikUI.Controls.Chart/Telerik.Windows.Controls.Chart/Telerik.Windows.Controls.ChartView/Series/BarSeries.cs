
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class BarSeries : CategoricalColorSeries
    {
        public override string GetChartType()
        {
            return "bar";
        }
    }
}
