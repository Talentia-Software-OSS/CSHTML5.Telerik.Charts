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
        #region Unused
        internal kendo_ui_chart.kendo.dataviz.ui.Chart _unsedChart;
        #endregion

        static Random random = new Random();
        #region variables
        public class DTPoint
        {
            public DateTime XValue { get; set; }
            public double YValue { get; set; }
        }
        public enum PeriodType
        {
            Day,
            Week,
            Month,
            Year,
        }

        private Dictionary<DateTime, int> dateDictionary = new Dictionary<DateTime, int>();
        private RadObservableCollection<DTPoint> centerAvgGraph = new RadObservableCollection<DTPoint>();
        private int[] sourceIndices;
        private int sourceSize, sourceLeft, sourceRight, bufferSize, bufferLeft, bufferRight;
        private float sourceIncrement;
        private const int WINDOW_SIZE = 300; // used if aggregating
        private KeyValuePair<DateTime, double>[] averages;
        private float MaxScale, MinScale, previousSliderValue;
        private double MaxY;
        private bool lastDateSetting = false, usingNonGraphicMethod = false;

        #endregion

        #region start
        public MainPage()
        {
            this.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            this.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            InitializeComponent();
            Loaded += SetReferencePeriod_Loaded;
        }

        private RadObservableCollection<DTPoint> GenerateRandomSerie(int size, DateTime initialDateTime, double minValue = 0, double maxValue = 300, int intervalBetweenPoints = 1, PeriodType intervalType = PeriodType.Month)
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
                switch (intervalType)
                {
                    case PeriodType.Day:
                        currentDate = currentDate.AddDays(intervalBetweenPoints);
                        break;
                    case PeriodType.Week:
                        currentDate = currentDate.AddDays(intervalBetweenPoints * 7);
                        break;
                    case PeriodType.Month:
                        currentDate = currentDate.AddMonths(intervalBetweenPoints);
                        break;
                    case PeriodType.Year:
                        currentDate = currentDate.AddYears(intervalBetweenPoints);
                        break;
                }
            }
            return serie;
        }

        private void SetReferencePeriod_Loaded(object sender, RoutedEventArgs e)
        {
            ReferenceGraph.Series[0].ItemsSource = centerAvgGraph;
            MaxScale = 300;
            MaxY = MaxScale + 10.0;
            fillBuffers();
            ReferenceGraph.Visibility = System.Windows.Visibility.Visible;
            Focus();
        }
        #endregion

        private void fillBuffers()
        {
            int sourceIndex, bufferIndex;
            int windowSize = sourceRight - sourceLeft + 1;
            bufferSize = windowSize;
            averages = new KeyValuePair<DateTime, double>[bufferSize];
            sourceIndices = new int[bufferSize];
            for (bufferIndex = 0, sourceIndex = sourceLeft; sourceIndex <= sourceRight; sourceIndex++, bufferIndex++)
            {
                sourceIndices[bufferIndex] = sourceIndex;
            }
            sourceIncrement = 1F;

            bufferLeft = 0;
            bufferRight = bufferSize - 1;
            centerAvgGraph.Clear();
            fillGraph(!usingNonGraphicMethod);
        }

        private void fillGraph(bool useBufferDates = true)
        {
            centerAvgGraph = GenerateRandomSerie(10, new DateTime(2000, 1, 1));
            displayGraph(useBufferDates);
        }

        private void setYAxis()
        {
            MaxY = MaxScale + 10.0;
            YAxis.Maximum = MaxY;
        }

        private void setXAxis()
        {
            XAxis.MajorTickInterval = 2;
        }

        private void displayGraph(bool useBufferDates = true)
        {
            lastDateSetting = useBufferDates;
            setXAxis();
            setYAxis();
            ReferenceGraph.Series[0].ItemsSource = centerAvgGraph;
            SetBackgroundRanges();
        }

        private void SetBackgroundRanges()
        {
            ReferenceGraph.Series[1].ItemsSource = GenerateRandomSerie(5, new DateTime(2000, 1, 1));
            ReferenceGraph.Series[2].ItemsSource = GenerateRandomSerie(5, new DateTime(2000, 6, 1));
        }

        #region apply non graphics selection method
        private void ApplyNonGraphicSelectionMethod_Click(object sender, RoutedEventArgs e)
        {
            usingNonGraphicMethod = true;
            fillBuffers();
            usingNonGraphicMethod = false;
        }
        #endregion
    }
}

