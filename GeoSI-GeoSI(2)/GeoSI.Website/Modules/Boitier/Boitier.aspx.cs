
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


namespace GeoSI.Website.Modules.Boitier
{
    public partial class Boitier : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int _TypeCompte = this.getCurrentUser().getTypeCompte();
            this.Page.Title = Resources.Resource.title_Module_Boitier;
            this.SetNomModule("Boitier");
            if (!X.IsAjaxRequest)
            {
                if (GeHabilitationAction("Consulter"))
                {
                    if (_TypeCompte == 3)//BackOffice
                    {
                        this.CommandColumn3.Hidden = true;
                    }
                    string _req = "SELECT b.boitierid,b.imei,m.marque_boitier,t.libelle,NULLIF(b.date_debut_garantie,'1900-01-01 00:00:00.000') date_debut_garantie,NULLIF(b.date_fin_garantie,'1900-01-01 00:00:00.000') date_fin_garantie,NULLIF(b.date_achat,'1900-01-01 00:00:00.000') date_achat FROM boitier b  left JOIN marqueboitier m ON b.marque_boitierid=m.marque_boitierid left JOIN type_boitier t   ON b.typeboitierid=t.typeboitierid where  b.clientid=" + this.getCurrentUser().getClientId() + " and b.actif='1' order by b.boitierid desc";
                    this.FillStore(_req, this.StoreMaster);

                    string _reqTypeBoitier = "select libelle boitiertype from type_boitier where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();

                    this.FillStore(_reqTypeBoitier, this.Store2);

                    string _reqMarqueBoitier = "select marque_boitier from marqueboitier where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();

                    this.FillStore(_reqMarqueBoitier, this.Store6);

                }

                if (!GeHabilitationAction("ajouter")) { this.Button1.Hidden = true; }
                if (!GeHabilitationAction("modifier")) { this.CommandColumn1.Hidden = true; }
                if (!GeHabilitationAction("supprimer")) { this.CommandColumn2.Hidden = true; }

            }
        }

        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req = "SELECT b.boitierid,b.imei,m.marque_boitier,t.libelle,NULLIF(b.date_debut_garantie,'1900-01-01 00:00:00.000') date_debut_garantie,NULLIF(b.date_fin_garantie,'1900-01-01 00:00:00.000') date_fin_garantie,NULLIF(b.date_achat,'1900-01-01 00:00:00.000') date_achat FROM boitier b  left JOIN marqueboitier m ON b.marque_boitierid=m.marque_boitierid left JOIN type_boitier t   ON b.typeboitierid=t.typeboitierid where  b.clientid=" + this.getCurrentUser().getClientId() + " and b.actif='1' order by b.boitierid desc";
            this.FillStore(_req, this.StoreMaster);
        }


        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void DesactiverRowsBehind(string id)
        {
            X.Msg.Confirm("Message", Resources.Resource.msgDesactiver, new MessageBoxButtonsConfig
            {
                Yes = new MessageBoxButtonConfig
                {
                    Handler = "X.DesactiverRows('" + id + "')",
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
        public void DesactiverRows(string id)
        {
            try
            {
                string _req2 = "update boitier set clientid=-1,date_modif='" + DateTime.Now + "' where boitierid=" + int.Parse(id);
                int _retourDes = this.Update(_req2);
                if (_retourDes != -1)
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

                string _req1 = "select count(*) from cartesim_boitier where boitierid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                SqlDataReader _retourSelect = this.Select(_req1);
                _retourSelect.Read();
                int varcount = (int)_retourSelect[0];
                _retourSelect.Close();

                string _reqcount2 = "select count(*) from affectation_vehicule_boitier where boitierid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                SqlDataReader _retourSelectvehicule = this.Select(_reqcount2);
                _retourSelectvehicule.Read();
                int varcount2 = (int)_retourSelectvehicule[0];
                _retourSelectvehicule.Close();

                if (varcount > 0 && varcount2 > 0)
                {
                    X.Msg.Confirm(Resources.Resource.Message, Resources.Resource.msgDeleteBoitier1, new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = "X.Delete2('" + id + "')",
                            Text = Resources.Resource.deleteconfirmOui
                        },
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "X.DoNo()",
                            Text = Resources.Resource.deleteconfirmNon
                        }
                    }).Show();
                }
                else if (varcount > 0 && varcount2 == 0)
                {
                    X.Msg.Confirm(Resources.Resource.Message, Resources.Resource.msgDeleteBoitier2, new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = "X.Delete2('" + id + "')",
                            Text = Resources.Resource.deleteconfirmOui
                        },
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "X.DoNo()",
                            Text = Resources.Resource.deleteconfirmNon
                        }
                    }).Show();
                }
                else if (varcount == 0 && varcount2 > 0)
                {
                    X.Msg.Confirm(Resources.Resource.Message, Resources.Resource.msgDeleteBoitier3, new MessageBoxButtonsConfig
                    {
                        Yes = new MessageBoxButtonConfig
                        {
                            Handler = "X.Delete2('" + id + "')",
                            Text = Resources.Resource.deleteconfirmOui
                        },
                        No = new MessageBoxButtonConfig
                        {
                            Handler = "X.DoNo()",
                            Text = Resources.Resource.deleteconfirmNon
                        }
                    }).Show();
                }
                else
                {
                    string _req2 = "update boitier set actif=0,date_modif='" + DateTime.Now + "' where boitierid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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


        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        public void Delete2(string _RecordID)
        {
            string _req2 = "update boitier set actif=0,date_modif='" + DateTime.Now + "' where boitierid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
            int _retourDelete = this.Update(_req2);

            if (_retourDelete != -1)
            {
                string _reqTableassociatif = "update cartesim_boitier set actif=0,date_desaffectation='" + DateTime.Now + "' where boitierid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                int _retoursup = this.Update(_reqTableassociatif);

                string _reqTableassociatif1 = "update affectation_vehicule_boitier set actif=0,date_desaffectation='" + DateTime.Now + "' where boitierid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                int _retoursup1 = this.Update(_reqTableassociatif1);


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