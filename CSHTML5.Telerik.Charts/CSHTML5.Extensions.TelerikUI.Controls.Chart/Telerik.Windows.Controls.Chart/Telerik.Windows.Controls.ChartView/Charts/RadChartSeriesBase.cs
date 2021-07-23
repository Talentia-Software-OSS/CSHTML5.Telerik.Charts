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

        protected virtual List<DataPropertyMapping> GetPropertyFields(ChartSeries chartSeries, ChartSeriesItem seriesItem)
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

        protected virtual void SetKendoSeriesOptions(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            SetKendoSeriesTooltip(chartSeries, seriesItem);
            SetKendoSeriesLabel(chartSeries, seriesItem);
            SetKendoSeriesBorder(chartSeries, seriesItem);
            SetKendoSeriesAdditionalOptions(chartSeries, seriesItem);
        }

        protected virtual void SetKendoSeriesLabel(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            if (chartSeries.Label != null)
            {
                seriesItem.labels = new ChartSeriesItemLabels();

                seriesItem.labels.visible = chartSeries.Label.Visibility == Visibility.Visible;
                
                if (chartSeries.Label.Background != null)
                {
                    seriesItem.labels.background = JSConverters.GetStringToSetAsColor(chartSeries.Label.Background);
                }

                if (chartSeries.Label.Color != null)
                {
                    seriesItem.labels.color = JSConverters.GetStringToSetAsColor(chartSeries.Label.Color);
                }

                if (chartSeries.Label.FontFamily != null)
                {
                    seriesItem.labels.font = string.Format("{0:0}px {1}", chartSeries.Label.FontSize, chartSeries.Label.FontFamily.ToString().ToLower());
                }

                if (chartSeries.Label.BorderThickness != null || chartSeries.Label.BorderBrush != null)
                {
                    seriesItem.labels.border = new ChartSeriesItemLabelsBorder();

                    if (chartSeries.Label.BorderThickness != null)
                    {
                        seriesItem.labels.border.width = JSConverters.GetBorderWidthFromThickness(chartSeries.Label.BorderThickness);
                    }

                    if (chartSeries.Label.BorderBrush != null)
                    {
                        seriesItem.labels.border.color = JSConverters.GetStringToSetAsColor(chartSeries.Label.BorderBrush);
                    }
                }

                if (chartSeries.Label.Format != null)
                {
                    seriesItem.labels.format = chartSeries.Label.Format;
                }

                if (chartSeries.Label.LabelTemplate != null)
                {
                    seriesItem.labels.template = chartSeries.Label.LabelTemplate;
                }

                if (chartSeries.Label.Align != LabelAlignment.Default)
                {
                    seriesItem.labels.align = JSConverters.FirstCharToLowerCase(chartSeries.Label.Align.ToString());  // column, circle
                }

                if (chartSeries.Label.Position != LabelPosition.Default)
                {
                    seriesItem.labels.position = JSConverters.FirstCharToLowerCase(chartSeries.Label.Position.ToString());
                }
            }
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

                if (Tooltip.TooltipTemplate != null)
                {
                    seriesItem.tooltip.template = Tooltip.TooltipTemplate;
                }
            }
        }

        protected virtual void SetKendoSeriesBorder(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            if (chartSeries.Border != null)
            {
                seriesItem.border = new ChartSeriesItemBorder();

                if (chartSeries.Border.Color != null)
                {
                    seriesItem.border.color = JSConverters.GetStringToSetAsColor(chartSeries.Border.Color);
                }
                
                seriesItem.border.opacity = chartSeries.Border.Opacity;
                seriesItem.border.width = chartSeries.Border.Width;
                seriesItem.border.dashType = chartSeries.Border.DashType.ToString().ToLower();
            }
        }

        protected virtual void SetKendoSeriesAdditionalOptions(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
        }

    }
}
