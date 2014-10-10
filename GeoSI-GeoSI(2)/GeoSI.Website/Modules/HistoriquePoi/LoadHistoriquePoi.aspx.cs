﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using Ext.Net;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

using System.Globalization;
namespace GeoSI.Website.Modules.HistoriquePoi
{
    public partial class LoadHistoriquePoi : Page
    {
        public String adress = "";

        //Recuperation de la session user
        protected UserInfo getCurrentUser()
        {

            UserInfo retVal = null;
            object o = Session["UserInfo"];
            if (o != null)
            {
                retVal = new UserInfo();
                retVal = ((UserInfo)Session["UserInfo"]);
            }
            return retVal;


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
        // Accès à la base de Données 
        protected SqlDataReader Select(string _Requette)
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
        private string racine = null;

        //Chergement de la page 
        protected void Page_Load(object sender, EventArgs e)
        {

            string _reqVeh = "select * from (select aff.* from ( select  v.matricule ,v.vehiculeid from vehicules v  inner join affectation_vehicule_boitier abv on abv.vehiculeid=v.vehiculeid  inner join boitier b on b.boitierid=abv.boitierid inner join Datatracker d on d.imei=b.imei  inner join groupe_vehicule gv on gv.vehiculeid = v.vehiculeid and gv.actif = '1' where v.clientid =" + this.getCurrentUser().getClientId() + " and v.actif = '1' )aff union select v.matricule, v.vehiculeid from vehicules v  inner join affectation_vehicule_boitier abv on abv.vehiculeid=v.vehiculeid  inner join boitier b on b.boitierid=abv.boitierid inner join Datatracker d on d.imei=b.imei  inner join profil_vehicule gp on gp.vehiculeid =v.vehiculeid and gp.actif = '1' inner join profil p on p.profilid = gp.profilid and p.actif = '1' inner join profil_user pu on pu.actif = '1' and pu.profilid = p.profilid where v.clientid = " + this.getCurrentUser().getClientId() + " and v.actif = '1' and pu.utilisateurid =" + this.getCurrentUser().getUserId() + " ) aff2      ";
            this.FillStore(_reqVeh, Store2);
            // txt1.Text = RetrieveFormatedAddress("33.5992364201655", "-7.570799214941417");

        }





        List<Pois> Listpoi =new List<Pois>();
        List<Pois> ListpoiAff=new List<Pois>();


        [DirectMethod(ShowMask = true, Msg = "Veuillez patienter, traitement en cours...")]
        protected void HistoriquePoi(object sender, EventArgs e)
        {
            
           

            string userDate1 = this.DateField1.Value.ToString();
            string[] du = userDate1.Split(' ');
            userDate1 = du[0] + " " + this.TimeField1.Value.ToString();

            string userDate2 = this.DateField2.Value.ToString();
            string[] du2 = userDate2.Split(' ');
            userDate2 = du2[0] + " " + this.TimeField2.Value.ToString();
            string vehiculeid = "";
            vehiculeid = this.MultiCombo1.SelectedItem.Value;
            if (vehiculeid == "" || userDate1 == "" || userDate2 == "")

                X.Msg.Show(new MessageBoxConfig
                {
                    Title = Resources.Resource.Information,
                    Message = "Veuillez choisir un véhicule, une date début et une date fin pour consulter les trajets",
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
            else
            {
                TimeSpan k = DateTime.ParseExact(userDate2, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture) - DateTime.ParseExact(userDate1, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                if (k.TotalDays <= 0)
                {
                    X.Msg.Show(new MessageBoxConfig
                    {
                        Title = Resources.Resource.Information,
                        Message = "La date  début doit être inferieure à la date fin",
                        Buttons = MessageBox.Button.OK,
                        Icon = MessageBox.Icon.INFO
                    });
                }
                else
                {
                    string _reqTime = "select * from(select top 1 d.RTCDateTime from Datatracker d order by d.datatrackerid desc) a union select * from (select top 1 d.RTCDateTime from Datatracker d order by d.datatrackerid )b ";
                    SqlDataReader drT = Select(_reqTime);

                    int m = 0;
                    while (drT.Read())
                    {
                        du[m] = drT[0].ToString();
                        m++;
                    }
                    drT.Close();
                    DateTime dsup = DateTime.ParseExact(du[1], "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime dinf = DateTime.ParseExact(du[0], "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    if (dsup < dinf)
                    {
                        dinf = DateTime.ParseExact(du[1], "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        dsup = DateTime.ParseExact(du[0], "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    }


                    if (DateTime.ParseExact(userDate1, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture) < dinf
                           || DateTime.ParseExact(userDate1, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture) > dsup
                                || DateTime.ParseExact(userDate2, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture) < dinf
                                    || DateTime.ParseExact(userDate2, "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture) > dsup)
                    {
                        X.Msg.Show(new MessageBoxConfig
                        {
                            Title = Resources.Resource.Information,
                            Message = "Les dates début et fin doivent être comprises entre " + dinf + " et " + dsup,
                            Buttons = MessageBox.Button.OK,
                            Icon = MessageBox.Icon.INFO
                        });

                    }
                    else
                    {
                        int Compt = 0;
                        int vites = 0;
                        string c = "";
                        string _reqlist = "select * from "
                     + " (select p.libelle as poi, p.type_poi ,p.longitude as lng ,p.latitude as lat,GPSDateTime as date,"
                     + " per.prenom+' '+per.nom as conducteur,"
                     + " geography::STGeomFromText('POINT('+convert(varchar(20),p.longitude)+' '+convert(varchar(20),p.latitude)+')',4326).STBuffer(p.tolerance).STIntersects "
                     + " (geography::STGeomFromText('POINT('+convert(varchar(20),d.longitude)+' '+convert(varchar(20),d.latitude)+')',4326).STBuffer(10)) as inter"
                      + " from Poi p  CROSS JOIN Datatracker  d "
                     + "  inner join boitier b on b.imei=d.imei "
                     + "  inner join affectation_vehicule_boitier abv on abv.boitierid=b.boitierid"
                     + "  inner join vehicules  v on v.vehiculeid = abv.vehiculeid "
                     + "  inner join vehicule_personnel vp on vp.vehiculeid=v.vehiculeid"
                     + "  inner join personnel per on per.personnelid=vp.personnelid"
                      + " where  cast(d.GPSDateTime AS datetime) >= '" + userDate1 + "' "
                      + " AND cast(d.GPSDateTime AS datetime) < '" + userDate2 + "'and v.vehiculeid='" + vehiculeid + "'"
                     + " and p.actif='1' and p.clientid='" + this.getCurrentUser().getClientId() + "' and p.userid ='" + this.getCurrentUser().getUserId() + "'  and d.speed=0) aff where aff.inter=1   ";

                        SqlDataReader drlist = Select(_reqlist);


                        while (drlist.Read())
                        {

                            Pois t = new Pois();
                            t.nom = drlist[0].ToString();
                            t.lat = drlist[3].ToString();
                            t.lng = drlist[2].ToString();
                            t.type = drlist[1].ToString();
                            t.cond = drlist[5].ToString();
                            t.dateD = drlist[4].ToString();
                            Listpoi.Add(t);

                        }

                        drlist.Close();

                        for (int i = 0; i < Listpoi.Count - 1; i++)
                        {

                            Pois p = new Pois();
                            p.dateD = Listpoi[i].dateD;
                            int j;
                            for (j = i; j < Listpoi.Count - 1 && Listpoi[j].lat == Listpoi[j + 1].lat && Listpoi[j].lng == Listpoi[j + 1].lng; j++)
                                ;
                            i = j;
                            p.dateF = Listpoi[i].dateD;
                            if (i == Listpoi.Count - 1)
                                p.dateF = Listpoi[i].dateD;

                            p.nom = Listpoi[i].nom;
                            p.lat = Listpoi[i].lat;
                            p.lng = Listpoi[i].lng;
                            p.type = Listpoi[i].type;
                            p.cond = Listpoi[i].cond;
                            DateTime d = DateTime.ParseExact(p.dateD.ToString(), "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            DateTime dd = DateTime.ParseExact(p.dateF.ToString(), "dd'/'MM'/'yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                            TimeSpan duree = dd - d;
                            p.duree = duree.ToString();
                            ListpoiAff.Add(p);

                        }


                        List<object> lo = new List<object>();
                        if (ListpoiAff.Count == 0)
                        {
                            X.Msg.Show(new MessageBoxConfig
                            {
                                Title = Resources.Resource.Information,
                                Message = "Aucun trajet n'a été parcouru",
                                Buttons = MessageBox.Button.OK,
                                Icon = MessageBox.Icon.INFO
                            });


                        }
                        else
                        {
                            Store1.RemoveAll();

                            for (int i = 0; i < ListpoiAff.Count; i++)
                            {

                                object[] test = new object[9];
                                test[0] = ListpoiAff[i].cond;
                                test[1] = ListpoiAff[i].nom;
                                test[2] = ListpoiAff[i].type;
                                test[3] = ListpoiAff[i].dateD;
                                test[4] =ListpoiAff[i].dateF;
                                test[5] = ListpoiAff[i].duree;
                                test[6] = ListpoiAff[i].lat;
                                test[7] = ListpoiAff[i].lng;

                                //{ c, "adrD", Listtrajet[i].position[0].GPSDateTime, "adrF", Listtrajet[i].position[Listtrajet[i].position.Count - 1].GPSDateTime, duree.ToString(), Listtrajet[i].vitesse + " Km/H", polyline, color[col], Listtrajet[i].km + " Km" };
                                lo.Add(test);
                    //            lo.Add(new object[] { ListpoiAff[i].cond, ListpoiAff[i].nom,ListpoiAff[i].type, ListpoiAff[i].dateD, ListpoiAff[i].dateF, ListpoiAff[i].duree, ListpoiAff[i].lat, ListpoiAff[i].lng }
                    //);



                            }


                            Store1.Add(lo);
                            Store1.CommitChanges();

                        }
                    }
                }
            }
        }

    }
}
