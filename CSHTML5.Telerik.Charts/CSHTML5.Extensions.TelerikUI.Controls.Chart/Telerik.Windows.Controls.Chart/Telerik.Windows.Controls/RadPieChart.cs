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

                    string categoryField = pieSeries.CategoryBinding?.PropertyPath ?? "Category";
                    string valueField = pieSeries.ValueBinding?.PropertyPath ?? "Value";
                    
                    string colorField = pieSeries.ColorBinding?.PropertyPath ?? "Color";

                    seriesItem.categoryField = categoryField;
                    seriesItem.field = valueField;

                    var propNames = new List<string>() { categoryField, valueField, colorField };
                    var mappedPropNames = new List<string>() { categoryField, valueField };
                    var res = PrepareSeriesData(pieSeries.ItemsSource, propNames, mappedPropNames);
                    seriesItem.data = res;

                    series.Add(seriesItem);
                }
            }

            // add chart to kendo
            chartO.series = series;
            _kendoChart.setOptions(chartO);
        }

        private JSObject PrepareSeriesData(System.Collections.IEnumerable seriesData, List<string> propertiesToPutInResult, List<string> mappedPropertiesToPutInResult)
        {
            object preparedSeriesData = Interop.ExecuteJavaScript("[]");

            foreach (var cSharpItem in seriesData)
            {
                var jsObject = Interop.ExecuteJavaScript("new Object()");
                foreach (string propertyName in propertiesToPutInResult)
                {
                    object propertyValue = Utils.GetNestedPropertyValue(cSharpItem, propertyName);

                    if (propertyValue is DateTime) {
                        Interop.ExecuteJavaScript(@"$0[$1] = new Date($2)", jsObject, propertyName, propertyValue.ToString()); //We'll simply do this for now, it might need some formatting to be sure Date() will understand the date.
                    } else if (mappedPropertiesToPutInResult.Contains(propertyName)) {
                        Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, propertyName, propertyValue.ToString());
                    } else {
                        Interop.ExecuteJavaScript(@"$0[$1] = $2;", jsObject, propertyName.ToLower(), propertyValue.ToString());
                    }
                }
                Interop.ExecuteJavaScript("$0.push($1)", preparedSeriesData, jsObject);
            }
            return new JSObject(preparedSeriesData);
        }

        //class PieDataProperties
        //{
        //    string propName;
        //    string fieldName;
        //    Boolean isMapped = false;
        //}
    }
}
