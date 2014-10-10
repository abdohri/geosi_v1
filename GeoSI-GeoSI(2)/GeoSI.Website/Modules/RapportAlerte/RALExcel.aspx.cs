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


namespace GeoSI.Website.Modules.RapportAlerte
{
    public partial class RALExcel : Form
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
           
            string req1 = "select aff.matricule,aff.DateAlert,aff.titre,aff.Descriptione from( "
+ " select v.matricule ,n.DateAlert,a.titre,n.Descriptione ,	ROW_NUMBER()OVER (partition BY n.DateAlert order by n.DateAlert) as numero "
+ " from  Notification n "
+ "   inner join alerte a on a.alerteid=n.alerteid "
+ "  inner join vehicules v on v.vehiculeid=n.vehiculeid "
+ "  inner join user_alerte ua on ua.utilisateurid=n.utilisateurid where"
+ "  n.utilisateurid='" + this.getCurrentUser().getUserId() + "' and n.vehiculeid='" + _idv + "'  "
+ "   and cast(n.DateAlert AS datetime) >= '" + _dateDebut + "'"
+ "   and  cast(n.DateAlert AS datetime) <= '" + _dateFin + "' )aff where aff.numero=1 ";
            DataTable dt = GetData(req1);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "Rapport";
                dt.WriteXml(Server.MapPath(".") + @"\RapportAlerte.xls", XmlWriteMode.IgnoreSchema);
                Response.Redirect("RapportAlerte.xls");
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