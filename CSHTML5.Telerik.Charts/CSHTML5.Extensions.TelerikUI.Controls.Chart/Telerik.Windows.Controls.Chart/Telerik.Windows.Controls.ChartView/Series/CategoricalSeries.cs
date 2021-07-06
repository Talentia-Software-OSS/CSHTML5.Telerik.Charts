//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public abstract class CategoricalSeries : CategoricalSeriesBase
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty ValueBindingProperty = DependencyProperty.Register("ValueBindingProperty", typeof(DataPointBinding), typeof(CategoricalSeries), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public DataPointBinding ValueBinding
        {
            get { return (DataPointBinding)this.GetValue(CategoricalSeries.ValueBindingProperty); }
            set { this.SetValue(CategoricalSeries.ValueBindingProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected CategoricalSeries()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
