using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSHTML5.Migration.Wrappers.KendoUI.Charts
{
    public class Configuration
    {
        /// <summary>
        /// Contains the path to the "kendo.all.min.js" file to use for the control.
        /// </summary>
        public string LocationOfKendoAllJS { get; set; }

        /// <summary>
        /// Contains the path to the "kendo.common-material.min.css" file to use for the control.
        /// </summary>
        public string LocationOfKendoCommonMaterialCSS { get; set; }

        /// <summary>
        /// Contains the path to the "kendo.material.min.css" file to use for the control.
        /// </summary>
        public string LocationOfKendoMaterialCSS { get; set; }

        /// <summary>
        /// Contains the path to the "kendo.material.mobile.min.css" file to use for the control.
        /// </summary>
        public string LocationOfKendoMaterialMobileCSS { get; set; }

        /// <summary>
        /// Contains the path to the "kendo.rtl.min.css" file to use for the control.
        /// </summary>
        public string LocationOfKendoRTLCSS { get; set; }

        internal bool AreSourcesSet
        {
            get
            {
                return (LocationOfKendoAllJS != null && LocationOfKendoCommonMaterialCSS != null && LocationOfKendoMaterialCSS != null && LocationOfKendoMaterialMobileCSS != null && LocationOfKendoRTLCSS != null);
            }
        }
    }
}
