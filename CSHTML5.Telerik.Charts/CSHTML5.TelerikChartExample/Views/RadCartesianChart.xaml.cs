using CSHTML5.TelerikChartExample.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public partial class RadCartesianChart : Page
    {
        private CartesianChartViewModel<RadCartesianChart, DTPoint> _carthesianChartViewModel;

        public RangeObservableCollection<BrokenViewModel> BrokenItems = new RangeObservableCollection<BrokenViewModel>();

        public class DTPoint
        {
            public DateTime XValue { get; set; }
            public double YValue { get; set; }
        }

        static Random random = new Random();
        //private RadObservableCollection<DTPoint> centerAvgGraph = new RadObservableCollection<DTPoint>();
        private float MaxScale;
        private double MaxY;

        public RadCartesianChart()
        {
            this.InitializeComponent();
            Loaded += SetReferencePeriod_Loaded;

            // create ViewModel
            _carthesianChartViewModel = new CartesianChartViewModel<RadCartesianChart, DTPoint>(
                this,
                GenerateRandomSerie(10, new DateTime(2000, 1, 1)),
                GenerateRandomSerie(5, new DateTime(2000, 1, 1)),
                GenerateRandomSerie(5, new DateTime(2000, 6, 1)),
                GenerateBarSerie(5, new DateTime(2000, 6, 1))
            );

            BrokenChart.DataContext = this;

            BrokenItems.AddRange(new List<BrokenViewModel>()
            {
                new BrokenViewModel() { Label = "In progress", Value = "14", Color = Color.Green },
                new BrokenViewModel() { Label = "To process", Value = "23", Color = Color.Blue },
                new BrokenViewModel() { Label = "Suspended", Value = "48", Color = Color.Red },
            }) ;
        }

        private void SetReferencePeriod_Loaded(object sender, RoutedEventArgs e)
        {
            // The chart is not really loaded here, we need a better loading event
            // TODO Better Loading event so that things get loaded into the charts
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MaxScale = 300;
            MaxY = MaxScale + 10.0;
            XAxis.MajorTickInterval = 2;
            YAxis.Maximum = MaxY;

            _carthesianChartViewModel.Series1.Clear();
            _carthesianChartViewModel.Series1 = GenerateRandomSerie(10, new DateTime(2000, 1, 1));

            // set piechart data on refresh
            ReferenceGraph.Refresh();
            BrokenChart.Refresh();
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

        private RadObservableCollection<DTPoint> GenerateBarSerie(int size, DateTime initialDateTime, double minValue = 0, double maxValue = 300, int intervalBetweenPoints = 1)
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
