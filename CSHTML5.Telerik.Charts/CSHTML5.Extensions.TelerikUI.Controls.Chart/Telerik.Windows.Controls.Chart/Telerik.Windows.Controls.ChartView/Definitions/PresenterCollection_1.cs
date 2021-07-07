//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.Collections.ObjectModel;
using System.Windows;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public class PresenterCollection<T> : ObservableCollection<T>
		where T : PresenterBase
	{
        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        internal PresenterCollection() : base()
        {
        }
		//-------------------------------------//
		//-------------------------------------//
		//-------------------------------------//

		private RadChartBase _chart;

		internal PresenterCollection(RadChartBase control)
		{
			_chart = control;
            _chart.DataContextChanged += Chart_DataContextChanged;
		}

        private void Chart_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foreach(var item in Items)
            {
				item.DataContext = e.NewValue;
            }
        }

        protected override void InsertItem(int index, T item)
		{
			base.InsertItem(index, item);
			if (_chart != null)
			{
				item.DataContext = _chart.DataContext;
				//_chart.OnPresenterAdded(item);
			}
		}

		protected override void RemoveItem(int index)
		{
			T t = base[index];
			base.RemoveItem(index);
			//_chart.OnPresenterRemoved(t);
		}
	
		protected override void ClearItems()
		{
			T[] array = new T[base.Items.Count];
			base.Items.CopyTo(array, 0);
			base.ClearItems();
			T[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				T t = array2[i];
				//this._chart.OnPresenterRemoved(t);
			}
		}

		protected override void SetItem(int index, T item)
		{
			T t = base[index];
			base.SetItem(index, item);
			//this._chart.OnPresenterRemoved(t);
			//this._chart.OnPresenterAdded(item);
		}

	}
}
