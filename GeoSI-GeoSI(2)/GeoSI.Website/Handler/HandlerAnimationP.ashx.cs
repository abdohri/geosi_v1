using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Ext.Net;
using GeoSI.Website.Common;

namespace GeoSI.Website.Handler
{
    /// <summary>
    /// Description résumée de HandlerAnimationP
    /// </summary>
    public class HandlerAnimationP : IHttpHandler
    {
        // Remplissage du DATASET
        protected DataSet json_encode(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _Global.CurrentConnection))
            {

                da.SelectCommand.CommandTimeout = 120;
                da.Fill(ds);
            }


            return ds;


        }
        //Accès à la base de données
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
        //Récuération des donées du traje
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            //long _Unitid = long.Parse(context.Request.Form["Unitid"]);
            //string _req1 = "select top 1 CONVERT(VARCHAR(10), GPSDateTime, 103) date, DATENAME(hh,GPSDateTime)+':'+ DATENAME(mi,GPSDateTime)+':'+ DATENAME(SS,GPSDateTime) time,d.latitude,d.longitude,d.speed,d.contact,v.matricule,v.code from datatracker d,boitier b,vehicules v,affectation_vehicule_boitier avb where d.imei=999999 and b.imei=d.imei and b.boitierid=avb.boitierid and avb.vehiculeid=v.vehiculeid order by GPSDateTime desc ";
            int _id = int.Parse(context.Request.Form["id"]);
            string _dateD = (context.Request.Form["dateD"]).ToString();
            string _dateF = (context.Request.Form["dateF"]).ToString();
            string _req1 = "select CONVERT(VARCHAR(10), GPSDateTime, 103) date, DATENAME(hh,GPSDateTime)+':'+ DATENAME(mi,GPSDateTime)+':'+ DATENAME(SS,GPSDateTime) time,d.latitude,d.longitude,d.speed,d.contact,v.matricule,v.typevehiculeid,v.code,p.nom,p.prenom,p.permis,v.imgVehicule,d.signialGPS from datatracker d,boitier b,vehicules v,affectation_vehicule_boitier avb, personnel p,vehicule_personnel vp where   vp.vehiculeid=v.vehiculeid  and vp.personnelid=p.personnelid and  b.imei=d.imei and b.boitierid=avb.boitierid and avb.vehiculeid=v.vehiculeid and v.vehiculeid ='" + _id + "' and cast(d.GPSDateTime AS datetime) >= '" + _dateD + "' AND cast(d.GPSDateTime AS datetime) <'" + _dateF + "'";

            context.Response.Write(JSON.Serialize(this.json_encode(_req1).Tables[0]));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}