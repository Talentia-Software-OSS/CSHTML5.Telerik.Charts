using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CSHTML5;
using CSHTML5.Internal;
using CSHTML5.Migration.Wrappers.KendoUI.Charts;
using CSHTML5.Wrappers.KendoUI.Common;
using TypeScriptDefinitionsSupport;

namespace kendo_ui_chart.kendo.dataviz.ui
{
    public partial class Chart : JSComponent
    {
        private static void LoadKendoUILibraries()
        {
            Configuration.LocationOfKendoAllJS = "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/scripts/kendo.all.min.js";
            Configuration.LocationOfKendoCommonMaterialCSS = "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/styles/kendo.common-material.min.css";
            Configuration.LocationOfKendoMaterialCSS = "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/styles/kendo.material.min.css";
            Configuration.LocationOfKendoMaterialMobileCSS = "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/styles/kendo.material.mobile.min.css";
            Configuration.LocationOfKendoRTLCSS = "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/styles/kendo.rtl.min.css";
        }

        public static Configuration Configuration = new Configuration();

        public static JSLibrary JSLibraryInstance;

        static Chart()
        {
            LoadKendoUILibraries();
            JSLibraryInstance = new JSLibrary(
                    css: new Interop.ResourceFile[]
                    {
                        new Interop.ResourceFile("kendo.common-material", Configuration.LocationOfKendoCommonMaterialCSS), // e.g. "ms-appx:///CSHTML5.Wrappers.KendoUI.Grid/styles/kendo.common-material.min.css"
                        new Interop.ResourceFile("kendo.material", Configuration.LocationOfKendoMaterialCSS), // e.g. "ms-appx:///CSHTML5.Wrappers.KendoUI.Grid/styles/kendo.material.min.css"
                        new Interop.ResourceFile("kendo.material.mobile", Configuration.LocationOfKendoMaterialMobileCSS), // e.g. "ms-appx:///CSHTML5.Wrappers.KendoUI.Grid/styles/kendo.material.mobile.min.css"
                        new Interop.ResourceFile("kendo.rtl", Configuration.LocationOfKendoRTLCSS) // e.g. "ms-appx:///CSHTML5.Wrappers.KendoUI.Grid/styles/kendo.rtl.min.css"
                    },
                    js: new Interop.ResourceFile[]
                    {
                        new Interop.ResourceFile("jQuery", "ms-appx:///CSHTML5.Migration.Wrappers.KendoUI.Charts/scripts/jquery.min.js"),
                        new Interop.ResourceFile("kendo", Configuration.LocationOfKendoAllJS) // e.g. "ms-appx:///CSHTML5.Wrappers.KendoUI.Grid/scripts/kendo.all.min.js"
                    }
                );
            JSLibraryInstance.Load();
        }

        static JSLibrary _jsLibrary;
        public override JSLibrary JSLibrary { get { return _jsLibrary; } }

        partial void Initialize()
        {
            LoadKendoUILibraries();
            base.Initialize(initJSInstance: true);
        }
        protected override void InitializeJSInstance()
        {
            this.UnderlyingJSInstance = Chart.New(new JSObject(this.DomElement));
        }

        protected override void JSComponent_Loaded(object sender, RoutedEventArgs e)
        {
            if (Configuration.AreSourcesSet)
            {
                _jsLibrary = JSLibraryInstance;
                if (_jsLibrary.IsLoaded)
                {
                    JsLibrary_LibraryLoaded(true);
                }
                else
                {
                    _jsLibrary.LibraryLoaded += JsLibrary_LibraryLoaded;
                }
            }
            else
            {
                this.Html = @"Before you can use the Kendo Chart Control, you must add to your project the corresponding libraries.
To do so, please follow the tutorial at: http://www.cshtml5.com";
                MessageBox.Show(@"Before you can use the Kendo Chart Control, you must add to your project the corresponding libraries.
To do so, please follow the tutorial at: http://www.cshtml5.com"); //todo: put the address of the tutorial.
                base.AbortLoading();
            }
        }

        private void JsLibrary_LibraryLoaded(bool result)
        {
            if (result)
            {
                if (this.initJSInstance)
                    this.InitializeJSInstance();
                // Using a Dispatcher because we need the component to be fully loaded before being able to properly modify the visual tree (we might meet uninitialized elements otherwise).
                // before this fix (2019/01/28), the Sample Showcase can display such an error when clicking on Third Party -> Telerik Kendo UI -> Grid then reclicking Grid
                Dispatcher.BeginInvoke(() =>
                {
                    this.jsInstanceLoaded.SetResult(true);

                    this.OnJSInstanceLoaded();
                });
            }
            else
            {
                this.jsInstanceLoaded.SetResult(false);
            }
        }

        private INTERNAL_DispatcherQueueHandler _dispatcherQueueToRefreshTheChart = new INTERNAL_DispatcherQueueHandler();
        public void Refresh()
        {
            _dispatcherQueueToRefreshTheChart.QueueActionIfQueueIsEmpty(() =>
            {
                redraw();
            });
        }
    }
}
