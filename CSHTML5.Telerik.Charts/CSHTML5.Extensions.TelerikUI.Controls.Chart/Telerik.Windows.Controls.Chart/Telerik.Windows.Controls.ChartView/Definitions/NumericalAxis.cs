//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.Windows;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public abstract class NumericalAxis : ChartAxis
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("MaximumProperty", typeof(double), typeof(NumericalAxis), null);
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("MinimumProperty", typeof(double), typeof(NumericalAxis), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public double Maximum
        {
            get { return (double)this.GetValue(NumericalAxis.MaximumProperty); }
            set { this.SetValue(NumericalAxis.MaximumProperty, (object)value); }
        }

        public double Minimum
        {
            get { return (double)this.GetValue(NumericalAxis.MinimumProperty); }
            set { this.SetValue(NumericalAxis.MinimumProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected NumericalAxis()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
