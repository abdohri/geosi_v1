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


namespace GeoSI.Website.Modules.RapportArret
{
    public partial class RapportArret : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Title = Resources.Resource.title_Module_Vehicules;
            this.SetNomModule("Vehicules");
            if (!X.IsAjaxRequest)
            {

                string _req = "select v.vehiculeid,v.matricule,v.code,v.imgVehicule,v.numero_chassis,v.modele,v.consommation,v.kilometrage,m.libelle marquevehicule,t.libelle typevehicule from vehicules v "
                             + "left join typevehicule t on v.typevehiculeid=t.typevehiculeid "
                              + "left join marquevehicule m on  v.marquevehiculeid=m.marquevehiculeid "
                             + "where v.clientid=" + this.getCurrentUser().getClientId() + " and v.actif='1' order by v.vehiculeid desc";
                this.FillStore(_req, this.StoreMaster);

                string _marque = "select libelle marquevehicule from marquevehicule where actif='1' and ClientId=-1 or ClientId=" + this.getCurrentUser().getClientId();
                this.FillStore(_marque, this.Store2);

                string _type = "select libelle typevehicule from typevehicule where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();
                this.FillStore(_type, this.Store3);


            }

        }


        protected void MyData_Refresh(object sender, StoreReadDataEventArgs e)
        {
            string _req = "select v.vehiculeid,v.matricule,v.code,v.imgVehicule,v.numero_chassis,v.modele,v.consommation,v.kilometrage,m.libelle marquevehicule,t.libelle typevehicule from vehicules v "
                                 + "left join typevehicule t on v.typevehiculeid=t.typevehiculeid "
                                  + "left join marquevehicule m on  v.marquevehiculeid=m.marquevehiculeid "
                                 + "where v.clientid=" + this.getCurrentUser().getClientId() + " and v.actif='1' order by v.vehiculeid desc";
            this.FillStore(_req, this.StoreMaster);
        }
    }
}