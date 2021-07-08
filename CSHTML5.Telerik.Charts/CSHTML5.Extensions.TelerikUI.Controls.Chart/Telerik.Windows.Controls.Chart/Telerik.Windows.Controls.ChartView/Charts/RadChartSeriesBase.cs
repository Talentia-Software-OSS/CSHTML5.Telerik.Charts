using JSConversionHelpers;
using kendo_ui_chart.kendo.dataviz.ui;
using System.Collections.Generic;

namespace Telerik.Windows.Controls.ChartView
{
    public abstract class RadChartSeriesBase<T> : RadChartBase where T : ChartSeries
    {
        protected PresenterCollection<T> _series;
        public PresenterCollection<T> Series
        {
            get { return _series; }
        }

        public RadChartSeriesBase() : base()
        {
            _series = new PresenterCollection<T>(this);
            _series.CollectionChanged += Series_CollectionChanged;
        }
        
        private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //When we add a CartesianChart, we set its ParentChart to this, when we remove one, we set it to null:
            if (e.OldItems != null)
            {
                foreach (object serieAsObject in e.OldItems)
                {
                    ((T)serieAsObject).ParentChart = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (object serieAsObject in e.NewItems)
                {
                    ((T)serieAsObject).ParentChart = this;
                }
            }
        }

        protected virtual List<DataPropertyMapping> SetInSeriesItemAndGetPropertyFields(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            var propertyFields = new List<DataPropertyMapping>();
            if (chartSeries is CategoricalSeries)
            {
                var categoricalSeries = chartSeries as CategoricalSeries;

                var categoryPropertyName = JSConverters.GetFieldNameFromProperty(categoricalSeries.CategoryBinding);
                DataPropertyMapping categoryMapping = new DataPropertyMapping(categoryPropertyName ?? "Category");
                seriesItem.categoryField = categoryMapping.FieldName;
                propertyFields.Add(categoryMapping);

                var valuePropertyName = JSConverters.GetFieldNameFromProperty(categoricalSeries.ValueBinding);
                DataPropertyMapping valueMapping = new DataPropertyMapping(valuePropertyName ?? "Value");
                seriesItem.field = valueMapping.FieldName;
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
