﻿
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class PieSeries : CategoricalColorSeries
    {
        internal const int Angle45 = 45;

        internal const int Angle75 = 75;

        internal const int Angle105 = 105;

        internal const int Angle135 = 135;

        internal const int Angle150 = 150;

        internal const int Angle255 = 255;

        internal const int Angle225 = 225;

        internal const int Angle285 = 285;

        internal const int Angle315 = 315;

        public override string GetChartType()
        {
            return "pie";
        }

        public double StartAngle = PieSeries.Angle150;
    }
}
