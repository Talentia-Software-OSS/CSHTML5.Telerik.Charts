//-------------------------------------//
//-------------- USINGS ---------------//
//-------------------------------------//
using System.Windows;
using System;
//-------------------------------------//
//-------------------------------------//
//-------------------------------------//

namespace Telerik.Windows.Controls.ChartView
{
    public class ChartTrackBallBehavior : ChartBehavior
    {
        //-------------------------------------//
        //-------------- FIELDS ---------------//
        //-------------------------------------//
        public static readonly DependencyProperty ShowTrackInfoProperty = DependencyProperty.Register("ShowTrackInfoProperty", typeof(bool), typeof(ChartTrackBallBehavior), null);
        public static readonly DependencyProperty ShowIntersectionPointsProperty = DependencyProperty.Register("ShowIntersectionPointsProperty", typeof(bool), typeof(ChartTrackBallBehavior), null);
        public static readonly DependencyProperty SnapModeProperty = DependencyProperty.Register("SnapModeProperty", typeof(TrackBallSnapMode), typeof(ChartTrackBallBehavior), null);
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------ PROPERTIES -------------//
        //-------------------------------------//
        public bool ShowTrackInfo
        {
            get { return (bool)this.GetValue(ChartTrackBallBehavior.ShowTrackInfoProperty); }
            set { this.SetValue(ChartTrackBallBehavior.ShowTrackInfoProperty, (object)value); }
        }
        public bool ShowIntersectionPoints
        {
            get { return (bool)this.GetValue(ChartTrackBallBehavior.ShowIntersectionPointsProperty); }
            set { this.SetValue(ChartTrackBallBehavior.ShowIntersectionPointsProperty, (object)value); }
        }
        public TrackBallSnapMode SnapMode
        {
            get { return (TrackBallSnapMode)this.GetValue(ChartTrackBallBehavior.SnapModeProperty); }
            set { this.SetValue(ChartTrackBallBehavior.SnapModeProperty, (object)value); }
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

        //-------------------------------------//
        //------------- METHODS ---------------//
        //-------------------------------------//
        public ChartTrackBallBehavior()
        {
        }
        //-------------------------------------//
        //-------------------------------------//
        //-------------------------------------//

    }
}
