using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Utilisateur
{
    public partial class Utilisateur : PageBase
    {  
        //Chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Resources.Resource.title_Module_Utilisateur;
            this.SetNomModule("utilisateur");
            if (!X.IsAjaxRequest)
            {
                //Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {
                    string _req = "select * from utilisateur where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by utilisateurid desc";
                    this.FillStore(_req, this.StoreMaster);
                }
                //Dans le cas où une des habilitations ( ajout, modification ou suppression) ne sont pas accordées cacher le boutton associé
                if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
                if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
                if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }

            }
        }
        //Actualisation du grid
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req = "select * from utilisateur where clientid=" + this.getCurrentUser().getClientId() + " and actif='1' order by utilisateurid desc";
            this.FillStore(_req, this.StoreMaster);
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
                

                string _req2 = "update utilisateur set actif=0   , date_modif='" + DateTime.Now + "'   where utilisateurid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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