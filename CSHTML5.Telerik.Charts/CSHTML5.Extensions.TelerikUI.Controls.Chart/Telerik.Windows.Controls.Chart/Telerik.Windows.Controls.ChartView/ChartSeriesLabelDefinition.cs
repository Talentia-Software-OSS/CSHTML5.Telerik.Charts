//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.ComponentModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class ChartSeriesLabelDefinition
    {
		//private HorizontalAlignment? horizontalAlignment;

		//[TypeConverter(typeof(StringToDataPointBindingConverter))]
		//public DataPointBinding Binding { get; set; }

		//public string Format { get; set; }

		//public Thickness Margin { get; set; }

		//public HorizontalAlignment HorizontalAlignment
		//{
		//	get
		//	{
		//		if (!horizontalAlignment.HasValue)
		//		{
		//			return HorizontalAlignment.Center;
		//		}
		//		return horizontalAlignment.Value;
		//	}
		//	set
		//	{
		//		horizontalAlignment = value;
		//	}
		//}

		//public VerticalAlignment VerticalAlignment { get; set; }

		public DataTemplate Template { get; set; }

		public DataTemplateSelector TemplateSelector { get; set; }

		//public Style DefaultVisualStyle { get; set; }

		//public ChartSeriesLabelStrategy Strategy { get; set; }
	}
}