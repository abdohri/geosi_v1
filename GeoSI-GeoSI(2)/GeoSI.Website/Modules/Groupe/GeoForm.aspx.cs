using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Groupe
{
    public partial class GeoForm : Form
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("groupe");
            this.PreSchema("groupe", "groupeid");

            if (!X.IsAjaxRequest)
            { // Dans le cas de la modification d'un élement existant
                string id = Request.Params.Get("id").ToString();
                if (id != "0")
                {
                    this.InitForm(id, this.UserForm, this.getCurrentUser().getClientId());
                    string _reqroot = "select ssgroupeid from groupe where groupeid=" + id;
                    SqlDataReader drroot = Select(_reqroot);
                    if (drroot.Read()) {
                        if (drroot[0].ToString() == "0") {
                            this.ssgroupeid.Disabled=true;
                        }
                    }
                    drroot.Close();
                }
                // Remplissage des combobox existant dans la forme
                string _req1 = "select gv.vehiculeid,v.matricule from groupe_vehicule gv inner join vehicules v on gv.vehiculeid=v.vehiculeid where gv.actif=1 and gv.groupeid=" + id;
                this.FillStore(_req1, Store1);
                string _req2 = "SELECT vehiculeid,matricule FROM vehicules where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and vehiculeid not in(select vehiculeid from groupe_vehicule where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and groupeid=" + id + ")";
                this.FillStore(_req2, Store2);
                string _reqville = "select groupeid,libelle from groupe where actif='1' and clientid=" + this.getCurrentUser().getClientId();
                this.FillStore(_reqville, this.Store3);
            }
        }

        //Méthide profil

        [DirectMethod()]
        public int MethodeProfil(string _ActionSelected, string ssgroupe)
        {
            int retourmethod = 0;
            string _ChaineUpdate = "";
            string _ssgroupe = ssgroupe;
            List<string> _ArrayActionexiste = new List<string>();
            List<string> _ArrayActionSelected = _ActionSelected.Split(';').ToList<string>();
            string _groupeid = this.groupeid.Text.ToString();
            string _libelle = this.libelle.Text.ToString();

            string valeurs = "'" + _libelle + "'," + int.Parse(_ssgroupe) + "," + this.getCurrentUser().getClientId() + ",1,'" + DateTime.Now + "'";

            _ChaineUpdate = "libelle='" + _libelle + "',ssgroupeid" + "=" + _ssgroupe + ",date_modif='" + DateTime.Now + "'";

            // Ajout d'un élément 
            if (_groupeid == "")
            {
                string _req = "insert into " + this._TableModule + " values (" + valeurs + ") SELECT IDENT_CURRENT('" + this._TableModule + "')";
                int retourSave = this.InsertRetourId(_req);
                if (retourSave != -1)
                {
                    if (_ArrayActionSelected[0] != "")
                    {
                        foreach (String _Selected in _ArrayActionSelected)
                        {

                            string _req2 = "insert into groupe_vehicule (groupeid,vehiculeid,actif,clientid) values(" + retourSave + "," + int.Parse(_Selected) + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                            this.Insert(_req2);
                        }
                    }
                }
                retourmethod = 1;
            }
            // Modification d'un élément groupe
            else
            {
                string _req = "update " + this._TableModule + " set " + _ChaineUpdate + " where groupeid=" + _groupeid + " and clientid=" + this.getCurrentUser().getClientId().ToString();
                int retourSave = this.Update(_req);
                if (retourSave != -1)
                {
                    string _reqexiste = "SELECT vehiculeid FROM groupe_vehicule where actif='1' and groupeid=" + _groupeid;
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
                    //affecter un Véhicule à un groupe
                    foreach (string _SelectedAdd in _listAdd)
                    {

                        string _req2 = "insert into groupe_vehicule (groupeid,vehiculeid,actif,clientid) values(" + _groupeid + "," + _SelectedAdd + ",1," + this.getCurrentUser().getClientId().ToString() + ")";
                        this.Insert(_req2);
                    }
                    //Désaffecter un Véhicule à un groupe
                    foreach (string _SelectedDelete in _listdelet)
                    {

                        string _req2 = "update groupe_vehicule set actif='0' where vehiculeid=" + _SelectedDelete + " and groupeid=" + _groupeid + " and clientid=" + this.getCurrentUser().getClientId().ToString(); ;
                        this.Update(_req2);
                    }
                }
                retourmethod = 1;
            }

            return retourmethod;
        }
    }
}