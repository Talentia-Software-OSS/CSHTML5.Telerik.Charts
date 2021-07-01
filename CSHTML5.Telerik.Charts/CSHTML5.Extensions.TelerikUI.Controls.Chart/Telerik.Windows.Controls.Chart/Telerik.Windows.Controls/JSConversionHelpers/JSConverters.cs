using CSHTML5;
using CSHTML5.Wrappers.KendoUI.Common;
using System;
using System.Collections.Generic;
using System.Text;
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
                return string.Format((propertyValue is DateTime) ? "new Date({0})" : "'{0}'", propertyValue.ToString());
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
    }
}