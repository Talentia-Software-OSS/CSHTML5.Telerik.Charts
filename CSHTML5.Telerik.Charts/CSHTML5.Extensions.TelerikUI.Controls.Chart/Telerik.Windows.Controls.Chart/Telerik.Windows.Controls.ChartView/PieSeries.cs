
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Telerik.Windows.Controls.ChartView
{
    public class PieSeries : ChartSeries
    {
        //public static readonly DependencyProperty ValueBindingProperty = DependencyProperty.Register("ValueBindingProperty", typeof(DataTemplate), typeof(ChartSeries), null);

        //public DataTemplate ValueBinding
        //{
        //    get { return (DataTemplate)this.GetValue(ChartSeries.TrackBallInfoTemplateProperty); }
        //    set { this.SetValue(ChartSeries.TrackBallInfoTemplateProperty, (object)value); }
        //}

        public static readonly DependencyProperty ValueBindingProperty = DependencyProperty.Register("ValueBinding", typeof(DataPointBinding), typeof(PieSeries), (PropertyMetadata)new PropertyMetadata((object)null, (PropertyChangedCallback)OnValueBindingChanged));

        public DataPointBinding ValueBinding
        {
            get
            {
                return GetValue(ValueBindingProperty) as DataPointBinding;
            }
            set
            {
                SetValue(ValueBindingProperty, value);
            }
        }

        private static void OnValueBindingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
