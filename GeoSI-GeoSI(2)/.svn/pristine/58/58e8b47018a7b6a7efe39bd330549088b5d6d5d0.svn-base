using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using Ext.Net;

namespace GeoSI.Website.Modules.Revendeur
{

    public partial class GeoForm : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreSchema("revendeur", "revendeurid");

            if (!X.IsAjaxRequest)
            {
                // Dans le cas d'ajout d'un nouvel élement
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        int retourSave = this.SaveFile(Request, this.logo1);

                    }
                    catch
                    {
                    }
                    Response.Write("<script>parent.location.reload();</script>");
                }

                      // Dans le cas de la modification d'un élement existant
                else
                {
                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm);
                        //this.pwd.Text = "password";
                    }
                    else
                    {
                        logo.Hidden = true;
                    }
                }
                // Remplissage des combobox existant dans la forme
                this.FillStore("SELECT langueid,libelle  FROM langue", this.StoreComboboxlangue);
                this.FillStore("SELECT paysid,pays  FROM pays", this.StoreComboboxPays);
                this.FillStore("SELECT villeid,ville  FROM ville", this.StoreComboboxVille);
            }
        }
    }
}