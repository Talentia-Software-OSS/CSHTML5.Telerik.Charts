
using JSConversionHelpers;

namespace Telerik.Windows.Controls.ChartView
{
    public class PieSeries : CategoricalColorSeries
    {
        internal const int Angle45 = (int)JSConverters.StartAngle.Angle45;

        internal const int Angle75 = (int)JSConverters.StartAngle.Angle75;

        internal const int Angle105 = (int)JSConverters.StartAngle.Angle105;

        internal const int Angle135 = (int)JSConverters.StartAngle.Angle135;

        internal const int Angle150 = (int)JSConverters.StartAngle.Angle150;

        internal const int Angle255 = (int)JSConverters.StartAngle.Angle255;

        internal const int Angle225 = (int)JSConverters.StartAngle.Angle225;

        internal const int Angle285 = (int)JSConverters.StartAngle.Angle285;

        internal const int Angle315 = (int)JSConverters.StartAngle.Angle315;

        public override string GetChartType()
        {
            return ChartTypePie;
        }

        public double StartAngle = PieSeries.Angle150;
    }
}
