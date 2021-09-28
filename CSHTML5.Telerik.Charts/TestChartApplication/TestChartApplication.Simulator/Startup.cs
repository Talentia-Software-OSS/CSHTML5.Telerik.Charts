using CSHTML5.TelerikChartExample;
using OpenSilver.Simulator;
using System;

namespace TestChartApplication.Simulator
{
    static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            return SimulatorLauncher.Start(typeof(App));
        }
    }
}
