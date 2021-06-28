//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using Telerik.Charting;
using Telerik.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Windows.Markup;
using CSHTML5.Internal;
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

        protected abstract void SetKendoChartSeries();

        #endregion

        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty BehaviorsProperty = DependencyProperty.Register("BehaviorsProperty", typeof(ChartBehaviorCollection), typeof(RadChartBase), new PropertyMetadata(new ChartBehaviorCollection()));
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
