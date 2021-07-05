namespace Telerik.Windows.Controls.ChartView
{
    public abstract class RadChartSeriesBase<T> : RadChartBase where T : ChartSeries
    {
        protected PresenterCollection<T> _series;
        public PresenterCollection<T> Series
        {
            get { return _series; }
        }

        public RadChartSeriesBase() : base()
        {
            _series = new PresenterCollection<T>();
            _series.CollectionChanged += Series_CollectionChanged;
        }

        private void Series_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            //When we add a CartesianChart, we set its ParentChart to this, when we remove one, we set it to null:
            if (e.OldItems != null)
            {
                foreach (object serieAsObject in e.OldItems)
                {
                    ((T)serieAsObject).ParentChart = null;
                }
            }
            if (e.NewItems != null)
            {
                foreach (object serieAsObject in e.NewItems)
                {
                    ((T)serieAsObject).ParentChart = this;
                }
            }
        }
    }
}
