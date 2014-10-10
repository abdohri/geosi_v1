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

namespace GeoSI.Website.Modules.Zone
{
    public partial class LoadZone : Form
    {

        public void Vider(object sender, DirectEventArgs e)
        {
            this.zoneid.Text = "";
            this.nom_zone.Text = "";
            this.interditid.Text = "";
            this.tolerance.Text = "";
            this.polygone.Text = "";

        }
        public void Vider()
        {
            this.zoneid.Text = "";
            this.nom_zone.Text = "";
            this.interditid.Text = "";
            this.tolerance.Text = "";
            this.polygone.Text = "";

        }
        //Traitement en cas de suppression d'un élement du grid
        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRowsBehind(object sender, DirectEventArgs e)
        {
            string _zoneid = this.zoneid.Text.ToString();
            X.Msg.Confirm("Message", Resources.Resource.msgDelete1, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "X.DeleteRows('" + _zoneid + "')",
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
            string _zoneid = this.zoneid.Text.ToString();
            try
            {

                //string _req2 = "update poi set actif=0  where poiid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId() ;
                string _req2 = "update zone set actif=0  where zoneid=" + _zoneid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int _retourDelete = this.Update(_req2);

                if (_retourDelete != -1)
                {
                    this.StoreZone.Reload();
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
                this.StoreZone.Reload();
            }
            catch (Exception)
            {

            }


        }
        protected int GETgroupeid(string grp)
        {
            string req_lat = "select groupeid from groupe where libelle='" + grp + "' and clientid=" + this.getCurrentUser().getClientId() + " and actif='1'";

            SqlConnection cnx1 = new SqlConnection();
            SqlCommand cmd1 = new SqlCommand(req_lat, _Global.CurrentConnection);
            cnx1.Close();

            return (int)cmd1.ExecuteScalar();


        }

        protected void Save(object sender, EventArgs e)
        {

            string _ChaineUpdate = "";
            string _zoneid = this.zoneid.Text.ToString();
            string _tolerance = this.tolerance.Text.ToString();
            string _nom_zone = this.nom_zone.Text.ToString();
            string _interdit = this.interditid.Text.ToString();
            string _polygone = this.polygone.Text.ToString();
            string _groupe = this.groupeid.Text.ToString();
            string _vehicule = this.MultiCombo1.Text.ToString();

            // = this.groupeid.SelectedItems ;
            string[] groupes;
            groupes = _groupe.Split(',');
            string[] vehicules;
            vehicules = _vehicule.Split(',');

            int _grpid = -1;
            int _vehiculeid;


            string valeurs = "'" + _nom_zone + "'," + "'" + _tolerance + "'," + "'" + _interdit + "','" + DateTime.Now + "'," + this.getCurrentUser().getClientId() + ",1,geometry::STGeomFromText('LINESTRING (" + _polygone + ")', 0)";

            _ChaineUpdate = "nom_zone='" + _nom_zone + "'," + "tolerance=" + _tolerance + "," + "interdit='" + _interdit + "',date_modification='" + DateTime.Now + "',polygone=geometry::STGeomFromText('LINESTRING (" + _polygone + ")', 0)";


            string valeursgroup = "'" + _zoneid + "'," + _grpid + "," + this.getCurrentUser().getClientId() + ",1";

            _ChaineUpdate = "zoneid='" + _zoneid + "'," + "groupeid=" + _grpid;


            // Ajout d'un élément 

            if (_zoneid == "")
            {
                string _req = "insert into " + this._TableModule + "(nom_zone,tolerance,interdit,date_modification,clientid,actif,polygone) values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                int retourSave = this.InsertRetourId(_req);
                _zoneid = retourSave.ToString();

                for (int i = 0; i < groupes.Length; i++)
                {
                    string req_lat = "select groupeid from groupe where libelle='" + groupes[i]+"' and clientid=" + this.getCurrentUser().getClientId() + " and actif='1'";

                    SqlConnection cnx1 =new SqlConnection("Data Source=.;Initial Catalog=Geomtec;Integrated Security=True");
                    cnx1.Open();
                    SqlCommand cmd1 = new SqlCommand(req_lat, cnx1);

                    _grpid = (int)cmd1.ExecuteScalar();
                    cnx1.Close();
                    string _reqgroup = "insert into Groupe_Zone (zoneid,groupeid,clientid,actif) values ('" + _zoneid + "'," + _grpid + "," + this.getCurrentUser().getClientId() + ",1)";
                    int retour = this.InsertRetourId(_reqgroup);
                }
                //for (int i = 0; i < vehicules.Length; i++)
                //{
                //    string _reqgroup = "insert into Groupe_Zone (zoneid,groupeid,clientid,actif) values ()";
                //    int retour = this.InsertRetourId(_reqgroup);
                //}

            }
            else
            {
                string _req = "update " + this._TableModule + " set " + _ChaineUpdate + " where zoneid=" + _zoneid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
            }


            //string _req11 = "SELECT zoneid,nom_zone,tolerance,interdit, replace(replace(replace(replace(replace(polygone.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as  polygone FROM zone where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by zoneid desc";
            //this.FillStore(_req11, this.StoreZone);
        }
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {

            string _req11 = "SELECT zoneid,nom_zone,tolerance,interdit, replace(replace(replace(replace(replace(polygone.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as  polygone FROM zone where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by zoneid desc";
            this.FillStore(_req11, this.StoreZone);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("zone");
            this.PreSchema("zone", "zoneid");
            if (!X.IsAjaxRequest)
            {
                if (Request.HttpMethod == "POST")
                {



                }
                else
                {

                    this.FillStore("SELECT interditid,interdit  FROM interditZone", this.StoreComboboxInterdit);
                    string _req = "SELECT interdit  FROM interditZone";

                    this.FillStore(_req, this.Store2);


                    string _req11 = "SELECT zoneid,nom_zone,tolerance,interdit, replace(replace(replace(replace(replace(polygone.STAsText(),'LINESTRING (','newgoogle.maps.LatLng('),',',');newgoogle.maps.LatLng('),'( ','('),' ',','),'newgoogle','new google') as  polygone FROM zone where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by zoneid desc";
                    this.FillStore(_req11, this.StoreZone);

                    string _reqGrp = "select g.groupeid as groupeid, g.libelle as libelle from groupe g inner join Groupe_Profil gp on gp.groupeid = g.groupeid and gp.actif = '1' inner join profil p on p.profilid = gp.profilid and p.actif = '1' inner join profil_user pu on pu.actif = '1' and pu.profilid = p.profilid where  g.clientid = " + this.getCurrentUser().getClientId() + "   and g.actif = '1' and pu.utilisateurid =  " + this.getCurrentUser().getUserId();
                    this.FillStore(_reqGrp, this.Store5);
                    string _reqvh = "select * from (select aff.* from (select v.vehiculeid, v.matricule, v.typevehiculeid , isnull(gv.groupeid, 1) as groupeid from vehicules v left outer join groupe_vehicule gv on gv.vehiculeid = v.vehiculeid and gv.actif = '1' where v.clientid = " + this.getCurrentUser().getClientId() + " and v.actif = '1' )aff union select v.vehiculeid, v.matricule, v.typevehiculeid , 1 as groupeid   from vehicules v inner join  profil_vehicule pv on pv.vehiculeid = v.vehiculeid and pv.actif = '1' inner join profil p on p.profilid = pv.profilid and p.actif ='1' inner join profil_user pu on pu.actif = '1' and pu.profilid = p.profilid where  pu.utilisateurid = " + this.getCurrentUser().getUserId() + " and  v.clientid = " + this.getCurrentUser().getClientId() + " and v.actif = '1') aff2";
                    this.FillStore(_reqvh, this.Store1);

                }

            }
        }
    }
}


