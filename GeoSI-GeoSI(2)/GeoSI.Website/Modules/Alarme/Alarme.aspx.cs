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
using System.Data;
using System.Data.SqlClient;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Alarme
{
    public partial class Alarme :PageBase
    {
        public UserInfo s = new UserInfo();
        public PageBase p = new PageBase();
        public SqlDataReader d;
        public SqlDataReader dd;
        public Notification not = new Notification();
        public List<Notification> lst = new List<Notification>();
        public List<vehicules> lstv = new List<vehicules>();


        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = "Alarme";
            this.SetNomModule("Alarme");
            s = p.getCurrentUser();

            if (!X.IsAjaxRequest)
            {
               
                  
                    string _req = "select n.idNoti,n.DateAlert,n.Descriptione,n.Vu,v.matricule,v.imgVehicule,m.libelle , a.titre from Notification n inner join vehicules v on v.vehiculeid=n.vehiculeid inner join marqueVehicule m on m.marquevehiculeid=v.marquevehiculeid inner join alerte a on a.alerteid=n.alerteid where n.utilisateurid="+s.getUserId()+"order by Vu ASC";
                    this.FillStore(_req, this.StoreMaster);

                //for(int i=0;i<this.StoreMaster.get)
                //{
                //}

  //                  d = p.Select(_req);
                   
//                    if (d.HasRows)
//                    {
//                        int cpt=0;
//                        while (d.Read())
//                        { 
                        
//                               if (d[3].Equals("oui"))
//                            {
//                             //   this.CommandColumn1.Hidden = true;
//                                this.CommandColumn2.Element.Item(cpt).Hide();
//                            }
//                               cpt++;
//cpt++;

//                        }
//                    }
//                    d.Close();

                //    if (this.CommandColumn2.DataIndex.Equals("oui"))
                //    {
                        

                //    }
                ////Dans le cas où une des habilitations ( ajout, modification ou suppression) ne sont pas accordées cacher le boutton associé
               // if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
               // if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
            //   if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }
                    p.Update("update Notification set Vu='oui' where alerteid in (6,8,18,20,30,32)");
            }

        }
        //Actualisation du grid
        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {

            string _req = "select n.idNoti,n.DateAlert,n.Descriptione,n.Vu,v.matricule,v.imgVehicule,m.libelle , a.titre from Notification n inner join vehicules v on v.vehiculeid=n.vehiculeid inner join marqueVehicule m on m.marquevehiculeid=v.marquevehiculeid inner join alerte a on a.alerteid=n.alerteid where n.utilisateurid=" + s.getUserId();
            this.FillStore(_req, this.StoreMaster);
        }


        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void UpdateVisibilite(string id)
        {
            string _req2 = "update  Notification set Vu='oui' where idNoti=" + int.Parse(id);
            int _retourDelete = this.Update(_req2);

            if (_retourDelete != -1)
            {
                this.StoreMaster.Reload();
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = Resources.Resource.Information,
                    Message = "Alarme vu ",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
            }
        }

        //Traitement en cas de suppression d'un élement du grid
        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRowsBehind(string id)
        {
            X.Msg.Confirm("Message", Resources.Resource.msgDelete1, new MessageBoxButtonsConfig
            {
                // confirmation de la suppression : traitement en cas de confirmation 
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "X.DeleteRows('" + id + "')",
                    Text = Resources.Resource.deleteconfirmOui
                },
                // Non confirmation de la suppression 
                No = new MessageBoxButtonConfig
                {
                    Handler = "X.DoNo()",
                    Text = Resources.Resource.deleteconfirmNon
                }
            }).Show();

        }

        //Traitement en cas de confirmation de suppression d'un élement du grid
        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DeleteRows(string id)
        {
            try
            {


                //Véfification si l'élément à supprimer est associé a un autre objet
                string _req1 = "select count(*) from affectation_vehicule_boitier where vehiculeid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                SqlDataReader _retourSelect = this.Select(_req1);
                _retourSelect.Read();
                int varcount = (int)_retourSelect[0];
                _retourSelect.Close();
                //Dans la cas où il y a une liaison
                if (varcount > 0)
                {
                    X.Msg.Confirm(Resources.Resource.Message, Resources.Resource.vehicule_msgDelete2, new MessageBoxButtonsConfig
                    {    // confirmation : suppresion logique d'un élement lié
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = "X.Delete2('" + id + "')",
                            Text = Resources.Resource.deleteconfirmOui
                        },
                        // non confirmation 
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "X.DoNo()",
                            Text = Resources.Resource.deleteconfirmNon
                        }
                    }).Show();
                }
                //Dans le cas où l'élément n'est affecté à aucun objet 
                else
                {
                    string _req2 = "update  vehicules set actif=0,date_modif='" + DateTime.Now + "' where vehiculeid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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
                }






            }
            catch (Exception)
            {

            }


        }

        //Suppression logique de l'élément lié
        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void Delete2(string _RecordID)
        {
            string _req2 = "update vehicules set actif=0,date_modif='" + DateTime.Now + "' where vehiculeid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
            int _retourDelete = this.Update(_req2);

            if (_retourDelete != -1)
            {
                string _reqTableassociatif = "update affectation_vehicule_boitier set actif=0,date_desaffectation='" + DateTime.Now + "' where vehiculeid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                int _retoursup = this.Update(_reqTableassociatif);

                if (_retoursup != -1)
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
            }



        }
    }
}