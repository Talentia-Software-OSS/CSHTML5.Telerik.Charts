using Telerik.Windows.Controls.ChartView;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using JSConversionHelpers;
using System.Collections.Generic;

namespace Telerik.Windows.Controls
{
    public class RadPolarChart: RadChartSeriesBase<PolarLineSeries>
    {
        public RadPolarChart(): base()
        {
            this.DefaultStyleKey = typeof(RadPolarChart);
        }

        protected override void SetKendoChartSeries(ChartOptions chartOptions)
        {
            // create series
            var series = new JSArray<ChartSeriesItem>();
            foreach (PolarLineSeries radarLineSerie in _series) // also RadarLineSeries is a PolarLineSeries
            {
                if (radarLineSerie.ItemsSource != null)
                {
                    // create seriesItem
                    ChartSeriesItem seriesItem = new ChartSeriesItem();

                    // set series details
                    seriesItem.name = radarLineSerie.SeriesName;
                    seriesItem.type = radarLineSerie.GetChartType();
                    seriesItem.style = radarLineSerie.GetChartStyle();

                    // mapped fields
                    var propertyFields = GetPropertyFields(radarLineSerie, seriesItem);
                    // data mapping
                    var res = JSConverters.PrepareSeriesData(radarLineSerie.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    SetKendoSeriesOptions(radarLineSerie, seriesItem);

                    // add serie to series array
                    series.Add(seriesItem);
                }
            }

            chartOptions.series = series;
        }

        protected override List<DataPropertyMapping> GetPropertyFields(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            if (chartSeries is RadarLineSeries)
            {
                return base.GetPropertyFields(chartSeries, seriesItem);
            }

            var propertyFields = new List<DataPropertyMapping>();
            if (chartSeries is CategoricalSeries)
            {
                var categoricalSeries = chartSeries as CategoricalSeries;
                
                var categoryPropertyName = JSConverters.GetFieldNameFromProperty(categoricalSeries.CategoryBinding);
                DataPropertyMapping categoryMapping = new DataPropertyMapping(categoryPropertyName ?? "Category");
                seriesItem.xField = categoryMapping.FieldName;
                propertyFields.Add(categoryMapping);

                var valuePropertyName = JSConverters.GetFieldNameFromProperty(categoricalSeries.ValueBinding);
                DataPropertyMapping valueMapping = new DataPropertyMapping(valuePropertyName ?? "Value");
                seriesItem.yField = valueMapping.FieldName;
                propertyFields.Add(valueMapping);
            }

            DataPropertyMapping colorMapping = JSConverters.SetColorSeriesOrGetColorMapping(chartSeries, seriesItem);
            if (colorMapping != null)
            {
                propertyFields.Add(colorMapping);
            }

            SetKendoSeriesTooltip(chartSeries, seriesItem);

            return propertyFields;
        }
    }
}
