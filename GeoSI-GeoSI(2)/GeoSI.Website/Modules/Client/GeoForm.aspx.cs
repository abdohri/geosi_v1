using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using Ext.Net;

namespace GeoSI.Website.Modules.Client
{
    public partial class GeoForm : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PreSchema("client", "clientid");


            if (!X.IsAjaxRequest)
            {
                // Dans le cas d'ajout d'un nouvel élement
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        int retourSave = this.SaveFile(Request, this.logo1);
                        if (Request.Params.Get("clientid") == "")
                        {
                            if (retourSave != -1)
                            {
                                string _req = "insert into groupe values('" + Request.Params.Get("raison_sociale") + "',0," + retourSave + ",1,'" + DateTime.Now + "')";
                                int retourinsert = this.Insert(_req);
                            }
                        }
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
                        this.raison_sociale.Disabled=true;

                    }
                    else
                    {
                        this.logo.Hidden = true;
                        

                    }
                }
                // Remplissage des combobox existant dans la forme
                this.FillStore("SELECT cartegeographieid,libelle  FROM cartegeographique", this.StoreComboboxcarte);
                this.FillStore("SELECT langueid,libelle  FROM langue", this.StoreComboboxlangue);
                this.FillStore("SELECT profilclientid,libelle  FROM profilclient", this.StoreComboboxProfilclient);
                this.FillStore("SELECT paysid,pays  FROM pays", this.StoreComboboxPays);
                this.FillStore("SELECT villeid,ville  FROM ville", this.StoreComboboxVille);
                this.FillStore("SELECT juridiqueid,juridique  FROM juridique", this.StoreComboboxJuridique);
                this.FillStore("SELECT typeabonnementid,typeabonnement  FROM par_typeabonnement", this.StoreComboboxTypeAbonnement);
                this.FillStore("SELECT societe_mereid,societe_mere  FROM societe_mere", this.StoreComboboxSociteMere);
                this.FillStore("SELECT bourseid,bourse  FROM bourse", this.StoreComboboxBourse);
                this.FillStore("SELECT carte_dataid,carte_data  FROM carte_data", this.StoreComboboxCarteData);
            }
        }
    }
}