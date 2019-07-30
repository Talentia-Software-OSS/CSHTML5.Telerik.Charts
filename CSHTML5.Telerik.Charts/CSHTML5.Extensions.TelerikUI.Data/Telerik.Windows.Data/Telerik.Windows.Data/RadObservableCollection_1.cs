//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Data
{
    public class RadObservableCollection<T> : ObservableCollection<T>, ISuspendNotifications
    {
        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public RadObservableCollection()
        {
        }
        public RadObservableCollection(IEnumerable<T> @collection)
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
