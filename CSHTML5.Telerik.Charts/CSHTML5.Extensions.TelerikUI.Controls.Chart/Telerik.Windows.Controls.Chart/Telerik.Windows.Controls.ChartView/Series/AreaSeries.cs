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
    public class AreaSeries : CategoricalStrokedSeries
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty FillProperty = DependencyProperty.Register("FillProperty", typeof(Brush), typeof(AreaSeries), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public Brush Fill
        {
            get { return (Brush)this.GetValue(AreaSeries.FillProperty); }
            set { this.SetValue(AreaSeries.FillProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public AreaSeries()
        {
        }

        public override string GetChartType()
        {
            return ChartTypeArea;
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
