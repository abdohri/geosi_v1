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
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Personnel
{
    public partial class Personnel : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Resources.Resource.title_Module_Personnel;
            this.SetNomModule("Personnel");
            if (!X.IsAjaxRequest)
            {//Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {
                    string _req = "select p.personnelid,p.nom,p.prenom,p.permis,p.cin,p.cnss,p.photo,NULLIF(p.date_embauche,'1900-01-01 00:00:00.000') date_embauche,NULLIF(p.date_expiration,'1900-01-01 00:00:00.000') date_expiration,t.libelle FROM personnel p left JOIN par_typepersonnel t ON p.typepersonnelid=t.typepersonnelid where p.clientid=" + this.getCurrentUser().getClientId() + " and p.actif='1' order by p.personnelid desc";

                    this.FillStore(_req, this.StoreMaster);

                    string _reqtypepersonnel = "select libelle typepersonnel from par_typepersonnel where clientid=-1 or clientid=" + this.getCurrentUser().getClientId();

                    this.FillStore(_reqtypepersonnel, this.Store2);
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
            string _req = "select p.personnelid,p.nom,p.prenom,p.permis,p.cin,p.cnss,p.photo,p.date_embauche,p.date_expiration,t.libelle FROM personnel p left JOIN par_typepersonnel t ON p.typepersonnelid=t.typepersonnelid where p.clientid=" + this.getCurrentUser().getClientId() + " and p.actif='1' order by p.personnelid desc";

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

                string _req2 = "update personnel set actif=0  where personnelid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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