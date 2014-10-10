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
    /// Summary description for vehiculeProche
    /// </summary>
    public class vehiculeProche : IHttpHandler
    {
        // Remplissage du DATASET
        protected DataSet json_encode(string sql)
        {
            DataSet ds = new DataSet();
            using (SqlDataAdapter da = new SqlDataAdapter(sql, _Global.CurrentConnection))
            {
                try
                {

                    da.SelectCommand.CommandTimeout = 120;
                    da.Fill(ds);
                }
                catch (Exception ex) { }
                finally { da.Dispose(); }
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
        //Récuération des donées du trajet 
        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "application/json";
            string _latitude = context.Request.Form["lat"].ToString();
            string _longitude = context.Request.Form["longitude"].ToString();
            string rayon = context.Request.Form["raduis"].ToString();

            String re = "select * from (select *, GEOGRAPHY::STPointFromText('POINT(' + CAST([longitude] AS VARCHAR(20))+ ' ' + CAST([latitude] AS VARCHAR(20)) + ')', 4326).STDistance(GEOGRAPHY::STGeomFromText('POINT(" + _longitude + " " + _latitude + ")', 4326))as distance from (select v.matricule, v.vehiculeid,v.typevehiculeid, b.imei,(select top 1 latitude from Datatracker d where d.imei = b.imei order by datatrackerid desc) as latitude,(select top 1 SendingDateTime from Datatracker d where d.imei = b.imei order by datatrackerid desc) as SendingDateTime,(select top 1 longitude from Datatracker d where d.imei = b.imei order by datatrackerid desc)  as longitude from vehicules v inner join affectation_vehicule_boitier vb on vb.vehiculeid = v.vehiculeid and vb.actif =1 inner join boitier b on b.boitierid = vb.boitierid and b.actif = 1 ) aff ) aff2 where (latitude !=0 and longitude!=0 and distance <=" + rayon + ") order by distance asc";
            context.Response.Write(JSON.Serialize(this.json_encode(re).Tables[0]));
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