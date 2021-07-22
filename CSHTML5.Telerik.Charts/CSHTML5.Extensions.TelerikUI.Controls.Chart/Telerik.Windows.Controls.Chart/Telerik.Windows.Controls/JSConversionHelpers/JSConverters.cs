using CSHTML5;
using CSHTML5.Wrappers.KendoUI.Common;
using kendo_ui_chart.kendo.dataviz.ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Media;
using Telerik.Windows.Controls;
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
                    default:
                        return string.Format("'{0}'", propertyValue.ToString());
                        /*
                        if (propertyValue.GetType().IsInstanceOfType(typeof(Color)))
                        {
                            return string.Format("'{0}'", propertyValue.ToString());
                        }
                        else
                        {
                            return string.Format("{0}", propertyValue.ToString());
                        }
                        */
                }
            }

            return null;
        }
        #endregion
    }

    public static class JSConverters
    { 
        public enum JSAlignment
        {
            start,
            center,
            end
        }

        public static string FirstCharToLowerCase(string str)
        {
            if (string.IsNullOrEmpty(str) || char.IsLower(str[0]))
                return str;

            return char.ToLower(str[0]) + str.Substring(1);
        }

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

            return preparedSeriesData as JSObject ?? new JSObject(preparedSeriesData);
            //return new JSObject(preparedSeriesData);
        }

        public static string GetFieldNameFromProperty(DataPointBinding dataBinding)
        {
            return (dataBinding is PropertyNameDataPointBinding) ? ((PropertyNameDataPointBinding)dataBinding)?.PropertyName : dataBinding?.PropertyPath;
        }

        #region Position Alignment
        public static JSAlignment GetAlignment(LegendPosition position, VerticalAlignment verticalAlignment, HorizontalAlignment horizontalAlignment)
        {
            switch (position)
            {
                case LegendPosition.Top:
                case LegendPosition.Bottom:
                    return GetHorizontalAlignment(horizontalAlignment);
                case LegendPosition.Left:
                case LegendPosition.Right:
                    return GetVerticalAlignment(verticalAlignment);
                default:
                    return JSAlignment.center;
            }
        }

        private static JSAlignment GetVerticalAlignment(VerticalAlignment verticalAlignment)
        {
            switch (verticalAlignment)
            {
                case VerticalAlignment.Top:
                    return JSAlignment.start;
                case VerticalAlignment.Bottom:
                    return JSAlignment.end;
                case VerticalAlignment.Center:
                default:
                    return JSAlignment.center;
            }
        }

        public static JSAlignment GetHorizontalAlignment(HorizontalAlignment horizontalAlignment)
        {
            switch (horizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    return JSAlignment.start;
                case HorizontalAlignment.Right:
                    return JSAlignment.end;
                case HorizontalAlignment.Center:
                default:
                    return JSAlignment.center;
            }
        }
        #endregion

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
                var colorPropertyName = JSConverters.GetFieldNameFromProperty(((CategoricalColorSeries)chartSeries).ColorBinding);
                DataPropertyMapping colorMapping = new DataPropertyMapping(colorPropertyName ?? "Color");
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

        public static double GetBorderWidthFromThickness(Thickness thickness)
        {
            return thickness != null ? thickness.Top : 0;
        }
    }
}