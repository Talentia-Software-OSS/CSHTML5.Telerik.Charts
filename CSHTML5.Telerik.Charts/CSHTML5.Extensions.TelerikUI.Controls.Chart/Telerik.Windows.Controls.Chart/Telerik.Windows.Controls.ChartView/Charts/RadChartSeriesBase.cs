using JSConversionHelpers;
using kendo_ui_chart.kendo.dataviz.ui;
using System.Collections.Generic;
using System.Windows;

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

            SetKendoSeriesTooltip(chartSeries, seriesItem);

            return propertyFields;
        }

        protected virtual void SetKendoSeriesTooltip(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            if (chartSeries.Tooltip != null)
            {
                seriesItem.tooltip = new ChartSeriesItemTooltip();

                seriesItem.tooltip.visible = chartSeries.Tooltip.Visibility == Visibility.Visible;
                // set bg
                if (chartSeries.Tooltip.Background != null)
                {
                    seriesItem.tooltip.background = JSConverters.GetStringToSetAsColor(chartSeries.Tooltip.Background);
                }

                if (chartSeries.Tooltip.Color != null)
                {
                    seriesItem.tooltip.color = JSConverters.GetStringToSetAsColor(chartSeries.Tooltip.Color);
                }

                if (chartSeries.Tooltip.FontFamily != null)
                {
                    seriesItem.tooltip.font = string.Format("{0:0}px {1}", chartSeries.Tooltip.FontSize, chartSeries.Tooltip.FontFamily.ToString().ToLower());
                }

                if (chartSeries.Tooltip.BorderThickness != null || chartSeries.Tooltip.BorderBrush != null)
                {
                    seriesItem.tooltip.border = new ChartSeriesItemTooltipBorder();

                    if (chartSeries.Tooltip.BorderThickness != null)
                    {
                        seriesItem.tooltip.border.width = JSConverters.GetBorderWidthFromThickness(chartSeries.Tooltip.BorderThickness);
                    }

                    if (chartSeries.Tooltip.BorderBrush != null)
                    {
                        seriesItem.tooltip.border.color = JSConverters.GetStringToSetAsColor(chartSeries.Tooltip.BorderBrush);
                    }
                }

                if (chartSeries.Tooltip.Format != null)
                {
                    seriesItem.tooltip.format = chartSeries.Tooltip.Format;
                }
            }
        }

    }
}
