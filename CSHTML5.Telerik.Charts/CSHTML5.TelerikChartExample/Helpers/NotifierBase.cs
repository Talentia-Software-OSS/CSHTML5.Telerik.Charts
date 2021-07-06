using System.ComponentModel;

namespace CSHTML5.TelerikChartExample.Views
{
    public class NotifierBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Fires the property changed.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void OnPropertyChanged(string propertyName)
        {
            // work on a local (threadsafe between the if and the call)
            PropertyChangedEventHandler handler = _propertyChangedHandler;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        PropertyChangedEventHandler _propertyChangedHandler;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add { _propertyChangedHandler += value; }
            remove { _propertyChangedHandler -= value; }
        }
    }

}
