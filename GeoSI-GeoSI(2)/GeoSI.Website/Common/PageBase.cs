using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Threading;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using Ext.Net;
using System.Web.Security;
using GeoSI.Website.Common;
using System.Net.Mail;

using System.Web.UI.WebControls;
using System.Threading;
using System.Net;
using System.Net.Mail;
namespace GeoSI.Website.Common
{
    public class PageBase : Page
    {
        #region Variable global
        //--------------------- Début ----------------------------
        protected List<string> ListAction = new List<string>();
        private GridPanel _grid = new GridPanel();
        private Store _store = new Store();
        private string _TableModule;
        private string _IdTableModule = null;
        protected string Currentmodule = null;
        //--------------------- Fin ------------------------------
        #endregion

        #region Constructeur
        //--------------------- Début ----------------------------
        public PageBase()
        {
        }
        //--------------------- Fin ------------------------------
        #endregion

        #region Methodes
        //--------------------- Début ----------------------------
        public void ConduitNAAlarme()
        {
            /*
             
            select ua.alerteid, v.matricule ,u.utilisateurid ,u.email,u.tel ,cv.jour,cv.heurD,cv.heurF from Datatracker d
inner join boitier b on b.imei=d.imei 
 inner join affectation_vehicule_boitier abv on abv.boitierid=b.boitierid 
 inner join vehicules  v on v.vehiculeid = abv.vehiculeid 
inner join vehicule_CNA cv on cv.vehiculeid=v.vehiculeid
  inner join utilisateur u on u.clientid= v.clientid
 inner join user_alerte ua on ua.utilisateurid=u.utilisateurid
 where d.contact=1 and  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-1,CURRENT_TIMESTAMP)
and cv.jour = datename(dw,getdate())
 and  cast(d.GPSDateTime AS datetime) >=  cast( (convert(varchar,(CONVERT(date,CURRENT_TIMESTAMP,103)),103))+' '+cv.heurD AS datetime)
 and  cast(d.GPSDateTime AS datetime) <=  cast((convert(varchar,(CONVERT(date,CURRENT_TIMESTAMP,103)),103))+' '+cv.heurF AS datetime)
and (ua.alerteid=12 or ua.alerteid=24 or ua.alerteid=36)   
             */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = "select ua.alerteid, v.vehiculeid,v.matricule ,u.utilisateurid ,u.email,u.tel ,cv.jour,cv.heurD,cv.heurF from Datatracker d inner join boitier b on b.imei=d.imei  inner join affectation_vehicule_boitier abv on abv.boitierid=b.boitierid  inner join vehicules  v on v.vehiculeid = abv.vehiculeid inner join vehicule_CNA cv on cv.vehiculeid=v.vehiculeid inner join utilisateur u on u.clientid= v.clientid inner join user_alerte ua on ua.utilisateurid=u.utilisateurid where d.contact=1 and  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-1,CURRENT_TIMESTAMP)and cv.jour = datename(dw,getdate()) and  cast(d.GPSDateTime AS datetime) >=  cast( (convert(varchar,(CONVERT(date,CURRENT_TIMESTAMP,103)),103))+' '+cv.heurD AS datetime) and  cast(d.GPSDateTime AS datetime) <=  cast((convert(varchar,(CONVERT(date,CURRENT_TIMESTAMP,103)),103))+' '+cv.heurF AS datetime) and (ua.alerteid=12 or ua.alerteid=24 or ua.alerteid=36) group by ua.alerteid, v.vehiculeid,v.matricule ,u.utilisateurid ,u.email,u.tel ,cv.jour,cv.heurD,cv.heurF";
                SqlDataReader s = Select(req);
                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 12)
                        {
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[3] + "," + (int)s[1] + "," + (int)s[0] + ",CURRENT_TIMESTAMP,'non','Alarme Conduite non autoriser : la vehicule matriculé  " + (int)s[2] + " roule pendant des horaires non autoriser ')");

                        }

                        if ((int)s[0] == 24)
                        {
                            /// envoi sms 

                        }

