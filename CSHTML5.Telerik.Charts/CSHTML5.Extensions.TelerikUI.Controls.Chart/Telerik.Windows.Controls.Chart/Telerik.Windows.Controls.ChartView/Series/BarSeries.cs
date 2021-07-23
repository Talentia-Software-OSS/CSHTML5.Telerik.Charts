
using kendo_ui_chart.kendo.dataviz.ui;
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
        public static readonly DependencyProperty GapProperty = DependencyProperty.Register("GapProperty", typeof(double), typeof(BarSeries), new PropertyMetadata(0.25)); //kendo default value is 1.5
        public static readonly DependencyProperty SpacingProperty = DependencyProperty.Register("SpacingProperty", typeof(double), typeof(BarSeries), new PropertyMetadata(0.4));


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
        public double Gap
        {
            get { return (double)this.GetValue(BarSeries.GapProperty); }
            set { this.SetValue(BarSeries.GapProperty, (object)value); }
        }

        public double Spacing
        {
            get { return (double)this.GetValue(BarSeries.SpacingProperty); }
            set { this.SetValue(BarSeries.SpacingProperty, (object)value); }
        }
    }
}
