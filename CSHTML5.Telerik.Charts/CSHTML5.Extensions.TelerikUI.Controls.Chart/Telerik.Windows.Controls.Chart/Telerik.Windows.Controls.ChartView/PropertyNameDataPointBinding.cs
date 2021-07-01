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
        //public static readonly DependencyProperty PropertyNameProperty = DependencyProperty.Register("PropertyNameProperty", typeof(string), typeof(PropertyNameDataPointBinding), null);

        //public string PropertyName
        //{
        //    get { return (string)this.GetValue(PropertyNameDataPointBinding.PropertyNameProperty); }
        //    set { this.SetValue(PropertyNameDataPointBinding.PropertyNameProperty, (object)value); }
        //}


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

        private void OnPropertyChanged(string v)
        {
            throw new NotImplementedException();
        }

        //      public PropertyNameDataPointBinding()
        //{
        //}

        //public PropertyNameDataPointBinding(string propertyName)
        //{
        //	PropertyName = propertyName;
        //}

        //public override object GetValue(object instance)
        //{
        //	if (instance == null)
        //	{
        //		throw new ArgumentNullException("instance");
        //	}
        //	if (string.IsNullOrEmpty(propertyName))
        //	{
        //		throw new ArgumentException("PropertyName not specified.");
        //	}
        //	Type type = instance.GetType();
        //	if (TypeExtensions.IsCustomTypeProvider(type))
        //	{
        //		return CustomTypeProviderExtensions.Property<object>(instance, propertyName);
        //	}
        //	if (getter == null || !object.ReferenceEquals(getterInstanceType, type))
        //	{
        //		getter = DynamicHelper.CreatePropertyValueGetter(type, propertyName);
        //		getterInstanceType = type;
        //	}
        //	return getter(instance);
        //}

        //internal override EnumerableSelectorAggregateFunctionExpressionBuilderBase CreateExpressionBuilder(Expression enumerableExpression, EnumerableSelectorAggregateFunction function)
        //{
        //	//IL_0021: Unknown result type (might be due to invalid IL or missing references)
        //	//IL_0027: Expected O, but got Unknown
        //	if (function.get_SourceField() != propertyName)
        //	{
        //		function.set_SourceField(propertyName);
        //	}
        //	return (EnumerableSelectorAggregateFunctionExpressionBuilderBase)new EnumerableSelectorAggregateFunctionExpressionBuilder(enumerableExpression, function);
        //}

        //internal override AggregatedGroupDescriptorBase CreateDateTimeGroupDescriptor()
        //{
        //	ChartDateTimeGroupDescriptor chartDateTimeGroupDescriptor = new ChartDateTimeGroupDescriptor();
        //	((GroupDescriptor)chartDateTimeGroupDescriptor).set_Member(propertyName);
        //	((GroupDescriptor)chartDateTimeGroupDescriptor).set_MemberType(typeof(DateTime));
        //	return (AggregatedGroupDescriptorBase)(object)chartDateTimeGroupDescriptor;
        //}
    }
}
