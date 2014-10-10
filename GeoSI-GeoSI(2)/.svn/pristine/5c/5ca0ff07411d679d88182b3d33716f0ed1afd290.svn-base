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


namespace GeoSI.Website.Modules.Poi
{
    public partial class LoadPoi : Form
    {

        protected void Save(object sender, DirectEventArgs e)
        {

            string _poiid = this.poiid.Text.ToString();
            string _libelle = this.libelle.Text.ToString();
            string _latitude = this.latitude.Text.ToString();
            string _longitude = this.longitude.Text.ToString();
            string _tolerance = this.tolerance.Text.ToString();
            string _adresse = this.adresse.Text.ToString();
            string _type = this.typepoiid.Text.ToString();

            string valeurs = "'" + _libelle + "'," + "'" + _latitude + "'," + "'" + _longitude + "'" + ",'" + _type + "'" + ",'" + _adresse + "'" + ",'" + _tolerance + "'," + this.getCurrentUser().getUserId().ToString() + "," + this.getCurrentUser().getClientId().ToString() + ",1";
            string _ChaineUpdate = "libelle" + "='" + _libelle + "',latitude" + "='" + _latitude + "',longitude" + "='" + _longitude + "',type_poi" + "='" + _type + "',adresse" + "='" + _adresse + "',tolerance" + "='" + _tolerance + "'";
            // Ajout d'un élément 
            if (_poiid == "")
            {
                string _req = "insert into " + this._TableModule + "(libelle,latitude,longitude,type_poi,adresse,tolerance,userid,clientid,actif) values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                int retourSave = this.InsertRetourId(_req);


            }
            // Modification d'un élément 
            else
            {
                string _req = "update " + this._TableModule + " set " + _ChaineUpdate + " where Poiid=" + _poiid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
            }

            string _req11 = "SELECT *  FROM Poi where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by Poiid desc";
            this.FillStore(_req11, this.StorePois);
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Poi");
            this.PreSchema("Poi", "Poiid");

            string _req11 = "SELECT *  FROM Poi where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by Poiid desc";
             this.FillStore(_req11, this.StorePois);

             string _req1 = "select type_poiid,type_poi from type_poi ";
            this.FillStore(_req1, this.Store2);

            string _req = "select type_poiid,type_poi from type_poi ";
            this.FillStore(_req, this.Store1);

        }
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req11 = "SELECT *  FROM Poi where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by Poiid desc";
            this.FillStore(_req11, this.StorePois);
        }

        //Requete Insert
        protected int Insert(string _Requette)
        {
            int _NewId = -1;
            try
            {
                SqlConnection cnx = _Global.CurrentConnection;
                SqlCommand cmd = new SqlCommand(_Requette, cnx);
                _NewId = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _NewId = -1;
                ex.ToString();
            }
            return _NewId;
        }
        //Recuperation de la session user
        protected UserInfo getCurrentUser()
        {

            UserInfo retVal = null;
            object o = Session["UserInfo"];
            if (o != null)
            {
                retVal = ((UserInfo)Session["UserInfo"]);
            }
            return retVal;


        }

        protected void FillStore(string sql, Store _store)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _Global.CurrentConnection))
            {
                DataSet ds = new DataSet();
                da.SelectCommand.CommandTimeout = 120;
                da.Fill(ds);
                _store.DataSource = ds.Tables[0];
                _store.DataBind();
            }
        }
        // Accès à la base de Données 
        protected SqlDataReader Select(string _Requette)
        {
            SqlDataReader dr;
            try
            {
                SqlConnection cnx = _Global.CurrentConnection;
                SqlCommand cmd = new SqlCommand(_Requette, cnx);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                dr = null;
                ex.ToString();
            }
            return dr;
        }
        //Actualisation du grid
       
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
            string _poiid = this.poiid.Text.ToString();
            try
            {

                //string _req2 = "update poi set actif=0  where poiid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId() ;
                string _req2 = "update poi set actif=0  where Poiid=" + _poiid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int _retourDelete = this.Update(_req2);

                if (_retourDelete != -1)
                {
                    this.StorePois.Reload();
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

        public void Vider(object sender, DirectEventArgs e)
        {
         
            this.latitude.Text ="";
            this.longitude.Text ="";
            this.tolerance.Text ="";
            this.adresse.Text = "";
            this.libelle.Text = "";
            
            
        }
        public void Vider()
        {

            this.latitude.Text = "";
            this.longitude.Text = "";
            this.tolerance.Text = "";
            this.adresse.Text = "";
            this.libelle.Text = "";
           

        }
    }
}