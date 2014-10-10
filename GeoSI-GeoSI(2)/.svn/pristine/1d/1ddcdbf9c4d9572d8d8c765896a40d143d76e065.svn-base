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

namespace GeoSI.Website.Modules.CarteSim
{
    public partial class GeoForm : Form
    {// Chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("CarteSim");
            this.PreSchema("carte_sim", "cartesimid");
            if (!X.IsAjaxRequest)
            {// Dans le cas d'ajout d'un nouvel élement
                if (Request.HttpMethod == "POST")
                {

                    try
                    {
                        int returnAff = -1;
                        int retourSave = this.Save(Request);
                        if (retourSave != -1 && Request.Params.Get("BoitierId") != null && Request.Params.Get("BoitierId") != "")
                        {
                            returnAff = this.Affectation("cartesim_boitier", "cartesimid", "boitierid", retourSave, int.Parse(Request.Params.Get("BoitierId")));
                            if (returnAff == -1)
                            {
                                msgErreur.Html = "<div id=\"erreur\">un problème est survenu veuillez ressayer ulterieurement</div>";
                            }
                            else
                            {
                                Response.Write("<script>parent.location.reload();</script>");
                            }
                        }
                        else
                        {
                            if (retourSave != -1)
                            {
                                Response.Write("<script>parent.location.reload();</script>");
                            }
                            else
                            {
                                msgErreur.Html = "<div id=\"erreur\">un problème est survenu veuillez ressayer ulterieurement</div>";
                            }
                        }

                    }
                    catch
                    {
                    }

                }
                // Dans le cas de la modification d'un élement existant
                else
                {
                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm, this.getCurrentUser().getClientId());

                        string _reqcourante = "select s.numero_tel,b.imei,cb.date_affectation from cartesim_boitier cb,carte_sim s,boitier b where b.boitierid=cb.boitierid and s.cartesimid=cb.cartesimid and s.cartesimid=" + int.Parse(id) + " and s.clientid=" + this.getCurrentUser().getClientId() + " and cb.actif='1'";
                        this.AffectationCourante(_reqcourante, this.numeroserieLabel, this.boitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);

                        string _req3 = "select c.numero_tel,b.imei,cb.date_desaffectation,cb.date_affectation from cartesim_boitier cb,boitier b,carte_sim c where cb.boitierid=b.boitierid and cb.cartesimid=c.cartesimid and cb.cartesimid=" + int.Parse(id) + " and cb.Clientid=" + this.getCurrentUser().getClientId() + " and cb.actif='0' order by cb.id desc";
                        this.FillStore(_req3, this.Store1);
                    }
                    // Remplissage des combobox existant dans la forme
                    string _req1 = "select operateurid,libelle from par_operateur where clientid=-1 or ClientId=" + this.getCurrentUser().getClientId();
                    this.FillStore(_req1, this.Store2);

                    string _req2 = "select boitierid ,imei from boitier where ClientId=" + this.getCurrentUser().getClientId() + " and BoitierId NOT IN (select BoitierId from cartesim_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
                    this.FillStore(_req2, this.Store4);
                }
            }
        }
        // Actualisation les affectations  boitier
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req2 = "select boitierid ,imei from boitier where ClientId=" + this.getCurrentUser().getClientId() + " and BoitierId NOT IN (select BoitierId from cartesim_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_req2, this.Store4);

            string _req3 = "select c.numero_tel,b.imei from cartesim_boitier cb,boitier b,carte_sim c where cb.boitierid=b.boitierid and cb.cartesimid=c.cartesimid and cb.cartesimid=" + int.Parse(this.cartesimid.Text) + " and cb.Clientid=" + this.getCurrentUser().getClientId() + " and cb.actif='0' order by cb.id desc";
            this.FillStore(_req3, this.Store1);
        }
        //Désaffectation d'un boitier
        protected void Desaffectation(object sender, DirectEventArgs e)
        {
            this.Desaffectation("cartesim_boitier", int.Parse(this.cartesimid.Text), this.numeroserieLabel, this.boitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);
            this.Store1.Reload();
        }

    }
}
