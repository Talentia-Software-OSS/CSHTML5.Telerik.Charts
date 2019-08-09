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
        internal kendo_ui_chart.kendo.dataviz.ui.Chart _unsedChart; // Keep this line because it ensures that the startup project has a direct reference to the Kendo Chart project.

        public class DTPoint
        {
            public DateTime XValue { get; set; }
            public double YValue { get; set; }
        }

        static Random random = new Random();
        private RadObservableCollection<DTPoint> centerAvgGraph = new RadObservableCollection<DTPoint>();
        private float MaxScale, MinScale;
        private double MaxY;

        public MainPage()
        {
            InitializeComponent();
            Loaded += SetReferencePeriod_Loaded;
        }

        private void SetReferencePeriod_Loaded(object sender, RoutedEventArgs e)
        {
            ReferenceGraph.Series[0].ItemsSource = centerAvgGraph;
            MaxScale = 300;
            MaxY = MaxScale + 10.0;
            displayGraph();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            displayGraph();
        }

        private void displayGraph()
        {
            centerAvgGraph.Clear();
            centerAvgGraph = GenerateRandomSerie(10, new DateTime(2000, 1, 1));
            XAxis.MajorTickInterval = 2;
            MaxY = MaxScale + 10.0;
            YAxis.Maximum = MaxY;
            ReferenceGraph.Series[0].ItemsSource = centerAvgGraph;
            ReferenceGraph.Series[1].ItemsSource = GenerateRandomSerie(5, new DateTime(2000, 1, 1));
            ReferenceGraph.Series[2].ItemsSource = GenerateRandomSerie(5, new DateTime(2000, 6, 1));
        }

        private RadObservableCollection<DTPoint> GenerateRandomSerie(int size, DateTime initialDateTime, double minValue = 0, double maxValue = 300, int intervalBetweenPoints = 1)
        {
            RadObservableCollection<DTPoint> serie = new RadObservableCollection<DTPoint>();
            DateTime currentDate = initialDateTime;
            Random rd = new Random(random.Next());
            for (int i = 0; i < size; i++)
            {
                DTPoint point = new DTPoint
                {
                    XValue = currentDate,
                    YValue = rd.NextDouble() * (maxValue - minValue) + minValue,
                };
                serie.Add(point);
                currentDate = currentDate.AddMonths(intervalBetweenPoints);
            }
            return serie;
        }
    }
}

