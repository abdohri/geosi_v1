using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections.Generic;
using System.IO;
using System.Xml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using GeoSI.Website.Common;


namespace GeoSI.Website.Modules.RapportArret
{
    public partial class RAZxcel : Form
    {
        String _idv;
        protected void Page_Load(object sender, EventArgs e)
        {
            _idv = Request.Params.Get("id").ToString();


        }
        protected void Gen(object sender, EventArgs e)
        {
            string _dateDebut = this.startdate.Text.ToString();
            string _dateFin = this.enddate.Text.ToString();
            string _id = _idv;

            string _req = "select v.matricule, p.nom+' '+p.prenom ,ha.localiisation ,  ha.date as Date_Debut,DATEADD(MINUTE,ha.duree,ha.date) as dete_fin, ha.duree from  Historique_Arret ha "

+ " inner join personnel p on p.personnelid=ha.personnelid"
+ " inner join vehicules v on v.vehiculeid=ha.vehiculeid "
+ " where cast(ha.date AS datetime) >='" + _dateDebut + "'  and  cast(ha.date AS datetime) <= '" + _dateFin + "' and ha.vehiculeid='" + _idv + "'";
        
            DataTable dt = GetData(_req);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "Rapport";
                dt.WriteXml(Server.MapPath(".") + @"\RapportArret.xls", XmlWriteMode.IgnoreSchema);
                Response.Redirect("RapportArret.xls");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Aucun Rapport trouver dans cette periode ! ')</SCRIPT>");

            }
        }

        private DataTable GetData(string query)
        {



            ///////////////////////////////////////////////////////////////////

            string conString = ConfigurationManager.ConnectionStrings["SQLConnString"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            SqlConnection con = new SqlConnection(conString);

            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();



            sda.Fill(dt);
            //DataColumn dc = new DataColumn();

            //dt.Columns.Add(dc);


            //  dt.Columns.Add("adress", typeof(string));


            foreach (DataRow dr in dt.Rows)
            {

                //float a = (float)dr["longitude"];

                //dr["adress"] = test(dr["longitude"].ToString());

                //string lat =dr["latitude"].ToString();
                //string longi = dr["longitude"].ToString();
                //string adr = RetrieveFormatedAddress(longi, lat);
                //  dr["adress"] = "1";
                //
            }

            //dt.Columns.RemoveAt(4);
            //dt.Columns.RemoveAt(5);



            return dt;


        }

    }
}