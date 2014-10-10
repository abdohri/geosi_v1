using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ext.Net;
using System.Threading;
using System.Globalization;
using System.Data.Odbc;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Personnel
{
    public partial class GeoForm : Form
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Personnel");
            this.PreSchema("Personnel", "personnelid");
            if (!X.IsAjaxRequest)
            {
                if (Request.HttpMethod == "POST")
                {

                    try
                    {
                        int retourSave = this.SaveFile(Request, this.photo1);

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
                    else
                    {
                        photo.Hidden = true;
                    }

                    string _type = "select typepersonnelid,libelle from par_typepersonnel where clientid=-1 or clientid=" + this.getCurrentUser().getClientId();
                    this.FillStore(_type, this.Store3);


                }
            }
        }

    }
}
