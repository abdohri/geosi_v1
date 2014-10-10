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
namespace GeoSI.Website.Modules.RapportJour
{
    public partial class RJExcel : Form
    {
        String _idv;
        protected void Page_Load(object sender, EventArgs e)
        {
            _idv = Request.Params.Get("id").ToString();
            startdate.Text = DateTime.Now.ToShortDateString();
            enddate.Text = DateTime.Now.ToShortDateString();

        }
        protected void Gen(object sender, EventArgs e)
        {
            //string _dateDebut = this.DateField1.Text.ToString();
            //string _dateFin = this.DateField2.Text.ToString();
            //string _id = this.vehiculeid.Text.ToString();
            string _dateDebut = this.startdate.Text.ToString();
            string _dateFin = this.enddate.Text.ToString();
            string _id = _idv;
            ////string _contact = "L'Etat du moteur";
            ////string _speed = "Vitesse";

            string _req = "select v.matricule, p.nom+' '+p.prenom as name,ht.adr_depart,"
 + "ht.date_depart,ht.adr_fin,ht.date_fin,ht.duree,"
+ " ht.vitesse,ht.distance,  cast(ht.date_depart AS date)"
+ " from Historique_Trajet ht "
+ " inner join vehicule_personnel vp on vp.vehiculeid=ht.vehiculeid  and vp.actif=1 "
+ " inner join personnel p on p.personnelid=vp.personnelid "
+ " inner join vehicules v on v.vehiculeid=ht.vehiculeid "


+ " where v.vehiculeid in "
 + "    (select pv.vehiculeid from profil_vehicule pv  "
 + "  inner join profil_user pu on  pu.profilid=pv.profilid and    pu.utilisateurid='" + this.getCurrentUser().getUserId() + "' and pu.actif='1' "
     + "    where pv.actif='1'   group by pv.vehiculeid  "
     + "     union  "
      + "    select gv.vehiculeid from groupe_vehicule gv "
      + "     inner join Groupe_Profil gp on gp.groupeid=gv.groupeid and gp.actif='1'"
      + "      inner join profil_user pu on  pu.profilid=gp.profilid  and    pu.utilisateurid='" + this.getCurrentUser().getUserId() + "' and pu.actif='1'"
       + "       where gv.actif='1'  ) and "
       + "       cast(ht.date_depart AS date) = CAST ( CONVERT (date, GETDATE()) as date)"

     + "  and v.vehiculeid='" + _idv + "' ";
            DataTable dt = GetData(_req);
            if (dt.Rows.Count > 0)
            {
                dt.TableName = "Rapport";
                dt.WriteXml(Server.MapPath(".") + @"\RapportJournalier.xls", XmlWriteMode.IgnoreSchema);
                Response.Redirect("RapportJournalier.xls");
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