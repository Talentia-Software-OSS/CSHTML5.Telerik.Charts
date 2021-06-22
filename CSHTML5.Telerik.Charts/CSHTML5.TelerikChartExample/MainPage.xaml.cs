using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Data;
using System.Windows.Input;

/// <summary>
/// code behind SetReferencePeriod
/// </summary>
namespace CSHTML5.TelerikChartExample
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void MenuListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                Frame.Navigate(new Uri($"/{e.AddedItems[0]}", UriKind.Relative));
            }
        }
    }
}

