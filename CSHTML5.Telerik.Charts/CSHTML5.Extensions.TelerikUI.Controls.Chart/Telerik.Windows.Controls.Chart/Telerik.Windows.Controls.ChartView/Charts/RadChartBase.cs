//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Charting;
using System.Windows;
using System;
using System.Windows.Markup;
using CSHTML5.Internal;
using kendo_ui_chart.kendo.dataviz.ui;
using JSConversionHelpers;
using System.Windows.Controls;
using System.Text;
using CSHTML5;
using TypeScriptDefinitionsSupport;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    //-------------------------------------//
    //------------ ATTRIBUTES -------------//
    //-------------------------------------//
    [ContentProperty("Series")]
    public abstract class RadChartBase : PresenterBase, IChartElementPresenter
    {

        #region Non-Generated methods

        protected kendo_ui_chart.kendo.dataviz.ui.Chart _kendoChart;
        protected TextBlock _noDataTextBlock;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _kendoChart = this.GetTemplateChild("KendoChart") as kendo_ui_chart.kendo.dataviz.ui.Chart;
            _noDataTextBlock = this.GetTemplateChild("NoDataTextBlock") as TextBlock;
        }

        private INTERNAL_DispatcherQueueHandler _dispatcherQueueToRefreshTheChart = new INTERNAL_DispatcherQueueHandler();
        public async void Refresh()
        {
            if (null != _kendoChart && await _kendoChart.JSInstanceLoaded)
            {
                _dispatcherQueueToRefreshTheChart.QueueActionIfQueueIsEmpty(() =>
                {
                    SetKendoChartOptions();
                    _kendoChart.Refresh();
                });
            }
            else
            {
                // Not loaded (for example if the .JS libraries are not present).

                throw new Exception("JS libraries not loaded");
            }
        }

        protected abstract void SetKendoChartSeries(ChartOptions chartOptions);

        protected virtual void SetKendoChartDefaultsLabel(ChartSeriesDefaults seriesDefaults)
        {
            if (Label != null)
            {
                seriesDefaults.labels = new ChartSeriesDefaultsLabels();

                seriesDefaults.labels.visible = Label.Visibility == Visibility.Visible;
                // set bg
                if (Label.Background != null)
                {
                    seriesDefaults.labels.background = JSConverters.GetStringToSetAsColor(Label.Background);
                }

                if (Label.Color != null)
                {
                    seriesDefaults.labels.color = JSConverters.GetStringToSetAsColor(Label.Color);
                }

                if (Label.FontFamily != null)
                {
                    seriesDefaults.labels.font = string.Format("{0:0}px {1}", Label.FontSize, Label.FontFamily.ToString().ToLower());
                }

                if (Label.BorderThickness != null || Label.BorderBrush != null)
                {
                    seriesDefaults.labels.border = new ChartSeriesDefaultsLabelsBorder();

                    if (Label.BorderThickness != null)
                    {
                        seriesDefaults.labels.border.width = JSConverters.GetBorderWidthFromThickness(Label.BorderThickness);
                    }

                    if (Label.BorderBrush != null)
                    {
                        seriesDefaults.labels.border.color = JSConverters.GetStringToSetAsColor(Label.BorderBrush);
                    }
                }

                if (Label.Format != null)
                {
                    seriesDefaults.labels.format = Label.Format;
                }

                if (Label.LabelTemplate != null)
                {
                    seriesDefaults.labels.template = Label.LabelTemplate;
                }

                // no align, position properties series defaults
            }
        }

        protected virtual void SetKendoChartTooltip(ChartOptions chartOptions)
        {
            if (null != this.Tooltip)
            {
                chartOptions.tooltip = new ChartTooltip();
                chartOptions.tooltip.visible = Tooltip.Visibility == Visibility.Visible;
                // set bg
                if (Tooltip.Background != null)
                {
                    chartOptions.tooltip.background = JSConverters.GetStringToSetAsColor(Tooltip.Background);
                }

                if (Tooltip.Color != null)
                {
                    chartOptions.tooltip.color = JSConverters.GetStringToSetAsColor(Tooltip.Color);
                }

                if (Tooltip.FontFamily != null)
                {
                    chartOptions.tooltip.font = string.Format("{0:0}px {1}", Tooltip.FontSize, Tooltip.FontFamily.ToString().ToLower());
                }

                if (Tooltip.BorderThickness != null || Tooltip.BorderBrush != null)
                {
                    chartOptions.tooltip.border = new ChartTooltipBorder();
                    
                    if (Tooltip.BorderThickness != null) {
                        chartOptions.tooltip.border.width = JSConverters.GetBorderWidthFromThickness(Tooltip.BorderThickness);
                    }

                    if (Tooltip.BorderBrush != null)
                    {
                        chartOptions.tooltip.border.color = JSConverters.GetStringToSetAsColor(Tooltip.BorderBrush);
                    }
                }

                if (Tooltip.Format != null)
                {
                    chartOptions.tooltip.format = Tooltip.Format;
                }

                if (Tooltip.TooltipTemplate != null)
                {
                    chartOptions.tooltip.template = Tooltip.TooltipTemplate;
                }
            }
        }

        protected virtual void SetKendoChartLegend(ChartOptions chartOptions)
        {
            if (null != this.Legend)
            {
                chartOptions.legend = new ChartLegend();
                chartOptions.legend.visible = Legend.Visibility == Visibility.Visible;
                // set bg
                if (Legend.Background != null)
                {
                    chartOptions.legend.background = JSConverters.GetStringToSetAsColor(Legend.Background);
                }

                // set labels
                chartOptions.legend.labels = new ChartLegendLabels();
                if (Legend.FontFamily != null)
                {
                    chartOptions.legend.labels.font = string.Format("{0:0}px {1}", Legend.FontSize, Legend.FontFamily.ToString().ToLower());
                }
                if (Legend.Color != null)
                {
                    chartOptions.legend.labels.color = JSConverters.GetStringToSetAsColor(Legend.Color);
                }

                // setting markers for legend
                if (Legend.MarkersHeight >= 0 || Legend.MarkersWidth >= 0)
                {
                    StringBuilder sb = new StringBuilder("");
                    sb.Append("$0.markers = {");
                    if (Legend.MarkersHeight >= 0)
                    {
                        sb.AppendFormat("'{0}': {1},", "height", Legend.MarkersHeight);
                    }
                    if (Legend.MarkersWidth >= 0)
                    {
                        sb.AppendFormat("'{0}': {1},", "width", Legend.MarkersWidth);
                    }
                    sb.Append("};");
                    Interop.ExecuteJavaScript(sb.ToString(), chartOptions.legend.UnderlyingJSInstance);
                }

                // set position and alignment
                chartOptions.legend.position = Legend.Position.ToString().ToLower();    // does not treat custom - if needed to expose offsetX, offsetY properties
                chartOptions.legend.align = JSConverters.GetAlignment(Legend.Position, Legend.VerticalAlignment, Legend.HorizontalAlignment).ToString();
            }
        }

        protected virtual void SetAxis(ChartOptions chartOptions)
        {
            // get gridlines visibility
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
            }

            var categoryAxisItem = GetCategoryAxis(hideCategoryAxisGridLines);
            if (categoryAxisItem != null)
            {
                var categoryAxis = new JSArray<ChartCategoryAxisItem>();
                categoryAxis.Add(categoryAxisItem);
                chartOptions.categoryAxis = categoryAxis;
            }

            var valueAxisItem = GetValueAxis(hideValueAxisGridLines);
            if (valueAxisItem != null)
            {
                var valueAxis = new JSArray<ChartValueAxisItem>();
                valueAxis.Add(valueAxisItem);
                chartOptions.valueAxis = valueAxis;
            }

            SetBehaviors(chartOptions, categoryAxisItem);
        }

        #region Axis Setters
        private void SetBehaviors(ChartOptions chartO, ChartCategoryAxisItem categoryAxisItem)
        {
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

        private ChartValueAxisItem GetValueAxis(bool hideValueAxisGridLines)
        {
            bool modifiedValueAxis = false;
            bool createdMajorGridLines = false;
            bool createdMinorGridLines = false;
            var valueAxisItem = new ChartValueAxisItem();

            if (VerticalAxis != null)
            {
                string YAxisColor = JSConverters.GetStringToSetAsColor(VerticalAxis.LineStroke);
                if (YAxisColor != null)
                {
                    valueAxisItem.color = YAxisColor;
                }

                modifiedValueAxis = true;
            }

            if (Grid != null)
            {
                valueAxisItem.visible = Grid.ValueAxisVisibility == Visibility.Visible;

                if (Grid.MajorYLineDashArray != null)
                {
                    if (!createdMajorGridLines)
                    {
                        valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                        createdMajorGridLines = true;
                    }
                    valueAxisItem.majorGridLines.dashType = "dash"; //Note: it's MajorYLineDashArray="5, 2" but I think the kendo charts only support a set of values: "dash","dashDot","dot","longDash","longDashDot","longDashDotDot" and "solid"
                    modifiedValueAxis = true;
                }

                if (Grid.MajorLineType != GridLinesType.Default)
                {
                    if (!createdMajorGridLines)
                    {
                        valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                        createdMajorGridLines = true;
                    }
                    valueAxisItem.majorGridLines.type = JSConverters.FirstCharToLowerCase(Grid.MajorLineType.ToString());
                    modifiedValueAxis = true;
                }

                if (Grid.MajorLineStep >= 0)
                {
                    if (!createdMajorGridLines)
                    {
                        valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                        createdMajorGridLines = true;
                    }
                    valueAxisItem.majorGridLines.step = Grid.MajorLineStep;
                    modifiedValueAxis = true;
                }

                if (Grid.ValueAxisNarrowRange != true)
                {
                    valueAxisItem.narrowRange = Grid.ValueAxisNarrowRange;
                    modifiedValueAxis = true;
                }

                if (Grid.MinorLinesVisibility != GridLineVisibility.None)
                {
                    if (!createdMinorGridLines)
                    {
                        valueAxisItem.minorGridLines = new ChartValueAxisItemMinorGridLines();
                        createdMinorGridLines = true;
                    }
                    valueAxisItem.minorGridLines.visible = Grid.MinorLinesVisibility == GridLineVisibility.XY || Grid.MinorLinesVisibility == GridLineVisibility.Y;
                    modifiedValueAxis = true;
                }

                if (Grid.MinorLineType != GridLinesType.Default)
                {
                    if (!createdMinorGridLines)
                    {
                        valueAxisItem.minorGridLines = new ChartValueAxisItemMinorGridLines();
                        createdMinorGridLines = true;
                    }
                    valueAxisItem.minorGridLines.type = JSConverters.FirstCharToLowerCase(Grid.MajorLineType.ToString());
                    modifiedValueAxis = true;
                }

                if (Grid.MajorUnit > -1)
                {
                    valueAxisItem.majorUnit = Grid.MajorUnit;
                }

                if (Grid.MinorUnit > -1)
                {
                    valueAxisItem.minorUnit = Grid.MinorUnit;
                }
            }

            //hiding the horizontal lines:
            if (hideValueAxisGridLines)
            {
                if (!createdMajorGridLines)
                {
                    valueAxisItem.majorGridLines = new ChartValueAxisItemMajorGridLines();
                }
                valueAxisItem.majorGridLines.visible = false;
                if (!createdMinorGridLines)
                {
                    valueAxisItem.minorGridLines = new ChartValueAxisItemMinorGridLines();
                    valueAxisItem.minorGridLines.visible = false;
                }
                modifiedValueAxis = true;
            }

            if (modifiedValueAxis)
            {
                return valueAxisItem;
            }

            return null;
        }

        private ChartCategoryAxisItem GetCategoryAxis(bool hideCategoryAxisGridLines)
        {
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
 
            if (Grid != null)
            {
                //hiding the vertical lines:
                if (hideCategoryAxisGridLines)
                {
                    categoryAxisItem.majorGridLines = new ChartCategoryAxisItemMajorGridLines();
                    Interop.ExecuteJavaScript("$0.visible = false", categoryAxisItem.majorGridLines.UnderlyingJSInstance); //todo: find out how to do categoryAxisItem.majorGridLines.visible = false; without having Bridge break everything by boxing the value even though it is boxed in the generated code.
                    categoryAxisItem.minorGridLines = new ChartCategoryAxisItemMinorGridLines();
                    Interop.ExecuteJavaScript("$0.visible = false", categoryAxisItem.minorGridLines.UnderlyingJSInstance); //todo: same as above.
                }

                if (Grid.CategoryAxisStartAngle != JSConverters.StartAngle.Default)
                {
                    categoryAxisItem.startAngle = (int)Grid.CategoryAxisStartAngle;
                }

                if (Grid.CategoryAxisReverse)
                {
                    categoryAxisItem.reverse = Grid.CategoryAxisReverse;
                }
            }

            return categoryAxisItem;
        }

        #endregion

        protected virtual void SetOtherOptions(ChartOptions chartOptions)
        {
        }

        protected virtual void SetKendoChartOptions()
        {
            ChartOptions chartOptions = new ChartOptions();

            SetKendoChartTooltip(chartOptions);
            SetKendoChartLegend(chartOptions);
            if (Label != null)
            {
                chartOptions.seriesDefaults = new ChartSeriesDefaults();
                SetKendoChartDefaultsLabel(chartOptions.seriesDefaults);
            }
            SetKendoChartSeries(chartOptions);
            SetAxis(chartOptions);
            SetOtherOptions(chartOptions);

            _kendoChart.setOptions(chartOptions);
        }

        #endregion

        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.Register("BehaviorsProperty", typeof(ChartBehaviorCollection), typeof(RadChartBase), new PropertyMetadata(new ChartBehaviorCollection()));
        public static readonly DependencyProperty KendoLegendProperty = DependencyProperty.Register("KendoLegendProperty", typeof(KendoLegend), typeof(RadChartBase), null);
        public static readonly DependencyProperty KendoTooltipProperty = DependencyProperty.Register("KendoTooltipProperty", typeof(KendoTooltip), typeof(RadChartBase), null);
        public static readonly DependencyProperty KendoLabelProperty = DependencyProperty.Register("KendoLabelProperty", typeof(KendoLabel), typeof(RadChartBase), null);
        public static readonly DependencyProperty NoDataMessageProperty = DependencyProperty.Register("NoDataMessageProperty", typeof(string), typeof(RadChartBase), new PropertyMetadata("No data to plot"));

        protected ChartGrid _grid;
        public static readonly DependencyProperty HorizontalAxisProperty = DependencyProperty.Register("HorizontalAxisProperty", typeof(ChartAxis), typeof(RadCartesianChart), null);
        public static readonly DependencyProperty VerticalAxisProperty = DependencyProperty.Register("VerticalAxisProperty", typeof(ChartAxis), typeof(RadCartesianChart), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public ChartGrid Grid
        {
            get { return _grid; }
            set { _grid = value; }
        }
        public ChartAxis HorizontalAxis
        {
            get { return (ChartAxis)this.GetValue(RadCartesianChart.HorizontalAxisProperty); }
            set { this.SetValue(RadCartesianChart.HorizontalAxisProperty, (object)value); }
        }
        public ChartAxis VerticalAxis
        {
            get { return (ChartAxis)this.GetValue(RadCartesianChart.VerticalAxisProperty); }
            set { this.SetValue(RadCartesianChart.VerticalAxisProperty, (object)value); }
        }

        public ChartBehaviorCollection Behaviors
        {
            get { return (ChartBehaviorCollection)this.GetValue(RadChartBase.BehaviorsProperty); }
        }

        public KendoLegend Legend
        {
            get { return (KendoLegend)this.GetValue(RadChartBase.KendoLegendProperty); }
            set { this.SetValue(RadChartBase.KendoLegendProperty, (object)value); }
        }

        public KendoTooltip Tooltip
        {
            get { return (KendoTooltip)this.GetValue(RadChartBase.KendoTooltipProperty); }
            set { this.SetValue(RadChartBase.KendoTooltipProperty, (object)value); }
        }

        public KendoLabel Label
        {
            get { return (KendoLabel)this.GetValue(RadChartBase.KendoLabelProperty); }
            set { this.SetValue(RadChartBase.KendoLabelProperty, (object)value); }
        }

        public string NoDataMessage
        {
            get { return (string)this.GetValue(RadChartBase.NoDataMessageProperty); }
            set { this.SetValue(RadChartBase.NoDataMessageProperty, (object)value); }
        }

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected RadChartBase()
        {
            _grid = null;
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//
    }
}
