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

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _kendoChart = this.GetTemplateChild("KendoChart") as kendo_ui_chart.kendo.dataviz.ui.Chart;
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

                // set position and alignment
                chartOptions.legend.position = Legend.Position.ToString().ToLower();    // does not treat custom - if needed to expose offsetX, offsetY properties
                chartOptions.legend.align = JSConverters.GetAlignment(Legend.Position, Legend.VerticalAlignment, Legend.HorizontalAlignment).ToString();
            }
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

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
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

        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected RadChartBase()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
