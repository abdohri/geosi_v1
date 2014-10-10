using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;


namespace GeoSI.Website.Modules.Trajet
{
    public partial class LoadTrajet : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Trajet");
            this.PreSchema("Trajet", "trajetid");

         
            string req = "select trajetid, trajet, datetrajet, vehicule,replace(replace(replace(replace(replace(polyline.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as polyline from Trajet where actif =1 and clientid=" + this.getCurrentUser().getClientId();
            this.FillStore(req, this.StoreTrajet);
            string _req1 = "SELECT poiid,libelle  FROM Poi where clientid=" + this.getCurrentUser().getClientId() + " and actif='1'";
            this.FillStore(_req1, this.StorePoint);
            string _req22 = "select vehiculeid ,matricule from vehicules where ClientId=" + this.getCurrentUser().getClientId() + " and vehiculeid NOT IN (select vehiculeid from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_req22, this.Store4);
            string _req2 = "select vehiculeid ,matricule as vehicule from vehicules where ClientId=" + this.getCurrentUser().getClientId() + " and vehiculeid NOT IN (select vehiculeid from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
            this.FillStore(_req2, this.Store2);

        }
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {

            string req = "select trajetid, trajet, datetrajet, vehicule,replace(replace(replace(replace(replace(polylineolygone.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as polyline from Trajet where actif =1 and clientid=" + this.getCurrentUser().getClientId();
            this.FillStore(req, this.StoreTrajet);
        }
         [DirectMethod(ShowMask = true)]
        public void setPosition(string _lat,string _long)
        {
           
            this.longitude.Text = _long;
            this.latitude.Text = _lat;
        }
        public void Getlat(String _poiid)
        {

            string req_lat = "select latitude from Poi where libelle='" + _poiid + "' and clientid=" + this.getCurrentUser().getClientId() + " and actif='1'";

            SqlConnection cnx1 = _Global.CurrentConnection;
            SqlCommand cmd1 = new SqlCommand(req_lat, cnx1);
            cmd1.ExecuteScalar().ToString();

            this.latitude.Text = (String)cmd1.ExecuteScalar();

        }
        public void Getlon(String _poiid)
        {

            string req_lon = "select longitude from Poi where libelle='" + _poiid + "' and clientid=" + this.getCurrentUser().getClientId() + " and actif='1'";

            SqlConnection cnx = _Global.CurrentConnection;
            SqlCommand cmd = new SqlCommand(req_lon, cnx);
            String lon = cmd.ExecuteScalar().ToString();

            this.longitude.Text = lon;
        }
           [DirectMethod(ShowMask = true)]
        public void GetPosition(object sender, DirectEventArgs e)
        {
            if (this.poiid.Text != "")
            {

                string _poiid = this.poiid.Text.ToString();
                this.Getlat(_poiid);
                this.Getlon(_poiid);
            }
            //string a = "33.34567";
            //string b = "-7.890";

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "nombidon", "AfficherPoi(a,b)", true);
        }
       
      


        protected void Save(object sender, DirectEventArgs e)
        {
            

            string _trajetid = this.trajetid.Text.ToString();
            string _trajet = this.trajet.Text.ToString();
            string _date = this.datetrajet.Text.ToString();
            string _longitude = this.longitude.Text.ToString();
            string _latitude = this.latitude.Text.ToString();
            string _vehicule = this.vehiculeid.Text.ToString();
            string _polyline = this.polyline.Text.ToString();
            string _ChaineUpdateUP = "trajet" + "='" + _trajet + "',datetrajet" + "='" + _date + "',vehicule" + "='" + _vehicule + "'";
            string valeurs = "'" + _trajet + "'," + "'" + _date + "'," + "'" + _vehicule + "'," + this.getCurrentUser().getClientId().ToString() + ",1,geometry::STGeomFromText('LINESTRING (" + _polyline + ")', 0)";
            string _ChaineUpdate = "trajet" + "='" + _trajet + "',datetrajet" + "='" + _date + "',vehicule" + "='" + _vehicule + "',polyline=geometry::STGeomFromText('LINESTRING (" + _polyline + ")', 0)";
            // Ajout d'un élément 
            if (_trajetid == "")
            {
                string _req = "insert into Trajet " +  "(trajet,datetrajet,vehicule,clientid,actif,polyline) values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                int retourSave = this.InsertRetourId(_req);


            }
            // Modification d'un élément 
            else
            {
                string _req = "update Trajet " + " set " + _ChaineUpdateUP + " where trajetid=" + _trajetid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
            }

            string req = "select trajetid, trajet, datetrajet, vehicule,replace(replace(replace(replace(replace(polyline.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as polyline from Trajet where actif =1 and clientid=" + this.getCurrentUser().getClientId();
            this.FillStore(req, this.StoreTrajet);

        }
       
        public void Vider(object sender, DirectEventArgs e)
        {

            this.latitude.Text = "";
            this.longitude.Text = "";
            this.trajet.Text = "";
            this.datetrajet.Text = "";
            this.vehiculeid.Text = "";
            this.poiid.Text = "";
          

        }
        public void Vider()
        {
            this.poiid.Text = "";
            this.latitude.Text = "";
            this.longitude.Text = "";
            this.trajet.Text = "";
            this.datetrajet.Text = "";
            this.vehiculeid.Text = "";

        }

       
        //Traitement en cas de suppression d'un élement du grid
        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRowsBehind(object sender, DirectEventArgs e)
        {
            string _poiid = this.poiid.Text.ToString();
            X.Msg.Confirm("Message", Resources.Resource.msgDelete1, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "X.DeleteRows('" + _poiid + "')",
                    Text = Resources.Resource.deleteconfirmOui
                },
                No = new MessageBoxButtonConfig
                {
                    Handler = "X.DoNo()",
                    Text = Resources.Resource.deleteconfirmNon
                }
            }).Show();

        }

        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRows(object sender, DirectEventArgs e)
        {
            string _trajetid = this.trajetid.Text.ToString();
            try
            {

                //string _req2 = "update poi set actif=0  where poiid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId() ;
                string _req2 = "update Trajet set actif=0  where trajetid=" + _trajetid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int _retourDelete = this.Update(_req2);

                if (_retourDelete != -1)
                {
                    this.StoreTrajet.Reload();
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = Resources.Resource.Information,
                        Message = Resources.Resource.deletevalid,
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO
                    });
                }
                else
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = Resources.Resource.Information,
                        Message = Resources.Resource.deleteerror,
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO
                    });
                }
                this.Vider();
            }
            catch (Exception)
            {

            }


        }

       
    }
}
