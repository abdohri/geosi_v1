using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Deconnexion
{
    public partial class Deconnexion : PageBase
    {
        protected void Page_PreLoad(object sender, EventArgs e)
        {
            int _TypeCompte = this.getCurrentUser().getTypeCompte();
            if (_TypeCompte == 1)//BackOffice
            {
                Session["UserInfo"] = null;
                Session["HabilitationAction"] = null;
                Response.Redirect("../Login/BackOffice.aspx",true);
            }
            else if (_TypeCompte == 2)//Revendeur
            {
                Session["UserInfo"] = null;
                Session["HabilitationAction"] = null;
                Response.Redirect("../Login/Revendeur.aspx",true);
            }
            else if (_TypeCompte == 3)//Client
            {
                Session["UserInfo"] = null;
                Session["HabilitationAction"] = null;
                Response.Redirect("../Login/Login.aspx",true);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}