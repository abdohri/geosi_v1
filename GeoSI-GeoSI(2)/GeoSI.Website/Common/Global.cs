using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace GeoSI.Website.Common
{
    public static class _Global
    {
        public static SqlConnection cnx = new SqlConnection(_Global.CurrentConnectionString);
        //Récuperation de la chaine de connexion courante 
        private static string CurrentConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
            }
        }

        //Récuperation de la chaine de connexion
        public static SqlConnection CurrentConnection
        {
            get
            {
                
                if (cnx.State.ToString() == "Open")
                {
                    return cnx;
                }
                else
                {
                    cnx = new SqlConnection(_Global.CurrentConnectionString);
                    cnx.Open();
                    return cnx;
                }
            }

        }

    }
}