                        if ((int)s[0] == 36)
                        {
                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : Conduite non autoriser ", "Alarme Conduite non autoriser : la vehicule matriculé  " + (int)s[2] + " roule pendant des horaires non autoriser ", "alerte_geomtec@geomtec.com");
                        }


                    }


                }
                s.Close();
                if (tab.Count > 0)
                {
                    for (int i = 0; i < tab.Count; i++)
                    {
                        b.Insert(tab[i]);
                    }

                }

            }
            catch (Exception ee) { }


        }
        public void PermisAlarme()
        {

            /*
             *select a.alerteid,c.clientid , p.personnelid,p.nom+' '+p.prenom as conducteur
,p.permis,p.date_expiration , u.utilisateurid,u.email,u.tel
 from user_alerte a
  inner join utilisateur u on u.utilisateurid=a.utilisateurid 
  inner join client c on c.clientid=u.clientid
   inner join personnel p on p.clientid=c.clientid
    where  p.date_expiration < DATEADD(month,1,CURRENT_TIMESTAMP)
    and (a.alerteid=8 or a.alerteid=20 or a.alerteid=32)
          
            // * */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = "select a.alerteid,c.clientid , p.personnelid,p.nom+' '+p.prenom as conducteur,p.permis,p.date_expiration , u.utilisateurid,u.email,u.tel from user_alerte a inner join utilisateur u on u.utilisateurid=a.utilisateurid  inner join client c on c.clientid=u.clientid  inner join personnel p on p.clientid=c.clientid   where  p.date_expiration < DATEADD(month,1,CURRENT_TIMESTAMP)  and (a.alerteid=8 or a.alerteid=20 or a.alerteid=32)";
                SqlDataReader s = Select(req);
                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 8)
                        {
                            // Insert("insert into Notification(utilisateurid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[6] + "," + (int)s[0] + ",CURRENT_TIMESTAMP,'non','le personel nommé : " + s[3].ToString() + " portant le permis  : " + s[4].ToString() + " qui va expire ( le" + s[5].ToString() + ") dans moins d'un mois  ')");
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[6] + ",0," + (int)s[0] + ",CURRENT_TIMESTAMP,'non','le personel nommé : " + s[3].ToString() + " portant le permis  : " + s[4].ToString() + " qui va expire ( le" + s[5].ToString() + ") dans moins d un mois  ')");

                        }

                        if ((int)s[0] == 20)
                        {
                            /// envoi sms 

                        }

                        if ((int)s[0] == 32)
                        {
                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : Expiration du Permis du Personnel ", "le personel nommé : " + s[3].ToString() + " portant le permis  : " + s[4].ToString() + " qui va expire ( le" + s[5].ToString() + ") dans moins d'un mois ", "alerte_geomtec@geomtec.com");
                        }


                    }


                }
                s.Close();
                if (tab.Count > 0)
                {
                    for (int i = 0; i < tab.Count; i++)
                    {
                        b.Insert(tab[i]);
                    }

                }
            }
            catch (Exception ee) { }


        }
        public void kiloAberrant()
        {/*
           select ua.alerteid,u.utilisateurid, v.matricule,v.vehiculeid, d2.Odometer - d1.Odometer  as distance ,vc.kmAberant ,(d2.Odometer -d1.Odometer)/10 as kmReel,u.email,u.tel from ( select imei, min(datatrackerid) idmin, MAX(datatrackerid) idmax from Datatracker d where  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-23,CURRENT_TIMESTAMP) group by imei) aff inner join Datatracker d1  on d1.datatrackerid = aff.idmin inner join Datatracker d2  on d2.datatrackerid = aff.idmax inner join boitier b on b.imei=aff.imei inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  inner join vehicules v on v.vehiculeid=avb.vehiculeid  inner join utilisateur u on u.clientid= v.clientid inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid  inner join user_alerte ua on ua.utilisateurid=u.utilisateurid where  (d2.Odometer - d1.Odometer)/10 > vc.kmAberant and ua.alerteid in (11,23,35)
        
          * */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = "select ua.alerteid,u.utilisateurid, v.matricule,v.vehiculeid, d2.Odometer - d1.Odometer  as distance ,vc.kmAberant ,(d2.Odometer -d1.Odometer)/10 as kmReel,u.email,u.tel from ( select imei, min(datatrackerid) idmin, MAX(datatrackerid) idmax from Datatracker d where  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-23,CURRENT_TIMESTAMP) group by imei) aff inner join Datatracker d1  on d1.datatrackerid = aff.idmin inner join Datatracker d2  on d2.datatrackerid = aff.idmax inner join boitier b on b.imei=aff.imei inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  inner join vehicules v on v.vehiculeid=avb.vehiculeid  inner join utilisateur u on u.clientid= v.clientid inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid  inner join user_alerte ua on ua.utilisateurid=u.utilisateurid where  (d2.Odometer - d1.Odometer)/10 > vc.kmAberant and ua.alerteid in (11,23,35)";
                SqlDataReader s = Select(req);
                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 11)
                        {
                            // Insert("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[1] + "," + (int)s[3] + ",11,CURRENT_TIMESTAMP,'non','Alarme : Kilometrage aberrant : le vehicule matriculé " + s[2].ToString() + " a deppassé son kilometrage prédefini (" + s[5].ToString() + ") on parcourant " + s[6].ToString() + "')");
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[1] + "," + (int)s[3] + ",11,CURRENT_TIMESTAMP,'non','Alarme : Kilometrage aberrant : le vehicule matriculé " + s[2].ToString() + " a deppassé son kilometrage prédefini (" + s[5].ToString() + ") on parcourant " + s[6].ToString() + "')");

                        }

                        if ((int)s[0] == 23)
                        {
                            /// envoi sms 

                        }

                        if ((int)s[0] == 35)
                        {

                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : Kilometrage aberrant  ", "Alarme : Kilometrage aberrant : le vehicule matriculé " + s[2].ToString() + " a deppassé son kilometrage prédefini (" + s[5].ToString() + ") on parcourant " + s[6].ToString(), "alerte_geomtec@geomtec.com");

                        }


                    }


                }
                s.Close();
                if (tab.Count > 0)
                {
                    for (int i = 0; i < tab.Count; i++)
                    {
                        b.Insert(tab[i]);
                    }

                }
            }
            catch (Exception ee) { }


        }
        public void consomationEx()
        {
            /*
             * 
             
  select v.matricule,v.vehiculeid, d2.Odometer - d1.Odometer as distance ,vc.consomationMax, u.utilisateurid  from (
  select imei, min(datatrackerid) idmin, MAX(datatrackerid) idmax from Datatracker d
  where  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-23,CURRENT_TIMESTAMP)
  group by imei) aff
  inner join Datatracker d1  on d1.datatrackerid = aff.idmin
  inner join Datatracker d2  on d2.datatrackerid = aff.idmax
inner join boitier b on b.imei=aff.imei
 inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid 
 inner join vehicules v on v.vehiculeid=avb.vehiculeid 
  inner join utilisateur u on u.clientid= v.clientid
 inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid 
 inner join user_alerte ua on ua.utilisateurid=u.utilisateurid
 
 
  where ((( d2.Odometer - d1.Odometer)/10)/100)*v.consommation > vc.consomationMax and ua.alerteid in (5,17,29)
        
             * */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = " select ua.alerteid,u.utilisateurid, v.matricule,v.vehiculeid, d2.Odometer - d1.Odometer as distance ,vc.consomationMax ,((( d2.Odometer - d1.Odometer)/10)/100)*v.consommation as consReel from (  select imei, min(datatrackerid) idmin, MAX(datatrackerid) idmax from Datatracker d where  cast(d.GPSDateTime AS datetime) >= DATEADD (HH,-229003,CURRENT_TIMESTAMP) group by imei) aff inner join Datatracker d1  on d1.datatrackerid = aff.idmin inner join Datatracker d2  on d2.datatrackerid = aff.idmax inner join boitier b on b.imei=aff.imei inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  inner join vehicules v on v.vehiculeid=avb.vehiculeid   inner join utilisateur u on u.clientid= v.clientid inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid  inner join user_alerte ua on ua.utilisateurid=u.utilisateurid where ((( d2.Odometer - d1.Odometer)/10)/100)*v.consommation > vc.consomationMax  and ua.alerteid in (5,17,29)";
                SqlDataReader s = Select(req);
                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 5)
                        {
                            // Insert("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[1] + "," + (int)s[3] + ",11,CURRENT_TIMESTAMP,'non','Alarme : Kilometrage aberrant : le vehicule matriculé " + s[2].ToString() + " a deppassé son kilometrage prédefini (" + s[5].ToString() + ") on parcourant " + s[6].ToString() + "')");
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[1] + "," + (int)s[3] + ",5,CURRENT_TIMESTAMP,'non','Alarme : consommation excessive  : le vehicule matriculé " + s[2].ToString() + " a deppassé sa consommation prédefini (" + s[5].ToString() + ") et elle a consommé " + s[6].ToString() + "')");

                        }

                        if ((int)s[0] == 17)
                        {
                            /// envoi sms 

                        }

                        if ((int)s[0] == 29)
                        {

                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : consommation excessive   ", "Alarme : consommation excessive  : le vehicule matriculé " + s[2].ToString() + " a deppassé son kilometrage prédefini (" + s[5].ToString() + ") on parcourant " + s[6].ToString(), "alerte_geomtec@geomtec.com");

                        }


                    }


                }
                s.Close();
                if (tab.Count > 0)
                {
                    for (int i = 0; i < tab.Count; i++)
                    {
                        b.Insert(tab[i]);
                    }

                }
            }
            catch (Exception ee) { }

        }
        public void aj()
        {

        }
        public void CompteExpAlarme()
        {
            /*
             select a.alerteid,c.clientid ,c.date_expiration , u.utilisateurid,u.email,u.tel 
from user_alerte a
 inner join utilisateur u on u.utilisateurid=a.utilisateurid 
 inner join client c on c.clientid=u.clientid
  where date_expiration < DATEADD(DAY,15,CURRENT_TIMESTAMP)
  and (a.alerteid=6 or a.alerteid=18  or a.alerteid=30)

             */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = "select a.alerteid,c.clientid ,c.date_expiration , u.utilisateurid,u.email,u.tel from user_alerte a inner join utilisateur u on u.utilisateurid=a.utilisateurid  inner join client c on c.clientid=u.clientid  where date_expiration < DATEADD(DAY,15,CURRENT_TIMESTAMP) and (a.alerteid=6 or a.alerteid=18  or a.alerteid=30)";

                SqlDataReader s = Select(req);
                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 6)
                        {
                            // Insert("insert into Notification(utilisateurid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[3] + ",6,CURRENT_TIMESTAMP,'non','Votre compte sera experier d ici 15 jours veuillez contacter votre fournisseur')");
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[3] + ",0,6,CURRENT_TIMESTAMP,'non','Votre compte sera expiré d ici 15 jours veuillez contacter votre fournisseur')");

                        }

                        if ((int)s[0] == 18)
                        {
                            /// envoi sms                    

                        }

                        if ((int)s[0] == 30)
                        {

                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : Expiration du Compte ", "Votre compte sera expiré  d ici 15 jours veuillez contacter votre fournisseur", "alerte_geomtec@geomtec.com");

                        }


                    }
                    s.Close();
                    if (tab.Count > 0)
                    {
                        for (int i = 0; i < tab.Count; i++)
                        {
                            b.Insert(tab[i]);
                        }

                    }

                }

            }
            catch (Exception ee) { }

        }
        public void DepassementVitesseAlarme()
        {

            /*
             * 
              select *,
(select top 1 latitude from Datatracker 
where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) 
and cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP 
  and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax
order by datatrackerid desc ),

(select top 1 longitude from Datatracker 
where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and
       cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP 
       and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax
order by datatrackerid desc ),
(select top 1 GPSDateTime from Datatracker 
where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and
       cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP 
       and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax
order by datatrackerid desc )
  from (
select ua.alerteid, u.utilisateurid,v.clientid,v.matricule,v.vehiculeid, 
MAX(d.speed) as vmax ,vc.vitesseMax, d.imei from Datatracker d 
 inner join boitier b on b.imei=d.imei 
 inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  
 inner join vehicules v on v.vehiculeid=avb.vehiculeid 
   inner join utilisateur u on u.clientid= v.clientid
    inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid 
    inner join user_alerte ua on ua.utilisateurid = u.utilisateurid 
     where cast(d.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and
       cast(d.GPSDateTime AS datetime) < CURRENT_TIMESTAMP 
       and d.speed >vc.vitesseMax
       and (ua.alerteid = 1 or ua.alerteid=13 or ua.alerteid=25)
       group by 
             u.utilisateurid,v.clientid,v.matricule,v.vehiculeid,vc.vitesseMax, d.imei,ua.alerteid
             
            )aff
             * 
             * */
            try
            {
                Common.PageBase b = new Common.PageBase();
                List<string> tab = new List<string>();
                string req = " select *,(select top 1 latitude from Datatracker where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP   and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax order by datatrackerid desc ),(select top 1 longitude from Datatracker where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and   cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP  and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax order by datatrackerid desc ),(select top 1 GPSDateTime from Datatracker where cast(Datatracker.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and cast(Datatracker.GPSDateTime AS datetime) < CURRENT_TIMESTAMP  and aff.imei = Datatracker.imei and Datatracker.speed = aff.vmax order by datatrackerid desc )from (select ua.alerteid, u.utilisateurid,v.clientid,v.matricule,v.vehiculeid, MAX(d.speed) as vmax ,vc.vitesseMax, d.imei from Datatracker d inner join boitier b on b.imei=d.imei  inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  inner join vehicules v on v.vehiculeid=avb.vehiculeid  inner join utilisateur u on u.clientid= v.clientid inner join vehiculeConf vc on v.vehiculeid=vc.vehiculeid  inner join user_alerte ua on ua.utilisateurid = u.utilisateurid   where cast(d.GPSDateTime AS datetime) >= DATEADD (MINUTE,-10,CURRENT_TIMESTAMP) and cast(d.GPSDateTime AS datetime) < CURRENT_TIMESTAMP    and d.speed >vc.vitesseMax and (ua.alerteid = 1 or ua.alerteid=13 or ua.alerteid=25) group by  u.utilisateurid,v.clientid,v.matricule,v.vehiculeid,vc.vitesseMax, d.imei,ua.alerteid )aff ";

                SqlDataReader s = Select(req);

                if (s.Read())
                {
                    while (s.Read())
                    {
                        if ((int)s[0] == 1)
                        {
                            // Insert("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[2] + "," + (int)s[4] + ",1,CURRENT_TIMESTAMP,'non','la vehicule matriculé " + s[3].ToString() + " (avec un vitesse max de " + s[6].ToString() + ")a fait un depassement de vitesse de " + s[5].ToString() + " a cette date : " + s[10].ToString() + "')");
                            tab.Add("insert into Notification(utilisateurid,vehiculeid,alerteid,DateAlert,Vu,Descriptione)values (" + (int)s[1] + "," + (int)s[4] + ",1,CURRENT_TIMESTAMP,'non','la vehicule matriculé " + s[3].ToString() + " (avec un vitesse max de " + s[6].ToString() + ")a fait un depassement de vitesse de " + s[5].ToString() + " a cette date : " + s[10].ToString() + "')");

                        }

                        if ((int)s[0] == 13)
                        {
                            /// envoi sms 

                        }

                        if ((int)s[0] == 25)
                        {

                            object sender = new object();
                            EventArgs ee = new EventArgs();
                            Bmail(sender, ee, "Alarme : Depassement de vitesse  ", "la vehicule matriculé " + s[3].ToString() + " (avec un vitesse max de " + s[6].ToString() + ")a fait un depassement de vitesse de " + s[5].ToString() + " a cette date : " + s[10].ToString(), "alerte_geomtec@geomtec.com");


                        }

                        s.Close();
                        if (tab.Count > 0)
                        {
                            for (int i = 0; i < tab.Count; i++)
                            {
                                b.Insert(tab[i]);
                            }

                        }
                    }



                }
                else
                {
                 //   System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('pas d'enregistrement')</SCRIPT>");

                }
            }
            catch (Exception ee) { }

        }
        public void heurConduitMaxAlarme()
        {
            try
            {
                List<string> tab = new List<string>();

                string re = " drop table temp_runk select *  into  temp_runk from tts_runk2 "

               + " select case when aff.contact = 0 then 'Arret' else 'depart' end as Etat, "
    + " aff.imei,p.personnelid,vp.vehiculeid ,  convert(float ,aff.odometer - aff2.odometer )/10 as distance,  "
     + "  aff.date as date1 ,aff2.date as date2, aff2.adress as depart ,  "
    + "    aff.adress as arrive, DATEDIFF(minute,  aff2.date,aff.date)  "
    + "     from (select *, ROW_NUMBER() over(order by runk) as n from temp_runk rn) aff "
    + "      left outer join (select *, ROW_NUMBER() over(order by runk) as n from temp_runk rn )aff2  "
      + "    on aff2.imei = aff.imei and aff.n = aff2.n+1   inner join boitier b on b.imei=aff.imei  "
      + "     inner join affectation_vehicule_boitier avb on avb.boitierid=b.boitierid  "
       + "     inner join vehicule_personnel vp on vp.vehiculeid=avb.vehiculeid  "
       + "     inner join personnel p on p.personnelid=vp.personnelid  where aff.date > DATEADD (HOUR,-2,CURRENT_TIMESTAMP)  ";
                SqlDataReader dr = Select(re);
                if (dr.Read())
                {
                    while (dr.Read())
                    {


                        if (dr[0].ToString() == "depart" && dr[9] != null && dr[6].ToString() != "" && (double)dr[4] != null)
                        {
                            if ((int)dr[9] > 0)
                            {

                            }
                        }
                    }
                    dr.Close();
                }
                else
                {
                    dr.Close();
                }
            }
            catch (Exception ee) { }

            
        }

        //Modifier le nombre de module
        protected void SetNomModule(string Currentmodule)
        {
            this.Currentmodule = Currentmodule;
        }
        // Initialisation de la page aprés connexion
        private void Page_PreInit(Object sender, EventArgs e)
        {

            if (!this.IsConnected())
            {
                Response.Redirect("../Login/Login.aspx");
            }

            int _TypeCompte = this.getCurrentUser().getTypeCompte();

            if (_TypeCompte == 1)//Page Master BackOffice
            {
                this.MasterPageFile = "~/PagesMaster/BackOffice.Master";
            }
            else if (_TypeCompte == 2)//Page Master Revendeur
            {
                this.MasterPageFile = "~/PagesMaster/Revendeur.Master";
            }
            else if (_TypeCompte == 3)//Page Master Client
            {
                this.MasterPageFile = "~/PagesMaster/Client.Master";
            }
            else
            {

            }

        }
        // Vérification habilitations 
        protected Boolean GeHabilitationAction(string _action)
        {
            Boolean trouve = false;

            int _TypeCompte = this.getCurrentUser().getTypeCompte();

            if (_TypeCompte == 1)//BackOffice
            {
                trouve = true;
            }
            else if (_TypeCompte == 2)//Revendeur
            {
                trouve = true;

            }
            else if (_TypeCompte == 3)//Client 
            {
                string _option = this.Currentmodule;
                this.ListAction = (List<string>)Session["HabilitationAction"];
                foreach (String Action in this.ListAction)
                {
                    if ((_action + _option).ToLower() == Action.ToLower())
                    {
                        trouve = true;
                        break;
                    }
                }

            }
            else
            {
                trouve = false;

            }

            return trouve;

        }
        //Récupération de la session et application de la langue
        protected override void InitializeCulture()
        {
            if (Session["Culture"] != null)
            {
                string _Culture = Session["Culture"].ToString();
                //  Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_Culture.ToString());
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_Culture.ToString());
            }
            else
            {
                String _Default = CultureInfo.CurrentCulture.Name;
                //  Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_Default.ToString());
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_Default.ToString());
            }
            base.InitializeCulture();
        }

        protected void FillStore(string sql, Store _store)
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _Global.CurrentConnection))
            {

                DataSet ds = new DataSet();
                da.SelectCommand.CommandTimeout = 120;
                da.Fill(ds);
                _store.DataSource = ds.Tables[0];
                _store.DataBind();


            }



        }
        //accès à la base de données
        public SqlDataReader Select(string _Requette)
        {
            SqlDataReader dr;
            try
            {
                SqlConnection cnx = _Global.CurrentConnection;
                SqlCommand cmd = new SqlCommand(_Requette, cnx);
                dr = cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                dr = null;
                ex.ToString();
            }
            return dr;

        }

        public vehicules GetVehByID(string _Requette)
        {
            SqlDataReader dr = Select(_Requette);
            vehicules v = new vehicules();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    v.vehiculeid = (int)dr[0];
                    v.matricule = dr[1].ToString();
                    v.code = dr[2].ToString();
                    v.personnelid = (int)dr[3];
                }

            }
            dr.Close();
            return v;
        }
        //Requette Insert avec retour de l'id 
        public int InsertRetourId(string _Requette)
        {
            int _NewId = -1;
            try
            {
                SqlDataReader resulat = this.Select(_Requette);
                resulat.Read();
                _NewId = int.Parse(resulat[0].ToString());
                resulat.Close();
            }
            catch (Exception ex)
            {
                _NewId = -1;
                ex.ToString();
            }
            return _NewId;
        }
        //Requete Insert
        public int Insert(string _Requette)
        {
            int _NewId = -1;
            try
            {
                SqlConnection cnx = _Global.CurrentConnection;
                SqlCommand cmd = new SqlCommand(_Requette, cnx);
                _NewId = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _NewId = -1;
                ex.ToString();
            }
            return _NewId;
        }
        //Requete Update
        public int Update(string _Requette)
        {
            int _UpdateId = -1;
            try
            {
                SqlConnection cnx = _Global.CurrentConnection;
                SqlCommand cmd = new SqlCommand(_Requette, cnx);
                _UpdateId = cmd.ExecuteNonQuery();
                if (_UpdateId == 0) { _UpdateId = -1; }
            }
            catch (Exception ex)
            {
                _UpdateId = -1;
                ex.ToString();
            }
            return _UpdateId;
        }
        //Récuperation de l'utilisateur courant
        public UserInfo getCurrentUser()
        {

            UserInfo retVal = null;
            object o = Session["UserInfo"];
            if (o != null)
            {
                retVal = ((UserInfo)Session["UserInfo"]);
            }
            return retVal;


        }
        //Modification de l'utilisateur courant
        public void setCurrentUser(UserInfo _UserInfo)
        {

            Session["UserInfo"] = _UserInfo;


        }
        //Vérification de la connexion
        public Boolean IsConnected()
        {
            if (Session["UserInfo"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }



        }

        public void Bmail(object sender, EventArgs e, string sub, string bod, string em)
        {
            var fromAddress = new MailAddress("alerte.geomtec@gmail.com", "Geomtec");
            // var toAddress = new MailAddress("hrifechabdelouahid@gmail.com", "lia");



            const string fromPassword = "geomtec2014";
            string subject = sub;
            string body = bod;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage() { Subject = subject, Body = body })
            {
                message.From = fromAddress;
                message.To.Add("hrifechabdelouahid@gmail.com");
                message.To.Add(em);
                //  message.CC.Add("lahjouji_abderrahman@hotmail.com");

                //   message.Bcc.Add("zaio.info@gmail.com");
                smtp.Send(message);
            }
        }




        //--------------------- Fin ------------------------------
        #endregion

        #region Methodes
        //--------------------- Début ----------------------------        
        protected string Hash(string Password)
        {
            string chaine = "";
            string reformulation = "asm" + Password + "tda";
            string hashOfInput = FormsAuthentication.HashPasswordForStoringInConfigFile(reformulation, "MD5");
            string chaine1 = hashOfInput.Substring(0, 12);
            string chaine2 = hashOfInput.Substring(0, 13);
            string chaine3 = hashOfInput.Substring(0, 7);
            chaine = chaine3 + chaine1 + chaine2;
            return chaine;
        }




        public void DoNo()
        { }

        //--------------------- Fin ------------------------------
        #endregion
    }
}