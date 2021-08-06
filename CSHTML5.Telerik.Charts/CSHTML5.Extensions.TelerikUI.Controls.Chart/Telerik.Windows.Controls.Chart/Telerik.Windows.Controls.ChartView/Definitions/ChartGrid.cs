//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using JSConversionHelpers;
using System.Windows;
using System.Windows.Media;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public enum GridLinesType
    {
        Default,
        Line,
        Arc
    }

    public class ChartGrid : ChartElementPresenter
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty MajorYLineDashArrayProperty = DependencyProperty.Register("MajorYLineDashArrayProperty", typeof(DoubleCollection), typeof(ChartGrid), null);
        private GridLineRenderMode _majorYLinesRenderMode;
        public static readonly DependencyProperty MajorYLineStyleProperty = DependencyProperty.Register("MajorYLineStyleProperty", typeof(Style), typeof(ChartGrid), null);
        
        public static readonly DependencyProperty MajorLinesVisibilityProperty = DependencyProperty.Register("MajorLinesVisibilityProperty", typeof(GridLineVisibility), typeof(ChartGrid), null);
        public static readonly DependencyProperty MajorLineTypeProperty = DependencyProperty.Register("MajorLineTypeProperty", typeof(GridLinesType), typeof(ChartGrid), new PropertyMetadata(GridLinesType.Default));
        public static readonly DependencyProperty MajorLineStepProperty = DependencyProperty.Register("MajorLineStepProperty", typeof(int), typeof(ChartGrid), new PropertyMetadata(-1));
        public static readonly DependencyProperty MajorUnitProperty = DependencyProperty.Register("MajorUnitProperty", typeof(int), typeof(ChartGrid), new PropertyMetadata(-1));

        public static readonly DependencyProperty MinorLinesVisibilityProperty = DependencyProperty.Register("MinorLinesVisibilityProperty", typeof(GridLineVisibility), typeof(ChartGrid), null);
        public static readonly DependencyProperty MinorLineTypeProperty = DependencyProperty.Register("MinorLineTypeProperty", typeof(GridLinesType), typeof(ChartGrid), new PropertyMetadata(GridLinesType.Default));
        public static readonly DependencyProperty MinorUnitProperty = DependencyProperty.Register("MinorUnitProperty", typeof(int), typeof(ChartGrid), new PropertyMetadata(-1));

        public static readonly DependencyProperty ValueAxisVisibilityProperty = DependencyProperty.Register("ValueAxisVisibilityProperty", typeof(Visibility), typeof(ChartGrid), new PropertyMetadata(Visibility.Visible));
        public static readonly DependencyProperty ValueAxisNarrowRangeProperty = DependencyProperty.Register("ValueAxisNarrowRangeProperty", typeof(bool), typeof(ChartGrid), new PropertyMetadata(true));
        
        public static readonly DependencyProperty CategoryAxisReverseProperty = DependencyProperty.Register("CategoryAxisReverseProperty", typeof(bool), typeof(ChartGrid), new PropertyMetadata(false));
        public static readonly DependencyProperty CategoryAxisStartAngleProperty = DependencyProperty.Register("CategoryAxisStartAngleProperty", typeof(JSConverters.StartAngle), typeof(ChartGrid), new PropertyMetadata(JSConverters.StartAngle.Default));
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public GridLineVisibility MajorLinesVisibility
        {
            get { return (GridLineVisibility)this.GetValue(ChartGrid.MajorLinesVisibilityProperty); }
            set { this.SetValue(ChartGrid.MajorLinesVisibilityProperty, (object)value); }
        }
        public DoubleCollection MajorYLineDashArray
        {
            get { return (DoubleCollection)this.GetValue(ChartGrid.MajorYLineDashArrayProperty); }
            set { this.SetValue(ChartGrid.MajorYLineDashArrayProperty, (object)value); }
        }
        public GridLineRenderMode MajorYLinesRenderMode
        {
            get { return _majorYLinesRenderMode; }
            set { _majorYLinesRenderMode = value; }
        }
        public Style MajorYLineStyle
        {
            get { return (Style)this.GetValue(ChartGrid.MajorYLineStyleProperty); }
            set { this.SetValue(ChartGrid.MajorYLineStyleProperty, (object)value); }
        }

        public GridLinesType MajorLineType
        {
            get { return (GridLinesType)this.GetValue(ChartGrid.MajorLineTypeProperty); }
            set { this.SetValue(ChartGrid.MajorLineTypeProperty, (object)value); }
        }
        public int MajorLineStep
        {
            get { return (int)this.GetValue(ChartGrid.MajorLineStepProperty); }
            set { this.SetValue(ChartGrid.MajorLineStepProperty, (object)value); }
        }
        
        public int MajorUnit
        {
            get { return (int)this.GetValue(ChartGrid.MajorUnitProperty); }
            set { this.SetValue(ChartGrid.MajorUnitProperty, (object)value); }
        }

        public GridLineVisibility MinorLinesVisibility
        {
            get { return (GridLineVisibility)this.GetValue(ChartGrid.MinorLinesVisibilityProperty); }
            set { this.SetValue(ChartGrid.MinorLinesVisibilityProperty, (object)value); }
        }
        public GridLinesType MinorLineType
        {
            get { return (GridLinesType)this.GetValue(ChartGrid.MinorLineTypeProperty); }
            set { this.SetValue(ChartGrid.MinorLineTypeProperty, (object)value); }
        }

        public int MinorUnit
        {
            get { return (int)this.GetValue(ChartGrid.MinorUnitProperty); }
            set { this.SetValue(ChartGrid.MinorUnitProperty, (object)value); }
        }

        public Visibility ValueAxisVisibility
        {
            get { return (Visibility)this.GetValue(ChartGrid.ValueAxisVisibilityProperty); }
            set { this.SetValue(ChartGrid.ValueAxisVisibilityProperty, (object)value); }
        }

        public bool ValueAxisNarrowRange
        {
            get { return (bool)this.GetValue(ChartGrid.ValueAxisNarrowRangeProperty); }
            set { this.SetValue(ChartGrid.ValueAxisNarrowRangeProperty, (object)value); }
        }
        
        public bool CategoryAxisReverse
        {
            get { return (bool)this.GetValue(ChartGrid.CategoryAxisReverseProperty); }
            set { this.SetValue(ChartGrid.CategoryAxisReverseProperty, (object)value); }
        }

        public JSConverters.StartAngle CategoryAxisStartAngle
        {
            get { return (JSConverters.StartAngle)this.GetValue(ChartGrid.CategoryAxisStartAngleProperty); }
            set { this.SetValue(ChartGrid.CategoryAxisStartAngleProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public ChartGrid()
        {
            _majorYLinesRenderMode = new GridLineRenderMode();
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
