using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;

namespace CSHTML5.TelerikChartExample.Views
{
    public partial class RadPolarChart : Page
    {
        public RadPolarChart()
        {
            this.InitializeComponent();
        }

        private void Button_Click_PolarChart(object sender, RoutedEventArgs e)
        {
            // set piechart data on refresh
            ExamplePolarChart.Refresh();
        }
    }
}
