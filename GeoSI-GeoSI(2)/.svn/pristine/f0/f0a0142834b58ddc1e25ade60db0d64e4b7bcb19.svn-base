using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Utilisateur
{
    public partial class GeoForm : Form
    {// Chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("utilisateur");
            this.PreSchema("utilisateur", "utilisateurid");
         
            if (!X.IsAjaxRequest)
            {    // Remplissage des combobox existant dans la forme
                string id = Request.Params.Get("id").ToString();
                if (id != "0")
                {
                    this.InitForm(id, this.UserForm, this.getCurrentUser().getClientId());

                    string _reqville = "SELECT villeid,ville from ville where paysid='" + this.paysid.Value+"'";
                    this.FillStore(_reqville, CitiesStore);
                }
              
                    string _req1 = "select hp.profilid,h.libelle from profil_user hp inner join profil h on hp.profilid=h.profilid where  hp.actif=1 and hp.utilisateurid=" + id;
                    this.FillStore(_req1, Store1);
                    string _req2 = "SELECT profilid,libelle FROM profil where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and profilid not in(select profilid from profil_user where actif=1 and actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and utilisateurid=" + id + ")";
                    this.FillStore(_req2, Store2);
                    string _reqpays = "select paysid,pays from pays";
                    this.FillStore(_reqpays, Store3);
                    string _langue= "SELECT langueid,libelle  FROM langue";
                    this.FillStore(_langue, this.StoreComboboxlangue);
            }
        }
        //Actualiser du combobox ville
        protected void CitiesRefresh(object sender, StoreReadDataEventArgs e)
        {
            string _req2 = "SELECT villeid,ville from ville where paysid=" + this.paysid.SelectedItem.Value;
            this.FillStore(_req2, CitiesStore);
        }
        //Traitement Forme
        [DirectMethod()]
        public int MethodeProfil(string _ActionSelected, string pays, string ville, string lang)
        {
            //Déclaration des champs de la forme
            int retourmethod = 0;
            string _ChaineUpdate = "";
            string _ville = ville;
            string _pays = pays;
            string _lang = lang;
            if (_lang == "0")
            {
                string _rep = "select c.langueid from client c where actif='1' and clientid=" + this.getCurrentUser().getClientId();
                SqlDataReader _retourSelect = this.Select(_rep);
                _retourSelect.Read();
                _lang = _retourSelect[0].ToString();
                _retourSelect.Close();

            }
            List<string> _ArrayActionexiste = new List<string>();
            List<string> _ArrayActionSelected = _ActionSelected.Split(';').ToList<string>();
            string _userid = this.utilisateurid.Text.ToString();
            string _nom = this.nom.Text.ToString();
            string _prenom = this.prenom.Text.ToString();
            string _email = this.email.Text.ToString();
            string _login = this.login.Text.ToString();
            string _pwd = this.pwd.Text.ToString();
            if (this.pwd.Text.ToString() != "gpeowdm"){ _pwd = Hash(this.pwd.Text.ToString()); }
            string _tel = this.tel.Text.ToString();
            string _adresse = this.adresse.Text.ToString();

            string valeurs = "'" + _login + "'," + "'" + _nom + "'," + "'" + _prenom + "'," + "'" + _email + "'," + "'" + _pwd + "'," + "'" + DateTime.Now + "','','" + _tel + "','" + _adresse + "',1," + this.getCurrentUser().getClientId().ToString() + ",'" + _ville + "','" + _pays + "','" + _lang + "'";
            if (_pwd == "gpeowdm") {
                _ChaineUpdate = "login='" + _login + "',nom" + "='" + _nom + "',prenom" + "='" + _prenom + "'" + ",email='" + _email + "'" + ",tel='" + _tel + "'" + ",adresse='" + _adresse + "'" + ",date_modif='" + DateTime.Now + "'" + ",villeid='" + _ville + "'" + ",paysid='" + _pays + "'" + ",langueid='" + _lang + "'";
            }
            else
            {
                _ChaineUpdate = "login='" + _login + "',nom" + "='" + _nom + "',prenom" + "='" + _prenom + "'" + ",email='" + _email + "'" + ",tel='" + _tel + "'" + ",adresse='" + _adresse + "'" + ",pwd='" + _pwd + "'" + ",date_modif='" + DateTime.Now + "'" + ",villeid='" + _ville + "'" + ",paysid='" + _pays + "'" + ",langueid='" + _lang + "'";
            }
            // Dans le cas d'ajout d'un nouvel élement
            if (_userid == "")
            {
                string _req = "insert into " + this._TableModule + " values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                int retourSave = this.InsertRetourId(_req);
                if (retourSave != -1)
                {
                    if (_ArrayActionSelected[0] != "")
                    {
                        foreach (String _Selected in _ArrayActionSelected)
                        {

                            string _req2 = "insert into profil_user (utilisateurid,profilid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                            this.Insert(_req2);
                        }
                    }
                }
                retourmethod = 1;
            }
            // Dans le cas de la midification d'un élément existant
            else
            {
                string _req = "update " + this._TableModule + " set " + _ChaineUpdate + " where utilisateurid=" + _userid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
                if (retourSave != -1)
                {
                    string _reqexiste = "SELECT profilid FROM profil_user where actif='1' and utilisateurid=" + _userid;
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
                    //Ajout  des information du noouvel utilisateur dans profil user
                    foreach (string _SelectedAdd in _listAdd)
                    {

                        string _req2 = "insert into profil_user (utilisateurid,profilid,actif,clientid) values(" + _userid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //Actualisation  des information de utilisateur dans profil user
                    foreach (string _SelectedDelete in _listdelet)
                    {

                        string _req2 = "update profil_user set actif='0' where profilid="+ _SelectedDelete + " and utilisateurid=" + _userid + " and clientid=" + this.getCurrentUser().getClientId().ToString();;
                        this.Insert(_req2);
                    }
                }
                retourmethod = 1;
            }

            return retourmethod; 
        }
    }
}