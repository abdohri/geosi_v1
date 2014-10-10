using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using Ext.Net;

namespace GeoSI.Website.Modules.Client
{
    public partial class Client : PageBase
    {
        
        private string _req = "";
        private string _actif = "";
        public int _TypeCompte = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            _actif = Request.Params.Get("a");
            _TypeCompte = this.getCurrentUser().getTypeCompte();
            this.Page.Title = Resources.Resource.title_Module_Client;
            this.SetNomModule("Client");
            if (!X.IsAjaxRequest)
            {
               
                if (_TypeCompte == 1)//BackOffice
                {
                    if (_actif != null)
                    {
                        //_req = "SELECT clientid ,logo,raison_sociale ,sigle,site_web,email,adresse,tel,fax,capital,annee_creation,cnss,pf.libelle profilclient FROM client c,profilclient pf  where c.actif='1' and c.profilclientid=pf.profilclientid and c.profilclientid=1 order by clientid desc";
                        this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  c.actif='" + _actif + "' order by clientid desc";
                    }
                    else
                    {
                        this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid order by clientid desc";
                    }
                }
                else if (_TypeCompte == 2)//Revendeur
                {
                    if (_actif != null)
                    {
                        this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  revendeurid=" + this.getCurrentUser().getRevendeurId() + " and c.actif='" + _actif + "' order by clientid desc";
                    }
                    else
                    {
                        this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  revendeurid=" + this.getCurrentUser().getRevendeurId() + " order by clientid desc";

                    }
                }
                else
                {
                    //Response.Redirect("../Index.aspx");
                }
                //Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {

                    this.FillStore(_req, this.StoreMaster);

                    string _reqoperateur = "SELECT libelle profilclient FROM profilclient";
                    this.FillStore(_reqoperateur, this.Store2);
                }

                if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
                if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
                if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }


            }
        }
        //Actualisation du grid
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            if (_TypeCompte == 1)//BackOffice
            {
                if (_actif != null)
                {
                    //_req = "SELECT clientid ,logo,raison_sociale ,sigle,site_web,email,adresse,tel,fax,capital,annee_creation,cnss,pf.libelle profilclient FROM client c,profilclient pf  where c.actif='1' and c.profilclientid=pf.profilclientid and c.profilclientid=1 order by clientid desc";
                    this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  c.actif='" + _actif + "' order by clientid desc";
                }
                else
                {
                    this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid order by clientid desc";
                }
            }
            else if (_TypeCompte == 2)//Revendeur
            {
                if (_actif != null)
                {
                    this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  revendeurid=" + this.getCurrentUser().getRevendeurId() + " and c.actif='" + _actif + "' order by clientid desc";
                }
                else
                {
                    this._req = "SELECT c.*,pf.libelle profilclient FROM client c  left JOIN profilclient pf   ON c.profilclientid=pf.profilclientid left JOIN juridique j   ON c.juridiqueid=j.juridiqueid where  revendeurid=" + this.getCurrentUser().getRevendeurId() + " order by clientid desc";

                }
            }
            this.FillStore(this._req, this.StoreMaster);
        }

        [DirectMethod()]
        public void ConneteWithClient(int _Clientid)
        {
            try
            {
                UserInfo _user = new UserInfo();
                _user = this.getCurrentUser();
                _user.setClientId(_Clientid);
                this.setCurrentUser(_user);
                Response.Redirect("../Carte/TempsReel.aspx");
            }
            catch (Exception)
            {

            }
        }


        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void GridActiver(string id)
        {
            try
            {
                string _req2 = "update client set actif='1',date_modif='" + DateTime.Now + "' where clientid=" + int.Parse(id);
                int _retourDes = this.Update(_req2);
                if (_retourDes != -1)
                {
                    this.StoreMaster.Reload();
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = Resources.Resource.Information,
                        Message = Resources.Resource.ClientActivation,
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
            }
            catch (Exception)
            {

            }
        }

        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRowsBehind(string id)
        {
            X.Msg.Confirm("Message", Resources.Resource.msgDelete1, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "X.DeleteRows('" + id + "')",
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
        public void DeleteRows(string id)
        {
            try
            {

                string _req2 = "update client set actif=0,date_modif='" + DateTime.Now + "' where clientid=" + int.Parse(id);
                int _retourDelete = this.Update(_req2);

                if (_retourDelete != -1)
                {
                    this.StoreMaster.Reload();
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

            }
            catch (Exception)
            {

            }


        }

    }
}