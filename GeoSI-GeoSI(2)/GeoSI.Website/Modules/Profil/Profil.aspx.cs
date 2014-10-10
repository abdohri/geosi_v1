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
using System.Data.Odbc;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Profil
{
    public partial class Profil : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Resources.Resource.title_Module_Profil;
            this.SetNomModule("Profil");

            if (!X.IsAjaxRequest)
            { //Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {
                    string _req = "select p.profilid,p.libelle,p.description, h.action from profil p , habilitation h, habilitation_profil hp where hp.profilid=p.profilid and hp.habilitationid=h.habilitationid   and p.clientid=" + this.getCurrentUser().getClientId() + " and p.actif='1' order by p.profilid desc";

                    this.FillStore(_req, this.StoreGrid);

                    //string _reqHbilitation = "select action from habilitation ";

                    //this.FillStore(_reqHbilitation, this.Store6);
                }
                //Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
                if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
                if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }

            }
        }
        //Actualisation du grid
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req = "select profilid,libelle,description  from profil  where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by profilid desc";

            this.FillStore(_req, this.StoreGrid);
        }
        //Traitement en cas de suppression d'un élement du grid
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

                string _req2 = "update profil set actif=0    where profilid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                int _retourDelete = this.Update(_req2);

                if (_retourDelete != -1)
                {
                    this.StoreGrid.Reload();
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