using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls.ChartView;

namespace Telerik.Windows.Controls
{
	public class PropertyNameDataPointBinding : DataPointBinding
	{
        private string propertyName;

        private GetPropertyValueDelegate getter;

        //////private Type getterInstanceType;

        public string PropertyName
        {
            get
            {
                return propertyName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("value");
                }
                if (!(propertyName == value))
                {
                    getter = null;
                    propertyName = value;
                    OnPropertyChanged("PropertyName");
                }
            }
        }
    }
}
