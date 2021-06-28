using System;
using Telerik.Windows.Controls.ChartView;
using CSHTML5;
using CSHTML5.Internal;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;

namespace Telerik.Windows.Controls
{
    public class RadPolarChart: RadChartBase
    {
        public RadPolarChart()
        {
            this.DefaultStyleKey = typeof(RadPolarChart);
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

        void SetKendoChartSeries()
        {
            // create chart options
            ChartOptions chartO = new ChartOptions();
            //chartO.seriesDefaults = Interop.ExecuteJavaScript("{ labels: { visible: true, background: 'transparent', template: '#= category #: \n #= value#%' } }");
            chartO.tooltip = new ChartTooltip() { visible = true, format = "{0}%" };

            // create series
            var series = new JSArray<ChartSeriesItem>();

            // create seriesItem
            ChartSeriesItem seriesItem = new ChartSeriesItem();

            // set series details
            seriesItem.type = "polarLine";
            seriesItem.style = "smooth";
            
            seriesItem.data = GetSeriesData();

            // add serie to series array
            series.Add(seriesItem);

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }

        private JSObject GetSeriesData()
        {
            object preparedSeriesData = Interop.ExecuteJavaScript("[]");

            object newItems1 = Interop.ExecuteJavaScript("[0,0,15,2,30,4,45,6,60, 8, 75, 10, 90, 12, 105, 14, 120, 16, 135, 18, 150, 20, 165, 22, 180, 24, 195, 26, 210, 28, 225, 30, 240, 32, 255, 34, 270, 36, 285, 38, 300, 40, 315, 42, 330, 44, 345, 46, 360, 48, 15, 50, 30, 52, 45, 54, 60, 56, 75, 58, 90, 60]");
            object newItems2 = Interop.ExecuteJavaScript("[0,0,15,1,30,2,45,3,60, 4, 75, 5, 90, 6, 105, 7, 120, 8, 135, 9, 150, 10, 165, 11, 180, 12, 195, 13, 210, 14, 225, 15, 240, 16, 255, 17, 270, 18, 285, 19, 300, 20, 315, 21, 330, 22, 345, 23, 360, 24, 15, 25, 30, 26, 45, 27, 60, 28, 75, 29, 90, 30]");
            object newItems3 = Interop.ExecuteJavaScript("[0,0,15,3,30,6,45,9,60, 12, 75, 15, 90, 18, 105, 21, 120, 24, 135, 27, 150, 30, 165, 33, 180, 36, 195, 39, 210, 42, 225, 45, 240, 48, 255, 51, 270, 54, 285, 57, 300, 60, 315, 63, 330, 66, 345, 69, 360, 72, 15, 75, 30, 78, 45, 81, 60, 84, 75, 87, 90, 90]");


            Interop.ExecuteJavaScript("while ($1.length > 0) {$0.push($1.splice(0,2));}", preparedSeriesData, newItems1);
            Interop.ExecuteJavaScript("while ($1.length > 0) {$0.push($1.splice(0,2));}", preparedSeriesData, newItems2);
            Interop.ExecuteJavaScript("while ($1.length > 0) {$0.push($1.splice(0,2));}", preparedSeriesData, newItems3);

            return new JSObject(preparedSeriesData);
        }

    }
}
