//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Media;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public abstract class CategoricalStrokedSeries : CategoricalSeries
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register("StrokeProperty", typeof(Brush), typeof(CategoricalStrokedSeries), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public Brush Stroke
        {
            get { return (Brush)this.GetValue(CategoricalStrokedSeries.StrokeProperty); }
            set { this.SetValue(CategoricalStrokedSeries.StrokeProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected CategoricalStrokedSeries()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
