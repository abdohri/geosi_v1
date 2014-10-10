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
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Vehicules
{
    // Chargement de la page
    public partial class GeoForm : Form
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Vehicules");
            this.PreSchema("Vehicules", "VehiculeId");
            if (!X.IsAjaxRequest)
            {   // Dans le cas d'ajout d'un nouvel élement
                if (Request.HttpMethod == "POST")
                {

                    try
                    {
                        int returnAff = -1;
                        int returnAffPersonnel = -1;
                        int retourSave = this.SaveFile(Request, this.imgVehicule1);
                        if (retourSave != -1 && Request.Params.Get("BoitierId") != "" && Request.Params.Get("BoitierId") != null)
                        {
                            returnAff = this.Affectation("affectation_vehicule_boitier", "vehiculeid", "boitierid", retourSave, int.Parse(Request.Params.Get("BoitierId")));
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


                        List<string> _ArrayPersonnelSelected = Request.Params.Get("personnelid").Split(',').ToList<string>();
                        foreach (string _Selected in _ArrayPersonnelSelected)
                        {
                            returnAffPersonnel = this.Affectation("vehicule_personnel", "vehiculeid", "personnelid", retourSave, int.Parse(_Selected));
                        }

                    }
                    catch
                    {
                    }

                }
                else
                {  // Dans le cas de la modification d'un élement existant
                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm);

                        string _req1 = "select v.matricule,b.imei,avb.date_affectation from affectation_vehicule_boitier avb,vehicules v,boitier b where b.boitierid=avb.boitierid and v.vehiculeid=avb.vehiculeid and avb.vehiculeid=" + int.Parse(id) + " and v.clientid=" + this.getCurrentUser().getClientId() + " and avb.actif='1'";
                        this.AffectationCourante(_req1, this.MatriculeLabel, this.BoitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);

                        string _req3 = "select v.matricule,b.imei from boitier b,vehicules v ,affectation_vehicule_boitier avb where avb.boitierid=b.boitierid and avb.vehiculeid=v.vehiculeid and avb.vehiculeid=" + int.Parse(id) + " and avb.Clientid=" + this.getCurrentUser().getClientId() + " and avb.actif='0' order by avb.id desc";
                        this.FillStore(_req3, this.Store1);

                        string _reqAnelffPerson = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(id) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='1'";
                        this.FillStore(_reqAnelffPerson, this.Store6);

                        string _reqAnelffPersonH = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(id) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='0' order by vp.id desc";
                        this.FillStore(_reqAnelffPersonH, this.Store7);
                    }
                    else
                    {
                        imgVehicule.Hidden = true;
                    }
                    // Remplissage des combobox existant dans la forme
                    string _marque = "select marquevehiculeid,libelle from marquevehicule where actif='1' and ClientId=-1 or ClientId=" + this.getCurrentUser().getClientId();
                    this.FillStore(_marque, this.Store2);

                    string _type = "select typevehiculeid,libelle from typevehicule where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();
                    this.FillStore(_type, this.Store3);


                    string _comboBoitier = "select boitierid,imei from boitier where actif='1' and ClientId=" + this.getCurrentUser().getClientId() + " and BoitierId NOT IN (select BoitierId from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
                    this.FillStore(_comboBoitier, this.Store4);

                    string _comboPersonnel = "Select personnelid,nom+' '+prenom nom From personnel where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and personnelid not in(select personnelid from vehicule_personnel where actif='1')";
                    this.FillStore(_comboPersonnel, this.Store5);
                }
               
            }
        }
        // Actualisation de l'onglet2
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _comboBoitier = "select boitierid ,imei from boitier where ClientId=1 and BoitierId NOT IN (select BoitierId from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_comboBoitier, this.Store4);

            string _req3 = "select v.matricule,b.imei from boitier b,vehicules v ,affectation_vehicule_boitier avb where avb.boitierid=b.boitierid and avb.vehiculeid=v.vehiculeid and avb.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and avb.Clientid=" + this.getCurrentUser().getClientId() + " and avb.actif='0' order by avb.id desc";
            this.FillStore(_req3, this.Store1);
        }

        // Actualisation de l'onglet3
        protected void MyData_Refresh2(object sender, StoreReadDataEventArgs e)
        {
            string _comboPersonnel = "Select personnelid,nom+' '+prenom nom From personnel where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and personnelid not in(select personnelid from vehicule_personnel where actif='1')";
            this.FillStore(_comboPersonnel, this.Store5);

            string _reqAnelffPerson = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='1'";
            this.FillStore(_reqAnelffPerson, this.Store6);
        }
        // Actualisation de l'onglet3
        protected void MyData_Refresh3(object sender, StoreReadDataEventArgs e)
        {
            string _reqAnelffPersonH = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='0' order by vp.id desc";
            this.FillStore(_reqAnelffPersonH, this.Store7);
        }
        //Désaffectation d'un boitier
        protected void Desaffectation(object sender, DirectEventArgs e)
        {
            this.Desaffectation("affectation_vehicule_boitier", int.Parse(this.vehiculeid.Text), this.MatriculeLabel, this.BoitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);
            this.Store1.Reload();
        }
        //Désaffectation d'un personnel
        [DirectMethod()]
        public void DesaffectationPersonnel(string _iddesaffect)
        {
            this.Methodedesaffec("vehicule_personnel", int.Parse(_iddesaffect));
            this.Store6.Reload();
            this.Store7.Reload();
        }
    }
}
