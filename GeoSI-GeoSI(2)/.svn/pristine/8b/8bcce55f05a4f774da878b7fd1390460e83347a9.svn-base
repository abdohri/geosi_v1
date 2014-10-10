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
    /// Description résumée de GetterPositionTrajet
    /// </summary>
    
    public class GetterPositionTrajet : IHttpHandler
    {   // Remplissage du DATASET
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
        //Récuération des donées d'une posiition du trajet 
        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "application/json";
            long _Unitid = long.Parse(context.Request.Form["Unitid"]);
            string _Time = context.Request.Form["dateTime"].Replace("/", "-");

            string _req1 = "select CONVERT(VARCHAR(10), GPSDateTime, 103) date, DATENAME(hh,GPSDateTime)+':'+ DATENAME(mi,GPSDateTime)+':'+ DATENAME(SS,GPSDateTime) time,d.latitude,d.longitude,d.speed,d.contact,v.matricule,v.code from datatracker d,boitier b,vehicules v,affectation_vehicule_boitier avb where d.imei=999999 and b.imei=d.imei and b.boitierid=avb.boitierid and avb.vehiculeid=v.vehiculeid order by GPSDateTime desc ";

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