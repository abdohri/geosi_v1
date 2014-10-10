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
using System.Data;
using System.Data.SqlClient;
using Ext.Net;
using System.Web.Security;
using GeoSI.Website.Common;


namespace GeoSI.Website.Modules.VehiculeConfiguration
{
    // Chargement de la page
    public partial class conForm : Form 
    {
        Ext.Net.Button b;
        int vconf = 0;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            b = this.Button2;
             
            this.SetNomModule("Vehicules");
            this.PreSchema("Vehicules", "VehiculeId");
            string idv=Request.Params.Get("id").ToString();
                        this.vehiculeid.Text=Request.Params.Get("id").ToString();

          //  this.codee.Text = idv;
            string req = "select * from vehicules where vehiculeid=" + Int32.Parse(idv);
            SqlDataReader s = Select(req);
            String matri = "";
            string codev="";
            if (s.HasRows)
            {
                while (s.Read())
                {
                    codev= s[2].ToString();
                    matri= s[1].ToString();
                }

            }
            s.Close();
            string req2 = "select * from vehiculeConf where vehiculeid=" + Int32.Parse(idv);
            SqlDataReader s2 = Select(req2);
            if (s2.HasRows)
            {
                while (s2.Read())
                {
                    this.vitesse.Text = s2[2].ToString();
                    this.kilometrage.Text = s2[3].ToString();
                    this.connsomation.Text = s2[4].ToString();

                    this.dureeMax.Text = s2[5].ToString();
                    vconf++;


                }

            }
            else
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Nouvelle configuration",
                    Message = "Cette vehicule n'est pas encore configurer ",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });

            }


            s2.Close();
            this.matricule.Text= matri;
            this.codee.Text = codev;
            this.TextField11.Text = idv;
            this.TextField12.Text = codev;
            this.TextField13.Text = matri;
         
        }
        public void InsertCNA(object sender, EventArgs e)
        {
            if (this.lundiD.Text != "-10675199.02:48:05.4775808" && this.lundiD.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text)+",'Lundi','"+this.lundiD.Text+"','"+this.lundiF.Text+"','vide')";
                int i = Insert(req);
            }

            if (this.mardiD.Text != "-10675199.02:48:05.4775808" && this.mardiF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Mardi','" + this.mardiD.Text + "','" + this.mardiF.Text + "','vide')";
                int i = Insert(req);
            }

            if (this.mercrediD.Text != "-10675199.02:48:05.4775808" && this.mercrediF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Mercredi','" + this.mercrediD.Text + "','" + this.mercrediF.Text + "','vide')";
                int i = Insert(req);
            }

            if (this.jeudiD.Text != "-10675199.02:48:05.4775808" && this.jeudiF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Jeudi','" + this.jeudiD.Text + "','" + this.jeudiF.Text + "','vide')";
                int i = Insert(req);
            }

            if (this.vendrediD.Text != "-10675199.02:48:05.4775808" && this.vendrediF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Vendredi','" + this.vendrediD.Text + "','" + this.vendrediF.Text + "','vide')";
                int i = Insert(req);
            }
            if (this.samediD.Text != "-10675199.02:48:05.4775808" && this.samediF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Samedi','" + this.samediD.Text + "','" + this.samediF.Text + "','vide')";
                int i = Insert(req);
            }
            if (this.dimancheD.Text != "-10675199.02:48:05.4775808" && this.dimancheF.Text != "-10675199.02:48:05.4775808")
            {
                string req = "insert into vehicule_CNA(vehiculeid,jour,heurD,heurF,note)values(" + Int32.Parse(this.TextField11.Text) + ",'Dimanche','" + this.dimancheD.Text + "','" + this.dimancheF.Text + "','vide')";
                int i = Insert(req);
            }

        }
        public void updateInsert(object sender, EventArgs e)
        {
            if (this.vitesse.Text.Equals("") || this.connsomation.Text.Equals("") || this.kilometrage.Text.Equals("") || this.dureeMax.Text.Equals(""))
            {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Verifier vos données ",
                    Message = "Les valeurs doivent etre superieur a 0 ",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
            }
            if (vconf > 0)
            {
                int vit = Int32.Parse(this.vitesse.Text);
                int kil = Int32.Parse(this.kilometrage.Text);
                int con = Int32.Parse(this.connsomation.Text);
                int dur = Int32.Parse(this.dureeMax.Text);
                int vehid = Int32.Parse(Request.Params.Get("id"));
                string req = "update vehiculeConf set vitesseMax=" + vit + " , consomationMax=" + con + ", kmAberant=" + kil + ",dureMaxCond=" + dur + " where vehiculeid=" + vehid;
                int i = Update(req);
               X.Msg.Show(new MessageBoxConfig
               {
                   Title = "Modification des données  ",
                   Message = "Votre modification est effectuer avec succes" +this.vitesse.Text.ToString(),
                   Buttons = MessageBox.Button.OK,
                   Icon = MessageBox.Icon.INFO
               });
            }
            if (vconf == 0)
            {
                int vit = Int32.Parse(this.vitesse.Text);
                int kil= Int32.Parse(this.kilometrage.Text);
                int con = Int32.Parse(this.connsomation.Text);
                int dur = Int32.Parse(this.dureeMax.Text);
                int vehid = Int32.Parse(Request.Params.Get("id"));

                string req = "insert into vehiculeConf(vehiculeid,vitesseMax,kmAberant,consomationMax,dureMaxCond) values ("+vehid + "," + vit + "," + kil + "," + con + "," + dur + ")";
                int i = Insert(req);
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = "Validation d'enregistrement",
                    Message = "Votre enregistrement est effectuer avec succes "+(vit+kil+con+dur).ToString(),
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
            }

       
        }
        // Actualisation de l'onglet2
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            //string _comboBoitier = "select boitierid ,imei from boitier where ClientId=1 and BoitierId NOT IN (select BoitierId from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            //this.FillStore(_comboBoitier, this.Store4);

            string _req3 = "select v.matricule,b.imei from boitier b,vehicules v ,affectation_vehicule_boitier avb where avb.boitierid=b.boitierid and avb.vehiculeid=v.vehiculeid and avb.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and avb.Clientid=" + this.getCurrentUser().getClientId() + " and avb.actif='0' order by avb.id desc";
           // this.FillStore(_req3, this.Store1);
        }

        // Actualisation de l'onglet3
        protected void MyData_Refresh2(object sender, StoreReadDataEventArgs e)
        {
        //    string _comboPersonnel = "Select personnelid,nom+' '+prenom nom From personnel where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and personnelid not in(select personnelid from vehicule_personnel where actif='1')";
        //    this.FillStore(_comboPersonnel, this.Store5);

            string _reqAnelffPerson = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='1'";
           // this.FillStore(_reqAnelffPerson, this.Store6);
        }
        // Actualisation de l'onglet3
        protected void MyData_Refresh3(object sender, StoreReadDataEventArgs e)
        {
            string _reqAnelffPersonH = "select vp.id,v.matricule,p.nom+' '+p.prenom nom,vp.date_affectation from vehicule_personnel vp,vehicules v,personnel p where p.personnelid=vp.personnelid and v.vehiculeid=vp.vehiculeid and vp.vehiculeid=" + int.Parse(this.vehiculeid.Text) + " and vp.clientid=" + this.getCurrentUser().getClientId() + " and vp.actif='0' order by vp.id desc";
          //  this.FillStore(_reqAnelffPersonH, this.Store7);
        }
        //Désaffectation d'un boitier
        protected void Desaffectation(object sender, DirectEventArgs e)
        {
          //  this.Desaffectation("affectation_vehicule_boitier", int.Parse(this.vehiculeid.Text), this.MatriculeLabel, this.BoitierLabel, this.DateAffectationLabel, this.ButtonDesaffectation);
           // this.Store1.Reload();
        }
       
    }
}
