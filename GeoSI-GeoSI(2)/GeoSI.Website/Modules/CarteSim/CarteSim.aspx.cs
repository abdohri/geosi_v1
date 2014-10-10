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

namespace GeoSI.Website.Modules.CarteSim
{
    public partial class CarteSim : PageBase
    {  //Chargement de la page
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Resources.Resource.title_Module_CarteSim;
            this.SetNomModule("CarteSim");
            if (!X.IsAjaxRequest)
            {//Dans le cas où l'habilitation pour la consultation existe: Importation des données pour remplir le grid
                if (GeHabilitationAction("Consulter"))
                {
                    string _req = "select s.cartesimid,s.numero_serie,s.numero_tel,s.code_pin,s.code_puk,o.libelle  from carte_sim s,par_operateur o where s.operateurid=o.operateurid and s.clientid=" + this.getCurrentUser().getClientId() + " and s.actif='1' order by s.cartesimid desc";

                    this.FillStore(_req, this.StoreMaster);

                    string _reqoperateur = "select libelle operateur from par_operateur where clientid=-1 or clientid=" + this.getCurrentUser().getClientId();

                    this.FillStore(_reqoperateur, this.Store2);

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
            string _req = "select s.cartesimid,s.numero_serie,s.numero_tel,s.code_pin,s.code_puk,o.libelle  from carte_sim s,par_operateur o where s.operateurid=o.operateurid and s.clientid=" + this.getCurrentUser().getClientId() + " and s.actif='1' order by s.cartesimid desc";

            this.FillStore(_req, this.StoreMaster);
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
                        string _req1 = "select count(*) from cartesim_boitier where cartesimid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
                        SqlDataReader _retourSelect = this.Select(_req1);
                        _retourSelect.Read();
                        int varcount = (int)_retourSelect[0];
                        _retourSelect.Close();
                        //Dans la cas où il y a une liaison
                        if (varcount > 0)
                        {
                            X.Msg.Confirm(Resources.Resource.Message, Resources.Resource.cartsim_msgDelete2, new MessageBoxButtonsConfig
                            { // confirmation : suppresion logique d'un élement lié
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
                            string _req2 = "update carte_sim set actif=0,date_modif='" + DateTime.Now + "' where cartesimid=" + int.Parse(id) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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
            string _req2 = "update carte_sim set actif=0,date_modif='" + DateTime.Now + "' where cartesimid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
            int _retourDelete = this.Update(_req2);

            if (_retourDelete != -1)
            {
                string _reqTableassociatif = "update cartesim_boitier set actif=0,date_desaffectation='" + DateTime.Now + "' where cartesimid=" + int.Parse(_RecordID) + " and actif='1' and clientid=" + this.getCurrentUser().getClientId();
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