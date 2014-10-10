using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.UserBackOffice
{
    public partial class GeoForm : Form
    {
        //Chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("UserBackOffice");
            this.PreSchema("userbackoffice", "userbackofficeid");
            if (!X.IsAjaxRequest)
            {
                // Dans le cas d'ajout d'un nouvel élement
                if (Request.HttpMethod == "POST")
                {

                    try
                    {
                        int retourSave = this.Save(Request);

                        if (retourSave != -1)
                        {
                            Response.Write("<script>parent.location.reload();</script>");
                        }
                        else
                        {
                            msgErreur.Html = "<div id=\"erreur\">un problème est survenu veuillez ressayer ulterieurement</div>";
                        }

                    }
                    catch
                    {
                    }

                }
                else
                {
                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm);
                    }

                }
            }
        }

    }
}
