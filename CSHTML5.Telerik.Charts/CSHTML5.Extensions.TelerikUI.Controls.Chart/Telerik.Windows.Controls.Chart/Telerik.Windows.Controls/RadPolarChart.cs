using System;
using Telerik.Windows.Controls.ChartView;
using CSHTML5;
using CSHTML5.Internal;
using kendo_ui_chart.kendo.dataviz.ui;
using TypeScriptDefinitionsSupport;
using JSConversionHelpers;
using System.Collections.Generic;

namespace Telerik.Windows.Controls
{
    public class RadPolarChart: RadChartBase
    {
        public RadPolarChart()
        {
            this.DefaultStyleKey = typeof(RadPolarChart);
            _series = new PresenterCollection<RadarLineSeries>();
            _series.CollectionChanged += Series_CollectionChanged;
        }

        private PresenterCollection<RadarLineSeries> _series;
        public PresenterCollection<RadarLineSeries> Series
        {
            get { return _series; }
        }

        private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //When we add a CartesianChart, we set its ParentChart to this, when we remove one, we set it to null:
            if (e.OldItems != null)
            {
                foreach (object radarLineSerieAsObject in e.OldItems)
                {
                    ((RadarLineSeries)radarLineSerieAsObject).ParentChart = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (object radarLineSerieAsObject in e.NewItems)
                {
                    ((RadarLineSeries)radarLineSerieAsObject).ParentChart = this;
                }
            }
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
                    seriesItem.type = "polarLine";
                    seriesItem.style = "smooth";

                    // mapped fields
                    DataPropertyMapping categoryMapping = new DataPropertyMapping(radarLineSerie.CategoryBinding?.PropertyPath ?? "Category");
                    seriesItem.xField = categoryMapping.FieldName;

                    DataPropertyMapping valueMapping = new DataPropertyMapping(radarLineSerie.ValueBinding?.PropertyPath ?? "Value");
                    seriesItem.yField = valueMapping.FieldName;

                    var propertyFields = new List<DataPropertyMapping>() { categoryMapping, valueMapping };
                    var res = JSConverters.PrepareSeriesData(radarLineSerie.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    //seriesItem.data = GetSeriesData();

                    // add serie to series array
                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }
    }
}
