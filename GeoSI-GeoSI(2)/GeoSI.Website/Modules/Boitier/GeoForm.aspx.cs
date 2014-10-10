using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ext.Net;
using System.Threading;
using System.Globalization;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Boitier
{
    public partial class GeoForm : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Boitier");
            this.PreSchema("boitier", "boitierid");
            int _TypeCompte = this.getCurrentUser().getTypeCompte();

            if (!X.IsAjaxRequest)
            {
                if (Request.HttpMethod == "POST")
                {
                    try
                    {
                        int retourSave = this.Save(Request);
                        if (retourSave != 0 && Request.Params.Get("cartesimid") != null)
                        {
                            this.Affectation("cartesim_boitier", "boitierid", "cartesimid", retourSave, int.Parse(Request.Params.Get("cartesimid")));

                        }
                        if (retourSave != 0 && Request.Params.Get("vehiculeid") != null)
                        {
                            this.Affectation("affectation_vehicule_boitier", "boitierid", "vehiculeid", retourSave, int.Parse(Request.Params.Get("vehiculeid")));
                        }

                    }
                    catch
                    {
                    }
                    Response.Write("<script>parent.location.reload();</script>");
                }
                else
                {

                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm, this.getCurrentUser().getClientId());

                        string _req1 = "select s.numero_tel,b.imei,cb.date_affectation from cartesim_boitier cb,carte_sim s,boitier b where b.boitierid=cb.boitierid and s.cartesimid=cb.cartesimid and cb.boitierid=" + int.Parse(id) + " and s.clientid=" + this.getCurrentUser().getClientId() + " and cb.actif='1'";
                        this.AffectationCourante(_req1, this.numerotelLabel, this.boitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);

                        string _req2 = "select v.matricule,b.imei,avb.date_affectation from affectation_vehicule_boitier avb,vehicules v,boitier b where b.boitierid=avb.boitierid and v.vehiculeid=avb.vehiculeid and avb.boitierid=" + int.Parse(id) + " and v.clientid=" + this.getCurrentUser().getClientId() + " and avb.actif='1'";
                        this.AffectationCourante(_req2, this.MatriculeLabel, this.BoitierLabelVehicule, this.DateAffectationLabelVehicule, this.ButtonDesaffectationVehicule);


                        string _req = "select c.numero_tel,b.imei from cartesim_boitier cb,boitier b,carte_sim c where cb.boitierid=b.boitierid and cb.cartesimid=c.cartesimid and cb.boitierid=" + int.Parse(id) + " and cb.actif='0' order by cb.id desc";
                        this.FillStore(_req, this.Store1);

                        string _HistoriqueVehicule = "select v.matricule,b.imei from affectation_vehicule_boitier avb,boitier b,vehicules v where avb.boitierid=b.boitierid and avb.vehiculeid=v.vehiculeid and avb.boitierid=" + int.Parse(id) + " and avb.actif='0' order by avb.id desc";
                        this.FillStore(_HistoriqueVehicule, this.Store5);
                    }
                    string _req11 = "select typeboitierid,libelle from type_boitier where clientid=-1 or ClientId=" + this.getCurrentUser().getClientId();
                    this.FillStore(_req11, this.Store2);

                    string _req22 = "select vehiculeid ,matricule from vehicules where ClientId=" + this.getCurrentUser().getClientId() + " and vehiculeid NOT IN (select vehiculeid from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
                    this.FillStore(_req22, this.Store4);

                    string _req3 = "select cartesimid ,numero_tel from carte_sim where ClientId=" + this.getCurrentUser().getClientId() + " and cartesimid NOT IN (select cartesimid from cartesim_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
                    this.FillStore(_req3, this.Store3);

                    string _reqMarqueBoitier = "select marque_boitierid,marque_boitier from marqueboitier where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();
                    this.FillStore(_reqMarqueBoitier, this.Store6);


                    if (_TypeCompte == 1)//BackOffice
                    {
                        string _comboclient = "select clientid,raison_sociale from client where revendeurid=-1";
                        this.FillStore(_comboclient, this.Store7);
                    }
                    else if (_TypeCompte == 2)
                    {
                        string _comboclient = "select clientid,raison_sociale from client where revendeurid!=-1";
                        this.FillStore(_comboclient, this.Store7);
                    }

                }
            }
        }

        protected void MyData_Refresh1(object sender, StoreReadDataEventArgs e)
        {
            string _req3 = "select cartesimid ,numero_tel from carte_sim where ClientId=" + this.getCurrentUser().getClientId() + " and cartesimid NOT IN (select cartesimid from cartesim_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_req3, this.Store3);

            string _req = "select c.numero_tel,b.imei,cb.date_affectation,cb.date_desaffectation from cartesim_boitier cb,boitier b,carte_sim c where cb.boitierid=b.boitierid and cb.cartesimid=c.cartesimid and cb.boitierid=" + int.Parse(this.boitierid.Text) + " and cb.actif='0' order by cb.id desc";
            this.FillStore(_req, this.Store1);
        }

        protected void MyData_Refresh2(object sender, StoreReadDataEventArgs e)
        {
            string _req22 = "select vehiculeid ,matricule from vehicules where ClientId=" + this.getCurrentUser().getClientId() + " and vehiculeid NOT IN (select vehiculeid from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_req22, this.Store4);

            string _HistoriqueVehicule = "select v.matricule,b.imei,avb.date_affectation,avb.date_desaffectation from affectation_vehicule_boitier avb,boitier b,vehicules v where avb.boitierid=b.boitierid and avb.vehiculeid=v.vehiculeid and avb.boitierid=" + int.Parse(this.boitierid.Text) + " and avb.actif='0' order by avb.id desc";
            this.FillStore(_HistoriqueVehicule, this.Store5);
        }

        protected void Desaffectation(object sender, DirectEventArgs e)
        {
            this.Desaffectation("cartesim_boitier", int.Parse(this.boitierid.Text), this.numerotelLabel, this.boitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);
            this.Store1.Reload();
        }

        protected void DesaffectationVehicule(object sender, DirectEventArgs e)
        {
            this.Desaffectation("affectation_vehicule_boitier", int.Parse(this.boitierid.Text), this.MatriculeLabel, this.BoitierLabelVehicule, this.DateAffectationLabelVehicule, this.ButtonDesaffectationVehicule);
            this.Store5.Reload();
        }

    }
}
