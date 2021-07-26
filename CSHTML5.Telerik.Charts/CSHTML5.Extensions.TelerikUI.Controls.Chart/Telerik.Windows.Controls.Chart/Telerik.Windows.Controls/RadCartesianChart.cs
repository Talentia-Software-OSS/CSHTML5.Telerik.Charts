//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.ChartView;
using System.Windows;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using CSHTML5;
using System.Windows.Media;
using JSConversionHelpers;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls
{
    public class RadCartesianChart : RadChartSeriesBase<CartesianSeries>
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        private CartesianChartGrid _grid;
        public static readonly DependencyProperty HorizontalAxisProperty = DependencyProperty.Register("HorizontalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        public static readonly DependencyProperty VerticalAxisProperty = DependencyProperty.Register("VerticalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public CartesianChartGrid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
        public CartesianAxis HorizontalAxis
        {
            get { return (CartesianAxis)this.GetValue(RadCartesianChart.HorizontalAxisProperty); }
            set { this.SetValue(RadCartesianChart.HorizontalAxisProperty, (object)value); }
        }
        public CartesianAxis VerticalAxis
        {
            get { return (CartesianAxis)this.GetValue(RadCartesianChart.VerticalAxisProperty); }
            set { this.SetValue(RadCartesianChart.VerticalAxisProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public RadCartesianChart() : base()
        {
            this.DefaultStyleKey = typeof(RadCartesianChart);
            _grid = null;
        }

        protected override void SetKendoChartSeries(ChartOptions chartOptions)
        {
            base.SetKendoChartSeries(chartOptions);

            //todo: refactor this method into smaller methods. Also, we should probably put the similar code for the two axes in the same places (instead of dealing with one axis, then the other).

            //ChartOptions chartO = new ChartOptions();
            var series = new JSArray<ChartSeriesItem>();

            foreach (CartesianSeries cartesianSeries in _series)
            {
                if (cartesianSeries.ItemsSource != null)
                {
                    ChartSeriesItem seriesItem = new ChartSeriesItem();
                    seriesItem.name = cartesianSeries.SeriesName;
                    seriesItem.type = cartesianSeries.GetChartType();
                    seriesItem.missingValues = "gap";

                    #region attempt at dealing with tooltips in series.
                    //if(cartesianSeries is LineSeries)
                    //{
                    //    //Note: the following does nothing if chartO.tooltip.shared is true.
                    //    //note: The LineSeries is the only one that has the LineSeries.TrackBallInfoTemplate set in the xaml
                    //    seriesItem.tooltip = new ChartSeriesItemTooltip();
                    //    Interop.ExecuteJavaScript("$0.visible = true", seriesItem.tooltip.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.crosshair.visible = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                    //    seriesItem.tooltip.format = "Close: {0}";
                    //}
                    //if(cartesianSeries.TrackBallInfoTemplate != null)
                    //{
                    //    //find a way to generate a kendo-style template in html here, from the cartesianSeries.TrackBallInfoTemplate.
                    //    //that includes creating the html structure and translating the bindings into something in kendo style.
                    //    // for example, the Text="{Binding DataPoint.Category, StringFormat=Date: \{0:d\} }"
                    //}
                    #endregion

                    // mapped fields
                    var propertyFields = GetPropertyFields(cartesianSeries, seriesItem);
                    // data mapping
                    var res = JSConverters.PrepareSeriesData(cartesianSeries.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    SetKendoSeriesOptions(cartesianSeries, seriesItem);

                    series.Add(seriesItem);
                }
            }

            chartOptions.series = series;
            //_kendoChart.setOptions(chartO);

            if (chartOptions.series.Count != _series.Count)
            {
                throw new System.Exception("Not working");
            }
        }

        protected override void SetOtherOptions(ChartOptions chartO)
        {
            //Setting the chart's background color:
            Brush background = Background;
            if (background != null && background is SolidColorBrush)
            {
                chartO.chartArea = new ChartChartArea();
                chartO.chartArea.background = (string)((SolidColorBrush)background).ConvertToCSSValue();
            }
        }

        protected override void SetAxis(ChartOptions chartO)
        {
            base.SetAxis(chartO);

            var categoryAxis = new JSArray<ChartCategoryAxisItem>();
            var categoryAxisItem = new ChartCategoryAxisItem();

            if (HorizontalAxis != null)
            {
                var labels = new ChartCategoryAxisItemLabels();
                labels.rotation = HorizontalAxis.LabelFitMode == Charting.AxisLabelFitMode.Rotate ? -60 : 0;
                labels.format = HorizontalAxis.LabelFormat; //Note: this seems to apply to DateFormats as well so I don't think we need to set labels.dateFormats
                labels.font = HorizontalAxis.FontFamily != null ? HorizontalAxis.FontFamily.Source : null;

                //labels.color = "LightGray"; //todo: find out what defines the label's color (it is not HorizontalAxis.Foreground apparently)
                categoryAxisItem.labels = labels;

                string XAxisColor = JSConverters.GetStringToSetAsColor(HorizontalAxis.LineStroke);
                if (XAxisColor != null)
                {
                    categoryAxisItem.color = XAxisColor;
                }
            }

            bool hideCategoryAxisGridLines = false;
            bool hideValueAxisGridLines = false;
            if (Grid != null)
            {
                #region Determining Whether to hide the Grid lines or not.
                switch (Grid.MajorLinesVisibility)
                {
                    case GridLineVisibility.None:
                        hideCategoryAxisGridLines = true;
                        hideValueAxisGridLines = true;
                        break;
                    case GridLineVisibility.X:
                        hideValueAxisGridLines = true;
                        break;
                    case GridLineVisibility.Y:
                        hideCategoryAxisGridLines = true;
                        break;
                    case GridLineVisibility.XY:
                        break;
                    default:
                        break;
                }
                #endregion

                //hiding the vertical lines:
                if (hideCategoryAxisGridLines)
                {
                    categoryAxisItem.majorGridLines = new ChartCategoryAxisItemMajorGridLines();
                    Interop.ExecuteJavaScript("$0.visible = false", categoryAxisItem.majorGridLines.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.majorGridLines.visible = false; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                    categoryAxisItem.minorGridLines = new ChartCategoryAxisItemMinorGridLines();
                    Interop.ExecuteJavaScript("$0.visible = false", categoryAxisItem.minorGridLines.UnderlyingJSInstance); //todo: same as above.
                }
            }

            categoryAxis.Add(categoryAxisItem);
            chartO.categoryAxis = categoryAxis;

            var valueAxis = new JSArray<ChartValueAxisItem>();
            var valueAxisItem = new ChartValueAxisItem();

            if (Grid != null)
            {
                if (Grid.MajorYLineDashArray != null)
                {
                    valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                    valueAxisItem.majorGridLines.dashType = "dash"; //Note: it's MajorYLineDashArray="5, 2" but I think the kendo charts only support a set of values: "dash","dashDot","dot","longDash","longDashDot","longDashDotDot" and "solid"
                }
            }

            //hiding the horizontal lines:
            if (hideValueAxisGridLines)
            {
                valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                Interop.ExecuteJavaScript("$0.visible = false", valueAxisItem.majorGridLines.UnderlyingJSInstance); //todo: find out how to do valueAxisItem.majorGridLines.visible = false; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                valueAxisItem.minorGridLines = new ChartValueAxisItemMinorGridLines();
                Interop.ExecuteJavaScript("$0.visible = false", valueAxisItem.minorGridLines.UnderlyingJSInstance); //todo: same as above.
            }

            if (VerticalAxis != null)
            {
                string YAxisColor = JSConverters.GetStringToSetAsColor(VerticalAxis.LineStroke);
                if (YAxisColor != null)
                {
                    valueAxisItem.color = YAxisColor;
                }

                valueAxis.Add(valueAxisItem);
                chartO.valueAxis = valueAxis;
            }

            if (Behaviors != null)
            {
                foreach (var behavior in Behaviors)
                {
                    if (behavior is ChartTrackBallBehavior)
                    {
                        ChartTrackBallBehavior behaviorAsCTBB = (ChartTrackBallBehavior)behavior;
                        if (behaviorAsCTBB.ShowIntersectionPoints)
                        {
                            categoryAxisItem.crosshair = new ChartCategoryAxisItemCrosshair();
                            Interop.ExecuteJavaScript("$0.visible = true", categoryAxisItem.crosshair.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.crosshair.visible = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                            //categoryAxisItem.crosshair.tooltip = new ChartCategoryAxisItemCrosshairTooltip();
                            //Interop.ExecuteJavaScript("$0.visible = true", categoryAxisItem.crosshair.tooltip.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.crosshair.visible = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                            //categoryAxisItem.crosshair.tooltip.format = "Date: {0:d}";

                            chartO.tooltip = new ChartTooltip(); //todo: move this to somewhere more adapted?
                            //Interop.ExecuteJavaScript("$0.visible = true", chartO.tooltip.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.crosshair.visible = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                            Interop.ExecuteJavaScript("$0.shared = true", chartO.tooltip.UnderlyingJSInstance); //todo: find out how to do chartO.tooltip.shared = true; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                                                                                                                //                            chartO.tooltip.sharedTemplate = @"<div>#: category #</div>
                                                                                                                //# for (var i = 0; i < points.length; i++) { #
                                                                                                                //    <div>#: points[i].series.name# : #: points[i].value #</div>
                                                                                                                //# } #";
                        }
                    }
                }
            }
        }

        protected override void SetKendoSeriesAdditionalOptions(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            base.SetKendoSeriesAdditionalOptions(chartSeries, seriesItem);
            var series = chartSeries as BarSeries;
            if (series != null)
            {
                seriesItem.gap = series.Gap;
                seriesItem.spacing = series.Spacing;
            }
        }
    }
}
