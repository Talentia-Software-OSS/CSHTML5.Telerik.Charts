//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Windows.Controls.ChartView;
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using CSHTML5;
using CSHTML5.Wrappers.KendoUI.Common;
using System.Collections.Generic;
using System.Windows.Media;
using CSHTML5.Internal;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls
{
    public class RadCartesianChart : RadChartBase
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        private PresenterCollection<CartesianSeries> _series;
        private CartesianChartGrid _grid;
        public static readonly DependencyProperty HorizontalAxisProperty = DependencyProperty.Register("HorizontalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        public static readonly DependencyProperty VerticalAxisProperty = DependencyProperty.Register("VerticalAxisProperty", typeof(CartesianAxis), typeof(RadCartesianChart), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public PresenterCollection<CartesianSeries> Series
        {
            get { return _series; }
        }
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
        public RadCartesianChart()
        {
            this.DefaultStyleKey = typeof(RadCartesianChart);
            _series = new PresenterCollection<CartesianSeries>();
            _series.CollectionChanged += Series_CollectionChanged;
            _grid = null;
        }

        private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //When we add a CartesianChart, we set its ParentChart to this, when we remove one, we set it to null:
            if (e.OldItems != null)
            {
                foreach (object cartesianSeriesAsObject in e.OldItems)
                {
                    ((CartesianSeries)cartesianSeriesAsObject).ParentChart = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (object cartesianSeriesAsObject in e.NewItems)
                {
                    ((CartesianSeries)cartesianSeriesAsObject).ParentChart = this;
                }
            }
        }

        void SetKendoChartSeries()
        {
            //todo: refactor this method into smaller methods. Also, we should probably put the similar code for the two axes in the same places (instead of dealing with one axis, then the other).

            ChartOptions chartO = new ChartOptions();
            var series = new JSArray<ChartSeriesItem>();

            #region Preparing the data points (series)
            foreach (CartesianSeries cartesianSeries in _series)
            {
                if (cartesianSeries.ItemsSource != null)
                {
                    ChartSeriesItem seriesItem = new ChartSeriesItem();
                    seriesItem.type = cartesianSeries.GetChartType();

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

                    if (cartesianSeries is CategoricalStrokedSeries)
                    {
                        var cartesianSeriesAsCategoricalSeries = cartesianSeries as CategoricalStrokedSeries;
                        string categoryField = cartesianSeriesAsCategoricalSeries.CategoryBinding.PropertyPath; //I'll just assume this has to have a value because I can't find a default value or anything like that in the telerik things I found on the internet.
                        string valueField = cartesianSeriesAsCategoricalSeries.ValueBinding.PropertyPath; // same as above.

                        SetSeriesItemColor(seriesItem, cartesianSeriesAsCategoricalSeries.Stroke);
                        if (cartesianSeries is AreaSeries)
                        {
                            SetSeriesItemColor(seriesItem, ((AreaSeries)cartesianSeriesAsCategoricalSeries).Fill);
                        }

                        var propNames = new List<string>() { categoryField, valueField };

                        var res = PrepareSeriesData(cartesianSeries.ItemsSource, propNames);

                        seriesItem.categoryField = categoryField;
                        seriesItem.field = valueField;
                        seriesItem.data = res;
                        seriesItem.missingValues = "gap";
                    }
                    else
                    {
                        //get the data as points as is.
                    }

                    //var v = new JSObject();
                    //Interop.ExecuteJavaScript(@"$0.UnderlyingJSInstance = [1, 2, 3]", v);
                    //seriesItem.data = v;
                    series.Add(seriesItem);
                }
            }
            #endregion

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

                string XAxisColor = GetStringToSetAsColor(HorizontalAxis.LineStroke);
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

            string YAxisColor = GetStringToSetAsColor(VerticalAxis.LineStroke);
            if (YAxisColor != null)
            {
                valueAxisItem.color = YAxisColor;
            }

            valueAxis.Add(valueAxisItem);
            chartO.valueAxis = valueAxis;

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

            //Setting the chart's background color:
            Brush background = Background;
            if (background != null && background is SolidColorBrush)
            {
                chartO.chartArea = new ChartChartArea();
                chartO.chartArea.background = (string)((SolidColorBrush)background).ConvertToCSSValue();
            }


            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }

        JSObject PrepareSeriesData(System.Collections.IEnumerable seriesData, List<string> propertiesToPutInResult)
        {
            object preparedSeriesData = Interop.ExecuteJavaScript("[]");

            foreach (var cSharpItem in seriesData)
            {
                var jsObject = Interop.ExecuteJavaScript("new Object()");
                foreach (string propertyName in propertiesToPutInResult)
                {
                    object propertyValue = Utils.GetNestedPropertyValue(cSharpItem, propertyName);

                    if (propertyValue is DateTime)
                    {
                        Interop.ExecuteJavaScript(@"$0[$1] = new Date($2)", jsObject, propertyName, propertyValue.ToString()); //We'll simply do this for now, it might need some formatting to be sure Date() will understand the date.
                    }
                    else
                    {
                        Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, propertyName, propertyValue.ToString());
                    }
                }
                Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, jsObject);
            }
            return new JSObject(preparedSeriesData);
        }

        void SetSeriesItemColor(ChartSeriesItem seriesItem, Brush color)
        {
            string colorToSet = GetStringToSetAsColor(color);
            if (colorToSet != null)
            {
                seriesItem.color = colorToSet;
            }
        }

        string GetStringToSetAsColor(Brush color)
        {
            if (color != null)
            {
                //todo: I don't remember if we have a good way of getting the string to set the css value from users' code.
                //todo: make it work with other brushes than SoliColorbrush (the attempt with LineargradientBrush didn't work although it works in the SL version).
                if (color is SolidColorBrush)
                {
                    return (string)((SolidColorBrush)color).ConvertToCSSValue();
                }
            }
            return null;
        }

        private INTERNAL_DispatcherQueueHandler _dispatcherQueueToRefreshTheChart = new INTERNAL_DispatcherQueueHandler();
        public async void Refresh()
        {
            if (await _kendoChart.JSInstanceLoaded)
            {
                _dispatcherQueueToRefreshTheChart.QueueActionIfQueueIsEmpty(() =>
                {
                    SetKendoChartSeries();
                    _kendoChart.Refresh();
                });
            }
            else
            {
                // Not loaded (for example if the .JS libraries are not present).

                throw new Exception("JS libraries not loaded");
            }
        }

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//
    }
}
