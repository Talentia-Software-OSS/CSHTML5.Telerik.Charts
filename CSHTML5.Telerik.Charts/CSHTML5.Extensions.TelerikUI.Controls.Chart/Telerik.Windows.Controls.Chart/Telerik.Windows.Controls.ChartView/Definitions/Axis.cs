//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using Telerik.Charting;
using System.Windows.Media;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public abstract class Axis : ChartElementPresenter
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty LabelFormatProperty = DependencyProperty.Register("LabelFormatProperty", typeof(string), typeof(Axis), null);
        public static readonly DependencyProperty LabelFitModeProperty = DependencyProperty.Register("LabelFitModeProperty", typeof(AxisLabelFitMode), typeof(Axis), null);
        private AxisSmartLabelsMode _smartLabelsMode;
        public static readonly DependencyProperty LineStrokeProperty = DependencyProperty.Register("LineStrokeProperty", typeof(Brush), typeof(Axis), null);
        public static readonly DependencyProperty MajorTickStyleProperty = DependencyProperty.Register("MajorTickStyleProperty", typeof(Style), typeof(Axis), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public string LabelFormat
        {
            get { return (string)this.GetValue(Axis.LabelFormatProperty); }
            set { this.SetValue(Axis.LabelFormatProperty, (object)value); }
        }
        public AxisLabelFitMode LabelFitMode
        {
            get { return (AxisLabelFitMode)this.GetValue(Axis.LabelFitModeProperty); }
            set { this.SetValue(Axis.LabelFitModeProperty, (object)value); }
        }
        public AxisSmartLabelsMode SmartLabelsMode
        {
            get { return _smartLabelsMode; }
            set { _smartLabelsMode = value; }
        }
        public Brush LineStroke
        {
            get { return (Brush)this.GetValue(Axis.LineStrokeProperty); }
            set { this.SetValue(Axis.LineStrokeProperty, (object)value); }
        }
        public Style MajorTickStyle
        {
            get { return (Style)this.GetValue(Axis.MajorTickStyleProperty); }
            set { this.SetValue(Axis.MajorTickStyleProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected Axis()
        {
            _smartLabelsMode = new AxisSmartLabelsMode();
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
