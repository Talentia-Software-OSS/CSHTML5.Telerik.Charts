//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using DotNetForHtml5.Core;
using System;
using System.ComponentModel;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public class DataPointBinding : INotifyPropertyChanged
    {

        static DataPointBinding()
        {
            TypeFromStringConverters.RegisterConverter(typeof(DataPointBinding), INTERNAL_ConvertFromString);
        }

        internal static object INTERNAL_ConvertFromString(string propertyPath)
        {
            return new DataPointBinding() { PropertyPath = propertyPath };
        }

        //-------------------------------------//
        //--------------- EVENTS --------------//
        //-------------------------------------//
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { }
            remove { }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        protected DataPointBinding()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        public string PropertyPath { get; set; }
    }
}
