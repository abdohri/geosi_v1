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
namespace GeoSI.Website.Modules.Profil
{
    public partial class GeoForm : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            this.PreSchema("profil", "profilid");
        

            if (!X.IsAjaxRequest)
            {// Dans le cas d'ajout d'un nouvel élement

                if (Request.HttpMethod == "POST")
                {
                   
                        
                }
                // Dans le cas de la modification d'un élement existant
                else
                {//Modification

                    string id = Request.Params.Get("id").ToString();
                    this.InitForm(id, UserForm, this.getCurrentUser().getClientId());
                   
                   string _req1 = "select hp.habilitationid,h.action from Habilitation_Profil hp inner join Habilitation h on hp.habilitationid=h.habilitationid where  hp.actif=1 and hp.profilid=" + id + " order by h.module desc";
                   this.FillStore(_req1, Store1);
                   string _req2 = "SELECT habilitationid,action FROM habilitation where habilitationid not in(select habilitationid from Habilitation_Profil where actif=1 and profilid=" + id + ")";
                   this.FillStore(_req2, Store2);

                   string _req3 = "select gp.groupeid,g.libelle from Groupe_Profil gp inner join groupe g on gp.groupeid=g.groupeid where  gp.actif=1 and gp.profilid=" + id ;
                   this.FillStore(_req3, Store3);
                   string _req4 = "SELECT groupeid,libelle FROM groupe where groupeid not in(select groupeid from Groupe_Profil where actif=1 and profilid=" + id + ")";
                   this.FillStore(_req4, Store4);

                   string _req5 = "select pv.vehiculeid,v.matricule from profil_vehicule pv inner join vehicules v on pv.vehiculeid=v.vehiculeid where  pv.actif=1 and pv.profilid=" + id;
                   this.FillStore(_req5, Store5);
                   //string _req6 = "SELECT v.vehiculeid,v.matricule FROM vehicules v,groupe_vehicule gv, Groupe_Profil gp where gv.vehiculeid=v.vehiculeid  and  gv.groupeid=gp.groupeid and  gp.profilid=" + id+  " and v.vehiculeid not in(select p.vehiculeid from profil_vehicule p where actif=1  and profilid=" + id + ")";
                   string _req6 = "SELECT vehiculeid,matricule FROM vehicules where vehiculeid not in(select vehiculeid from profil_vehicule where actif=1 and profilid=" + id + ")";
                    this.FillStore(_req6, Store6);

                    //string _req7 = "select pa.alerteid,a.titre from profil_alerte pa inner join alerte a on pa.alerteid=a.alerteid where  pa.actif=1 and pa.profilid=" + id;
                    //this.FillStore(_req7, Store7);
                    //string _req8 = "SELECT alerteid,titre FROM alerte where alerteid not in(select alerteid from profil_alerte where actif=1 and profilid=" + id + ")";
                    //this.FillStore(_req8, Store8);
                }
 
            }

        }
       
        //traitement des sélections : habilitaion, groupe, véhicule
        [DirectMethod()]
        public int MethodeProfil(string _ActionSelected, string _GroupSelected, string _VehiculSelected, string _AlerteSelected)
        {
            int retourmethod = 0;
            List<string> _ArrayActionexiste = new List<string>();
            List<string> _ArrayActionSelected = _ActionSelected.Split(';').ToList<string>();
            List<string> _ArrayGroupexiste = new List<string>();
            List<string> _ArrayGroupSelected = _GroupSelected.Split(';').ToList<string>();
            List<string> _ArrayVehiculexiste = new List<string>();
            List<string> _ArrayVehiculSelected = _VehiculSelected.Split(';').ToList<string>();
            List<string> _ArrayAlertexiste = new List<string>();
            List<string> _ArrayAlertSelected = _AlerteSelected.Split(';').ToList<string>();

            string _profilid = this.profilid.Text.ToString();
            string _libelle = this.libelle.Text.ToString();
            string _description = this.description.Text.ToString();
            string valeurs = "'" + _libelle + "'," + "'" + _description + "'," + "1," + this.getCurrentUser().getClientId().ToString();
            string _ChaineUpdate = "libelle" + "='" + _libelle + "',description" + "='" + _description + "'";

            // Ajout d'un élément 
            if (_profilid == "")
            {
               string _req = "insert into " + this._TableModule + " (libelle,description,actif,clientid) values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
               int retourSave = this.InsertRetourId(_req);
               if (retourSave != -1)
                   {

                       if (_ArrayActionSelected[0] != "")
                       {
                           foreach (String _Selected in _ArrayActionSelected)
                           {
                               string _req2 = "insert into habilitation_profil (profilid,habilitationid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                               this.Insert(_req2);
                           }
                       }
                       if (_ArrayGroupSelected[0] != "")
                       {
                           foreach (String _Selected in _ArrayGroupSelected)
                           {
                               string _req3 = "insert into Groupe_Profil (profilid,groupeid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                               this.Insert(_req3);
                           }
                       }
                       if (_ArrayVehiculSelected[0] != "")
                       {
                           foreach (String _Selected in _ArrayVehiculSelected)
                           {
                               string _req3 = "insert into profil_vehicule (profilid,vehiculeid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                               this.Insert(_req3);
                           }
                       }
                       if (_ArrayAlertSelected[0] != "")
                       {
                           foreach (String _Selected in _ArrayAlertSelected)
                           {
                               string _req3 = "insert into profil_alerte (profilid,alerteid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                               this.Insert(_req3);
                           }
                       }
                       retourmethod = 1;            
                   }

            }
            // Modification d'un élément 
            else
            {
                string _req = "update " + this._TableModule + " set " + _ChaineUpdate + " where profilid=" + _profilid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
                if (retourSave != -1)
                {
                    //---------------modification habilitation
                    string _reqexiste = "SELECT habilitationid FROM habilitation_profil where actif='1' and profilid=" + _profilid;
                    SqlDataReader dr = Select(_reqexiste);
                    while (dr.Read())
                    {
                        _ArrayActionexiste.Add(dr[0].ToString());
                    }
                    dr.Close();

                    List<string> _listdelet = new List<string>();
                    if (_ArrayActionexiste.Count > 0)
                    {
                        if (_ArrayActionSelected[0] == "")
                        {
                            _listdelet = _ArrayActionexiste;
                        }
                        else
                        {
                            foreach (string _Profil in _ArrayActionexiste)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayActionSelected)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listdelet.Add(_Profil);
                                }
                            }
                        }
                    }
                    List<string> _listAdd = new List<string>();
                    if (_ArrayActionSelected[0] != "")
                    {
                        if (_ArrayActionexiste.Count > 0)
                        {
                            foreach (string _Profil in _ArrayActionSelected)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayActionexiste)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listAdd.Add(_Profil);
                                }
                            }
                        }
                        else
                        {
                            _listAdd = _ArrayActionSelected;
                        }
                    }
                    //attriburion des habilitation 
                    foreach (string _SelectedAdd in _listAdd)
                    {

                        string _req2 = "insert into Habilitation_Profil (profilid,habilitationid,actif,clientid) values(" + _profilid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //réstriction des habilitations
                    foreach (string _SelectedDelete in _listdelet)
                    {

                        string _req2 = "update Habilitation_Profil set actif='0' where actif='1' and habilitationid="+ _SelectedDelete + " and profilid=" + _profilid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        this.Insert(_req2);
                    }

                    // -------------------------modification Groupe
                     string _reqexisteG = "SELECT groupeid FROM Groupe_Profil where actif='1' and profilid=" + _profilid;
                    SqlDataReader drG = Select(_reqexisteG);
                    while (drG.Read())
                    {
                        _ArrayGroupexiste.Add(drG[0].ToString());
                    }
                    drG.Close();

                    List<string> _listdeletG = new List<string>();
                    if (_ArrayGroupexiste.Count > 0)
                    {
                        if (_ArrayGroupSelected[0] == "")
                        {
                            _listdeletG = _ArrayGroupexiste;
                        }
                        else
                        {
                            foreach (string _Profil in _ArrayGroupexiste)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayGroupSelected)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listdeletG.Add(_Profil);
                                }
                            }
                        }
                    }
                    List<string> _listAddG = new List<string>();
                    if (_ArrayGroupSelected[0] != "")
                    {
                        if (_ArrayGroupexiste.Count > 0)
                        {
                            foreach (string _Profil in _ArrayGroupSelected)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayGroupexiste)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listAddG.Add(_Profil);
                                }
                            }
                        }
                        else
                        {
                            _listAddG = _ArrayGroupSelected;
                        }
                    }
                    //attriburion des groupes
                    foreach (string _SelectedAdd in _listAddG)
                    {

                        string _req2 = "insert into Groupe_Profil (profilid,groupeid,actif,clientid) values(" + _profilid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //réstriction des groupes
                    foreach (string _SelectedDelete in _listdeletG)
                    {

                        string _req2 = "update Groupe_Profil set actif='0' where actif='1' and groupeid=" + _SelectedDelete + " and profilid=" + _profilid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        this.Insert(_req2);
                    }

                    // -------------------------modification vehicule
                    string _reqexisteV = "SELECT vehiculeid FROM profil_vehicule where actif='1' and profilid=" + _profilid;
                    SqlDataReader drV = Select(_reqexisteV);
                    while (drV.Read())
                    {
                        _ArrayVehiculexiste.Add(drV[0].ToString());
                    }
                    drV.Close();

                    List<string> _listdeletV = new List<string>();
                    if (_ArrayVehiculexiste.Count > 0)
                    {
                        if (_ArrayVehiculSelected[0] == "")
                        {
                            _listdeletV = _ArrayVehiculexiste;
                        }
                        else
                        {
                            foreach (string _Profil in _ArrayVehiculexiste)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayVehiculSelected)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listdeletV.Add(_Profil);
                                }
                            }
                        }
                    }
                    List<string> _listAddV = new List<string>();
                    if (_ArrayVehiculSelected[0] != "")
                    {
                        if (_ArrayVehiculexiste.Count > 0)
                        {
                            foreach (string _Profil in _ArrayVehiculSelected)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayVehiculexiste)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listAddV.Add(_Profil);
                                }
                            }
                        }
                        else
                        {
                            _listAddV = _ArrayVehiculSelected;
                        }
                    }
                    //attriburion des vehicules
                    foreach (string _SelectedAdd in _listAddV)
                    {

                        string _req2 = "insert into profil_vehicule (profilid,vehiculeid,actif,clientid) values(" + _profilid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //réstriction des vehicules
                    foreach (string _SelectedDelete in _listdeletV)
                    {

                        string _req2 = "update profil_vehicule set actif='0' where actif='1' and vehiculeid=" + _SelectedDelete + " and profilid=" + _profilid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        this.Insert(_req2);
                    }

                    // -------------------------modification alerte
                    string _reqexisteA = "SELECT alerteid FROM profil_alerte where actif='1' and profilid=" + _profilid;
                    SqlDataReader drA = Select(_reqexisteA);
                    while (drA.Read())
                    {
                        _ArrayAlertexiste.Add(drA[0].ToString());
                    }
                    drA.Close();

                    List<string> _listdeletA = new List<string>();
                    if (_ArrayAlertexiste.Count > 0)
                    {
                        if (_ArrayAlertSelected[0] == "")
                        {
                            _listdeletA = _ArrayAlertexiste;
                        }
                        else
                        {
                            foreach (string _Profil in _ArrayAlertexiste)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayAlertSelected)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listdeletA.Add(_Profil);
                                }
                            }
                        }
                    }
                    List<string> _listAddA = new List<string>();
                    if (_ArrayAlertSelected[0] != "")
                    {
                        if (_ArrayAlertexiste.Count > 0)
                        {
                            foreach (string _Profil in _ArrayAlertSelected)
                            {
                                Boolean trouve = true;

                                foreach (string _Selected in _ArrayAlertexiste)
                                {

                                    if (int.Parse(_Profil) == int.Parse(_Selected))
                                    {
                                        trouve = false;
                                    }

                                }
                                if (trouve)
                                {
                                    _listAddA.Add(_Profil);
                                }
                            }
                        }
                        else
                        {
                            _listAddA = _ArrayAlertSelected;
                        }
                    }
                    //attriburion des alertes
                    foreach (string _SelectedAdd in _listAddA)
                    {

                        string _req2 = "insert into profil_alerte (profilid,alerteid,actif,clientid) values(" + _profilid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //réstriction des alertes
                    foreach (string _SelectedDelete in _listdeletA)
                    {

                        string _req2 = "update profil_alerte set actif='0' where actif='1' and alerteid=" + _SelectedDelete + " and profilid=" + _profilid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                        this.Insert(_req2);
                    }

                }
                retourmethod = 1;

               }
            
            return retourmethod;  
        }
       
    }
}
