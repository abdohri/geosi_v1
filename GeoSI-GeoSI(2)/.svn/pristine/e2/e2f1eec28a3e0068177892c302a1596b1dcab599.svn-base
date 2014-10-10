using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using Ext.Net;

namespace GeoSI.Website.Modules.Revendeur
{
    public partial class Revendeur : PageBase
    {


        protected void Page_Load(object sender, EventArgs e)
        {
           
            this.Page.Title = Resources.Resource.Title_Module_Revendeur;
            if (!X.IsAjaxRequest)
            {//Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {
                    int _TypeCompte = this.getCurrentUser().getTypeCompte();
                    if (_TypeCompte == 1)//BackOffice
                    {
                        string _req = "select r.*,p.pays pays,v.ville ville,l.libelle langue from revendeur r left join pays p on r.paysid=p.paysid left join ville v on r.villeid=v.villeid left join langue l on r.langueid=l.langueid where r.actif='1' order by r.revendeurid desc";
                        this.FillStore(_req, this.StoreMaster);
                    }
                    else
                    {
                        //  Response.Redirect("../Index.aspx");
                    }

                    string _reqlangue = "SELECT libelle langue  FROM langue";

                    this.FillStore(_reqlangue, this.StoreLangue);

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
            string _req = "select r.*,p.pays pays,v.ville ville,l.libelle langue from revendeur r left join pays p on r.paysid=p.paysid left join ville v on r.villeid=v.villeid left join langue l on r.langueid=l.langueid where r.actif='1' order by r.revendeurid desc";

            this.FillStore(_req, this.StoreMaster);
        }

        
        protected Field OnCreateFilterableField(object sender, ColumnBase column, Field defaultField)
        {
            if (column.DataIndex == "raison_sociale")
            {
                ((TextField)defaultField).Icon = Icon.Magnifier;
            }
            return defaultField;
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

                string _req2 = "update revendeur set actif=0   where revendeurid=" + int.Parse(id) + " and actif='1'";
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