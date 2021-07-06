
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class CategoricalColorSeries : CategoricalSeries
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty ColorBindingProperty = DependencyProperty.Register("ColorBindingProperty", typeof(DataPointBinding), typeof(BarSeries), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public DataPointBinding ColorBinding
        {
            get { return (DataPointBinding)this.GetValue(BarSeries.ColorBindingProperty); }
            set { this.SetValue(BarSeries.ColorBindingProperty, (object)value); }
        }
    }
}
