using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GeoSI.Website.Modules.Deconnexion
{
    public partial class Deconnexion1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
           // Response.BufferOutput = true;
            Response.Redirect("../Login/Login.aspx");

        }
    }
}