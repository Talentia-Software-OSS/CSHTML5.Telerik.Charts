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
using Telerik.Windows.Data;

namespace CSHTML5.TelerikChartExample.Views
{
    public class PolarChartViewModel<TChartPage, TChartSeries> : NotifierBase
        where TChartPage : Page
    {
        RadObservableCollection<TChartSeries> _series1 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series1
        {
            get { return _series1; }
            set { _series1 = value; OnPropertyChanged("Series1"); }
        }

        RadObservableCollection<TChartSeries> _series2 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series2
        {
            get { return _series2; }
            set { _series2 = value; OnPropertyChanged("Series2"); }
        }

        RadObservableCollection<TChartSeries> _series3 = new RadObservableCollection<TChartSeries>();
        public RadObservableCollection<TChartSeries> Series3
        {
            get { return _series3; }
            set { _series3 = value; OnPropertyChanged("Series3"); }
        }

        public PolarChartViewModel(
            TChartPage page, 
            RadObservableCollection<TChartSeries> series1,
            RadObservableCollection<TChartSeries> series2,
            RadObservableCollection<TChartSeries> series3
        )
        {
            page.DataContext = this;

            this.Series1 = series1;
            this.Series2 = series2;
            this.Series3 = series3;
        }
    }

    public partial class RadPolarChart : Page
    {
        private class DataPoint
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        private PolarChartViewModel<RadPolarChart, DataPoint> _polarChartViewModel;

        public RadPolarChart()
        {
            this.InitializeComponent();

            // define mockup data
            int[] testArr1 = new int[] { 0, 0, 15, 2, 30, 4, 45, 6, 60, 8, 75, 10, 90, 12, 105, 14, 120, 16, 135, 18, 150, 20, 165, 22, 180, 24, 195, 26, 210, 28, 225, 30, 240, 32, 255, 34, 270, 36, 285, 38, 300, 40, 315, 42, 330, 44, 345, 46, 360, 48, 15, 50, 30, 52, 45, 54, 60, 56, 75, 58, 90, 60 };
            int[] testArr2 = new int[] { 0, 0, 15, 1, 30, 2, 45, 3, 60, 4, 75, 5, 90, 6, 105, 7, 120, 8, 135, 9, 150, 10, 165, 11, 180, 12, 195, 13, 210, 14, 225, 15, 240, 16, 255, 17, 270, 18, 285, 19, 300, 20, 315, 21, 330, 22, 345, 23, 360, 24, 15, 25, 30, 26, 45, 27, 60, 28, 75, 29, 90, 30 };
            int[] testArr3 = new int[] { 0, 0, 15, 3, 30, 6, 45, 9, 60, 12, 75, 15, 90, 18, 105, 21, 120, 24, 135, 27, 150, 30, 165, 33, 180, 36, 195, 39, 210, 42, 225, 45, 240, 48, 255, 51, 270, 54, 285, 57, 300, 60, 315, 63, 330, 66, 345, 69, 360, 72, 15, 75, 30, 78, 45, 81, 60, 84, 75, 87, 90, 90 };
            
            // create ViewModel
            _polarChartViewModel = new PolarChartViewModel<RadPolarChart, DataPoint>(
                this, 
                GetSerie(testArr1),
                GetSerie(testArr2),
                GetSerie(testArr3)
            );
        }

        private void Button_Click_PolarChart(object sender, RoutedEventArgs e)
        {
            // set piechart data on refresh
            ExamplePolarChart.Refresh();
        }
        private static RadObservableCollection<DataPoint> GetSerie(int[] testArr)
        {
            RadObservableCollection<DataPoint> serie = new RadObservableCollection<DataPoint>();

            while (testArr.Length > 0)
            {
                int[] obj = testArr.Take(2).ToArray();
                serie.Add(new DataPoint() { X = obj[0], Y = obj[1] });
                testArr = testArr.Where((val, idx) => idx > 1).ToArray();
            }

            return serie;
        }

    }
}
