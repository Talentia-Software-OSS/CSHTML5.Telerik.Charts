using Telerik.Windows.Controls.ChartView;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using JSConversionHelpers;
using System.Collections.Generic;

namespace Telerik.Windows.Controls
{
    public class RadPolarChart: RadChartSeriesBase<RadarLineSeries>
    {
        public RadPolarChart(): base()
        {
            this.DefaultStyleKey = typeof(RadPolarChart);
        }

        protected override void SetKendoChartSeries()
        {
            // create chart options
            ChartOptions chartO = new ChartOptions();
            //chartO.seriesDefaults = Interop.ExecuteJavaScript("{ labels: { visible: true, background: 'transparent', template: '#= category #: \n #= value#%' } }");
            chartO.tooltip = new ChartTooltip() { visible = true, format = "{0}%" };

            // create series
            var series = new JSArray<ChartSeriesItem>();
            foreach (RadarLineSeries radarLineSerie in _series)
            {
                if (radarLineSerie.ItemsSource != null)
                {
                    // create seriesItem
                    ChartSeriesItem seriesItem = new ChartSeriesItem();

                    // set series details
                    seriesItem.type = radarLineSerie.GetChartType();
                    seriesItem.style = radarLineSerie.GetChartStyle();

                    // mapped fields
                    var propertyFields = SetInSeriesItemAndGetPropertyFields(radarLineSerie, seriesItem);
                    // data mapping
                    var res = JSConverters.PrepareSeriesData(radarLineSerie.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    // add serie to series array
                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }

        protected override List<DataPropertyMapping> SetInSeriesItemAndGetPropertyFields(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            var propertyFields = new List<DataPropertyMapping>();
            if (chartSeries is CategoricalSeries)
            {
                var categoricalSeries = chartSeries as CategoricalSeries;
                DataPropertyMapping categoryMapping = new DataPropertyMapping(categoricalSeries.CategoryBinding?.PropertyPath ?? "Category");
                seriesItem.xField = categoryMapping.FieldName;
                propertyFields.Add(categoryMapping);

                DataPropertyMapping valueMapping = new DataPropertyMapping(categoricalSeries.ValueBinding?.PropertyPath ?? "Value");
                seriesItem.yField = valueMapping.FieldName;
                propertyFields.Add(valueMapping);
            }

            DataPropertyMapping colorMapping = JSConverters.SetColorSeriesOrGetColorMapping(chartSeries, seriesItem);
            if (colorMapping != null)
            {
                propertyFields.Add(colorMapping);
            }

            return propertyFields;
        }
    }
}
