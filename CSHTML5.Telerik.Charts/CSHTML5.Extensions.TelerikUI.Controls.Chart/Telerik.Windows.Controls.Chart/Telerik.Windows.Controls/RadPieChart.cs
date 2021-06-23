using CSHTML5;
using CSHTML5.Internal;
using kendo_ui_chart.kendo.dataviz.ui;
using System;
using Telerik.Windows.Controls.ChartView;
using TypeScriptDefinitionsSupport;
//using Telerik.Windows.Controls.Primitives;
//using System.Windows.Controls;
//using System.Windows;
//using System;
//using kendo_ui_chart.kendo.dataviz.ui;
//using TypeScriptDefinitionsSupport;
//using CSHTML5;
//using CSHTML5.Wrappers.KendoUI.Common;
//using System.Collections.Generic;
//using System.Windows.Media;
//using CSHTML5.Internal;

namespace Telerik.Windows.Controls
{
    public class RadPieChart : RadChartBase
    {
        public RadPieChart()
        {
            this.DefaultStyleKey = typeof(RadPieChart);
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
            seriesItem.type = "pie";
            seriesItem.startAngle = 150;
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

            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("Asia", 53.8, "#9de219"));
            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("Europe", 16.1, "#90cc38"));
            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("Latin America", 11.3, "#068c35"));
            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("Africa", 9.6, "#006634"));
            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("Middle East", 5.2, "#004d38"));
            Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, CreateNewPieSeriesObject("North America", 3.6, "#033939"));

            return new JSObject(preparedSeriesData);
        }

        private object CreateNewPieSeriesObject(string categroy, double value, string color)
        {
            var jsObject = Interop.ExecuteJavaScript("new Object()");

            Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, "category", categroy.ToString());
            Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, "value", value);
            Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, "color", color.ToString());

            return jsObject;
        }
    }
}
