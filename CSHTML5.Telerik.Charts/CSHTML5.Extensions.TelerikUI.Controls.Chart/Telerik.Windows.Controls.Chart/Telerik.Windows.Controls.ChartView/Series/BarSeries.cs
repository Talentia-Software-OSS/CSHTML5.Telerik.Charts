
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{ 
    public class BarSeries : CategoricalColorSeries
    {
        public enum BarTypes
        {
            Bar,
            Column
        }

        public static readonly DependencyProperty TypeProperty = DependencyProperty.Register("TypeProperty", typeof(BarTypes), typeof(BarSeries), new PropertyMetadata(BarTypes.Column));
        public static readonly DependencyProperty ShowLabelsProperty = DependencyProperty.Register("ShowLabelsProperty", typeof(BarSeries), typeof(bool), null);
        
        public override string GetChartType()
        {
            return Type == BarTypes.Column ? ChartTypeColumn : ChartTypeBar;
        }

        public DataPointBinding ShowLabels
        {
            get { return (DataPointBinding)this.GetValue(BarSeries.ShowLabelsProperty); }
            set { this.SetValue(BarSeries.ShowLabelsProperty, (object)value); }
        }

        public BarTypes Type
        {
            get { return (BarTypes)this.GetValue(BarSeries.TypeProperty); }
            set { this.SetValue(BarSeries.TypeProperty, (object)value); }
        }
    }
}
