
using System.Web.Security;
using System.Web.SessionState;

using System.Data.Odbc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Timers;
using Ext.Net;
using System.Threading;
using System.Globalization;
using System.Data.Odbc;
using GeoSI.Website.Common;
namespace GeoSI.Website
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
           System.Diagnostics.Debugger.Break();
            System.Timers.Timer aTimer = new System.Timers.Timer(1 * 60 * 1000 * 60 * 24); //un jour
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Start();


            System.Timers.Timer aTimer2 = new System.Timers.Timer(1 * 60 * 1000 * 60); //1 heure
            aTimer2.Elapsed += new ElapsedEventHandler(CNA);
            aTimer2.Start();

            System.Timers.Timer aTimer3 = new System.Timers.Timer(1 * 60 * 1000 * 10); //10 minutes
            aTimer3.Elapsed += new ElapsedEventHandler(DepV);
            aTimer3.Start();

            System.Timers.Timer aTimer4 = new System.Timers.Timer(1 * 60 * 1000 ); //10 minutes
            aTimer4.Elapsed += new ElapsedEventHandler(TestGlob);
            aTimer4.Start();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Common.PageBase p = new Common.PageBase();
            p.CompteExpAlarme();
            p.PermisAlarme();
            p.kiloAberrant();
            p.consomationEx();


        }

        private void CNA(object source, ElapsedEventArgs e)
        {
            Common.PageBase p = new Common.PageBase();
            p.ConduitNAAlarme();
          //  p.Alarme_Entrer_zone_interdite();
          //  p.Alarme_Sortie_zone_interdite();

        }
        private void TestGlob(object source, ElapsedEventArgs e)
        {
            Common.PageBase p = new Common.PageBase();
            p.Insert("insert into test(note) values('bn tst')");
            //  p.Alarme_Entrer_zone_interdite();
            //  p.Alarme_Sortie_zone_interdite();

        }
        private void DepV(object source, ElapsedEventArgs e)
        {
            Common.PageBase p = new Common.PageBase();
            p.DepassementVitesseAlarme();



        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code qui s'exécute à l'arrêt de l'application

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code qui s'exécute lorsqu'une erreur non gérée se produit

        }

        void Session_Start(object sender, EventArgs e)
        {

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code qui s'exécute lorsqu'une session se termine. 
            // Remarque : l'événement Session_End est déclenché uniquement lorsque le mode sessionstate
            // a la valeur InProc dans le fichier Web.config. Si le mode de session a la valeur StateServer 
            // ou SQLServer, l'événement n'est pas déclenché.
        }

    }
}
