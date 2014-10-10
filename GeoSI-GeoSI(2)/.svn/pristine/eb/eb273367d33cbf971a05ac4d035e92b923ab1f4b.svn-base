using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.UserBackOffice
{
    public partial class UserBackOffice : PageBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {

            this.Page.Title = Resources.Resource.Title_Module_UserBackOffice;
            if (!X.IsAjaxRequest)
            {
                if (GeHabilitationAction("Consulter"))
                {
                    int _TypeCompte = this.getCurrentUser().getTypeCompte();
                    if (_TypeCompte == 1)//BackOffice
                    {
                        string _req = "select * from userbackoffice where actif='1'";
                        this.FillStore(_req, this.StoreMaster);
                    }
                    else
                    {
                        //  Response.Redirect("../Index.aspx");
                    }
                }

                if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
                if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
                if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }

            }
        }
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req = "select * from userbackoffice  where actif='1'";
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

                string _req2 = "update userbackoffice set actif=0 , date_modif='" + DateTime.Now + "'  where userbackofficeid=" + int.Parse(id)+"and actif='1'";
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