//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Charting;
using System.Windows;
using System;
using System.Windows.Markup;
using CSHTML5.Internal;
using kendo_ui_chart.kendo.dataviz.ui;
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
            if (await _kendoChart.JSInstanceLoaded)
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

        protected virtual void SetKendoChartTooltip(ChartOptions chartOptions)
        {
            //if (tooltip) {
            chartOptions.tooltip = new ChartTooltip() { visible = true, format = "{0}%" };
            // }
        }
        protected virtual void SetKendoChartLegend(ChartOptions chartOptions)
        {
            if (null != this.Legend)
            {
                chartOptions.legend = new ChartLegend();
                chartOptions.legend.background = "green";
                chartOptions.legend.visible = true;

                chartOptions.legend.labels = new ChartLegendLabels();
                chartOptions.legend.labels.font = "20px sans-serif";
            }
        }

        protected virtual void SetKendoChartOptions()
        {
            ChartOptions chartOptions = new ChartOptions();

            SetKendoChartTooltip(chartOptions);
            SetKendoChartLegend(chartOptions);
            SetKendoChartSeries(chartOptions);

            _kendoChart.setOptions(chartOptions);
        }

        #endregion

        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.Register("BehaviorsProperty", typeof(ChartBehaviorCollection), typeof(RadChartBase), new PropertyMetadata(new ChartBehaviorCollection()));
        public static readonly DependencyProperty KendoLegendProperty = DependencyProperty.Register("KendoLegendProperty", typeof(KendoLegend), typeof(RadChartBase), null);
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
