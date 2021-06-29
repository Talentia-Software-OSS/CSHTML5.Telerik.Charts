using CSHTML5;
using CSHTML5.Internal;
using CSHTML5.Wrappers.KendoUI.Common;
using kendo_ui_chart.kendo.dataviz.ui;
using System;
using System.Collections.Generic;
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
        class DataPropertyMapping
        {
            public string PropName;
            public string FieldName;
            public Boolean IsMapped = false;
        }

        public RadPieChart()
        {
            this.DefaultStyleKey = typeof(RadPieChart);
            _series = new PresenterCollection<PieSeries>();
            _series.CollectionChanged += Series_CollectionChanged;
        }

        private PresenterCollection<PieSeries> _series;
        public PresenterCollection<PieSeries> Series
        {
            get { return _series; }
        }

        private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //When we add a CartesianChart, we set its ParentChart to this, when we remove one, we set it to null:
            if (e.OldItems != null)
            {
                foreach (object pieSeriesAsObject in e.OldItems)
                {
                    ((PieSeries)pieSeriesAsObject).ParentChart = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (object pieSeriesAsObject in e.NewItems)
                {
                    ((PieSeries)pieSeriesAsObject).ParentChart = this;
                }
            }
        }

        protected override void SetKendoChartSeries()
        {
            ChartOptions chartO = new ChartOptions();
            chartO.tooltip = new ChartTooltip() { visible = true, format = "{0}%" };

            var series = new JSArray<ChartSeriesItem>();
            foreach (PieSeries pieSeries in _series)
            {
                if (pieSeries.ItemsSource != null)
                {
                    // create seriesItem
                    ChartSeriesItem seriesItem = new ChartSeriesItem();

                    // set series details
                    seriesItem.type = pieSeries.GetChartType();
                    seriesItem.startAngle = pieSeries.StartAngle;

                    // mapped fields
                    DataPropertyMapping categoryMapping = new DataPropertyMapping() { FieldName = pieSeries.CategoryBinding?.PropertyPath ?? "Category" };
                    seriesItem.categoryField = categoryMapping.FieldName;

                    DataPropertyMapping valueMapping = new DataPropertyMapping() { FieldName = pieSeries.ValueBinding?.PropertyPath ?? "Value" };
                    seriesItem.field = valueMapping.FieldName;

                    // unmapped detail fields
                    DataPropertyMapping colorMapping = new DataPropertyMapping() { PropName = pieSeries.ColorBinding?.PropertyPath ?? "Color", FieldName = "color" };

                    var propertyFields = new List<DataPropertyMapping>() { categoryMapping, valueMapping, colorMapping };
                    var res = PrepareSeriesData(pieSeries.ItemsSource, propertyFields);
                    seriesItem.data = res;

                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }

        private JSObject PrepareSeriesData(System.Collections.IEnumerable seriesData, List<DataPropertyMapping> propertiesToPutInResult)
        {
            object preparedSeriesData = Interop.ExecuteJavaScript("[]");

            foreach (var cSharpItem in seriesData)
            {
                var jsObject = Interop.ExecuteJavaScript("new Object()");
                foreach (DataPropertyMapping property in propertiesToPutInResult)
                {
                    string propertyName = property.FieldName;
                    object propertyValue = String.IsNullOrEmpty(property.PropName) ? Utils.GetNestedPropertyValue(cSharpItem, propertyName) : Utils.GetNestedPropertyValue(cSharpItem, property.PropName);

                    if (propertyValue is DateTime) {
                        Interop.ExecuteJavaScript(@"$0[$1] = new Date($2)", jsObject, propertyName, propertyValue.ToString()); //We'll simply do this for now, it might need some formatting to be sure Date() will understand the date.
                    } else if (propertyValue != null) {
                        Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, propertyName, propertyValue.ToString());
                    }
                }
                Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, jsObject);
            }
            return new JSObject(preparedSeriesData);
        }
    }
}
