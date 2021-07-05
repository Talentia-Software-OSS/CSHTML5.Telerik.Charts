using CSHTML5;
using CSHTML5.Wrappers.KendoUI.Common;
using kendo_ui_chart.kendo.dataviz.ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using Telerik.Windows.Controls.ChartView;
using TypeScriptDefinitionsSupport;

namespace JSConversionHelpers {
    public class DataPropertyMapping
    {
        public string PropName;
        public string FieldName;

        #region Contructors
        public DataPropertyMapping(string fieldName)
        {
            FieldName = fieldName;
        }

        public DataPropertyMapping(string propName, string fieldName) : this(fieldName)
        {
            PropName = propName;
        }
        #endregion

        #region Methods
        public string GetPropertyName()
        {
            return string.IsNullOrEmpty(PropName) ? FieldName : PropName;
        }

        public string GetPropertyValueAsString(object cSharpItem)
        {
            object propertyValue = Utils.GetNestedPropertyValue(cSharpItem, GetPropertyName());

            if (propertyValue != null)
            {
                switch (Type.GetTypeCode(propertyValue.GetType()))
                {
                    case TypeCode.DateTime:
                        return string.Format("new Date('{0}')", propertyValue.ToString());
                    case TypeCode.String:
                        return string.Format("'{0}'", propertyValue.ToString());
                    default:
                        return string.Format("{0}", propertyValue.ToString());
                }
            }

            return null;
        }
        #endregion
    }

    public static class JSConverters
    { 
        public static string GetObjectWithPresetPropertiesAsString(object cSharpItem, List<DataPropertyMapping> propertiesToPutInResult)
        {
            StringBuilder sb = new StringBuilder("");

            sb.Append("{");
            foreach (DataPropertyMapping property in propertiesToPutInResult)
            {
                string propertyName = property.FieldName;
                string propertyValue = property.GetPropertyValueAsString(cSharpItem);

                if (propertyValue != null)
                {
                    sb.AppendFormat("'{0}': {1},", propertyName, propertyValue);
                }
            }
            sb.Append("}");

            return sb.ToString();
        }

        public static JSObject PrepareSeriesData(System.Collections.IEnumerable seriesData, List<DataPropertyMapping> propertiesToPutInResult)
        {
            object preparedSeriesData = Interop.ExecuteJavaScript("[]");

            StringBuilder sb = new StringBuilder("");
            foreach (var cSharpItem in seriesData)
            {
                sb.AppendFormat("$0.push({0});", GetObjectWithPresetPropertiesAsString(cSharpItem, propertiesToPutInResult));
            }
            Interop.ExecuteJavaScript(sb.ToString(), preparedSeriesData);

            return new JSObject(preparedSeriesData);
        }

        public static DataPropertyMapping SetColorSeriesOrGetColorMapping(ChartSeries chartSeries, ChartSeriesItem seriesItem)
        {
            if (chartSeries is CategoricalStrokedSeries)
            {
                var categoricalStrokedSeries = chartSeries as CategoricalStrokedSeries;
                SetSeriesItemColor(seriesItem, categoricalStrokedSeries.Stroke);

                if (chartSeries is AreaSeries)
                {
                    SetSeriesItemColor(seriesItem, ((AreaSeries)categoricalStrokedSeries).Fill);
                }
            } else if (chartSeries is CategoricalColorSeries)
            {
                DataPropertyMapping colorMapping = new DataPropertyMapping(((CategoricalColorSeries)chartSeries).ColorBinding?.PropertyPath ?? "Color");
                seriesItem.colorField = colorMapping.FieldName;
                
                return colorMapping;
            }

            return null;
        }

        public static void SetSeriesItemColor(ChartSeriesItem seriesItem, Brush color)
        {
            string colorToSet = GetStringToSetAsColor(color);
            if (colorToSet != null)
            {
                seriesItem.color = colorToSet;
            }
        }

        public static string GetStringToSetAsColor(Brush color)
        {
            if (color != null)
            {
                //todo: I don't remember if we have a good way of getting the string to set the css value from users' code.
                //todo: make it work with other brushes than SoliColorbrush (the attempt with LineargradientBrush didn't work although it works in the SL version).
                if (color is SolidColorBrush)
                {
                    return (string)((SolidColorBrush)color).ConvertToCSSValue();
                }
            }
            return null;
        }
    }
}