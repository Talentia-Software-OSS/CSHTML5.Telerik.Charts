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
    public abstract class CategoricalSeriesBase : CartesianSeries
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty CategoryBindingProperty = DependencyProperty.Register("CategoryBindingProperty", typeof(DataPointBinding), typeof(CategoricalSeriesBase), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public DataPointBinding CategoryBinding
        {
            get { return (DataPointBinding)this.GetValue(CategoricalSeriesBase.CategoryBindingProperty); }
            set { this.SetValue(CategoricalSeriesBase.CategoryBindingProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected CategoricalSeriesBase()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
