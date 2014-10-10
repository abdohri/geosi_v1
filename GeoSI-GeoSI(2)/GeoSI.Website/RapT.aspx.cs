using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using GeoSI.Website.Common;
namespace GeoSI.Website
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            Rapports r = new Rapports();
           

            r.histo_trajet();
            Label1.Text = "Done good done";

        }
    }
}