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

namespace GeoSI.Website.Modules.RapportTrajet
{
    public partial class RTpdf : Form
    {
        String _idv;
        protected void Page_Load(object sender, EventArgs e)
        {
            _idv = Request.Params.Get("id").ToString();
            //startdate.Text = DateTime.Now.ToShortDateString();
            //enddate.Text = DateTime.Now.ToShortDateString();
        }
        public void DoPdf(object sender, EventArgs e)
        {
            string _dateDebut = this.startdate.Text.ToString();
            string _dateFin = this.enddate.Text.ToString();
            string _id = _idv;
            ////string _contact = "L'Etat du moteur";
            ////string _speed = "Vitesse";

            string repp = "select v.matricule, p.nom+' '+p.prenom as name,ht.adr_depart,"
+ " ht.date_depart,ht.adr_fin,ht.date_fin,ht.duree,"
+ " ht.vitesse,ht.distance,v.consommation,( ht.distance*v.consommation)/100 as conso"
 + " from Historique_Trajet ht "
+ " inner join vehicule_personnel vp on vp.vehiculeid=ht.vehiculeid  and vp.actif=1"
+ " inner join personnel p on p.personnelid=vp.personnelid"
+ " inner join vehicules v on v.vehiculeid=ht.vehiculeid"
+ " where v.vehiculeid in"
   + "  (select pv.vehiculeid from profil_vehicule pv  "
  + " inner join profil_user pu on  pu.profilid=pv.profilid and    pu.utilisateurid='2' and pu.actif='1'"
    + " where pv.actif='1'   group by pv.vehiculeid"
     + " union  "
     + " select gv.vehiculeid from groupe_vehicule gv "
      + " inner join Groupe_Profil gp on gp.groupeid=gv.groupeid and gp.actif='1'"
       + " inner join profil_user pu on  pu.profilid=gp.profilid  and    pu.utilisateurid='2' and pu.actif='1'"
         + " where gv.actif='1'  ) and "
         + " cast(ht.date_depart AS datetime) >='" + _dateDebut + "'"
         + " and  cast(ht.date_depart AS datetime) <= '" + _dateFin + "'"
  + " and v.vehiculeid='" + _idv + "' ";
            DataTable dat = GetData(repp);
            if (dat.Rows.Count > 0)
            {
                DataRow dr = dat.Rows[0];
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                {
                    float[] widths = new float[] { 5f, 5f, 6f, 6f, 6f, 6f, 4f, 4f, 4f, 11f, 6f };
                    iTextSharp.text.Font font5 = FontFactory.GetFont("Arial", 7);
                    iTextSharp.text.Font font6 = FontFactory.GetFont("Arial", 9);

                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    Phrase phrase = null;
                    PdfPCell cell = null;
                    PdfPTable table = null;
                    PdfPTable table2 = null;
                    Color color = null;

                    document.Open();

                    table = new PdfPTable(2);
                    table.TotalWidth = 800f;
                    table.LockedWidth = true;
                    table.SetWidths(new float[] { 0.4f, 0.6f });
                    double somkm = 0;
                    double tpm = 0;
                    double vts = 0;
                    int idt = 0;
                    foreach (DataRow row in dat.Rows)
                    {
                        somkm += (double)row["distance"];
                        tpm += (double)row["duree"];
                        vts += (double)row["vitesse"];
                        idt++;

                    }


                    //Company Logo
                    cell = ImageCell("~/Ressources/Images/logo.png", 70f, PdfPCell.ALIGN_CENTER);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    phrase.Add(new Chunk("Rapport  des  trajets \n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.GRAY)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Reference vehicule :" + _idv, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    phrase.Add(new Chunk("De : " + startdate.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("A  : " + enddate.Text, FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Kilometrage : " + somkm + " KM", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    TimeSpan tm = TimeSpan.FromMinutes(tpm);
                    phrase.Add(new Chunk("Temps en marche : " + tm + " (J.hh:mm:ss) ", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    //DateTime d1 = DateTime.ParseExact(startdate.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    //DateTime d2 = DateTime.ParseExact(enddate.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                    //TimeSpan ts = d2 - d1;
                    //TimeSpan th = TimeSpan.FromHours(24);
                    //TimeSpan def = th - tm;

                    //phrase.Add(new Chunk("Temps en arret : " + def + " (J.hh:mm:ss )", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    //phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    //phrase.Add(new Chunk("Vitesse moyenne : " + (int)vts / idt + " Km/h", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    //phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                    phrase.Add(new Chunk("\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    table.AddCell(cell);

                    color = new Color(System.Drawing.ColorTranslator.FromHtml("#A9A9A9"));
                    DrawLine(writer, 25f, document.Top - 150f, document.PageSize.Width - 25f, document.Top - 150f, color);
                    DrawLine(writer, 25f, document.Top - 150f, document.PageSize.Width - 25f, document.Top - 150f, color);


                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    cell = PhraseCell(phrase, PdfPCell.ALIGN_LEFT);
                    cell.VerticalAlignment = PdfCell.ALIGN_TOP;
                    table.AddCell(cell);



                    document.Add(table);



                    //Separater Line
                    table2 = new PdfPTable(dat.Columns.Count);
                    table2.TotalWidth = 500f;
                    table2.LockedWidth = true;
                    table2.WidthPercentage = 100;
                    table2.SetWidths(widths);


                    //table2.SetWidths(new float[] { 0.4f, 0.6f });


                    for (int j = 0; j < dat.Columns.Count; j++)
                    {
                        table2.AddCell(new Phrase(dat.Columns[j].ColumnName, font6));
                    }

                    table2.HeaderRows = 1;


                    for (int i = 0; i < dat.Rows.Count; i++)
                    {

                        for (int k = 0; k < dat.Columns.Count; k++)
                        {

                            if (dat.Rows[i][k] != null)
                            {
                                table2.AddCell(new Phrase(dat.Rows[i][k].ToString(), font5));
                            }
                        }

                    }

                    string msg1 = "brrrrrr";
                    document.Add(table2);
                    document.Close();
                    byte[] bytes = memoryStream.ToArray();
                    memoryStream.Close();
                    Response.Clear();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment; filename=Rapport" + DateTime.Now.Ticks + ".pdf");
                    Response.Write(msg1);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();

                }



            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Aucun Rapport trouver dans cette periode ! ')</SCRIPT>");

            }


        }
        private static void DrawLine(PdfWriter writer, float x1, float y1, float x2, float y2, Color color)
        {
            PdfContentByte contentByte = writer.DirectContent;
            contentByte.SetColorStroke(color);
            contentByte.MoveTo(x1, y1);
            contentByte.LineTo(x2, y2);
            contentByte.Stroke();
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
        private static PdfPCell PhraseCell(Phrase phrase, int align)
        {
            PdfPCell cell = new PdfPCell(phrase);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 2f;
            cell.PaddingTop = 0f;
            return cell;
        }
        private static PdfPCell ImageCell(string path, float scale, int align)
        {
            iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath(path));
            image.ScalePercent(scale);
            PdfPCell cell = new PdfPCell(image);
            cell.BorderColor = Color.WHITE;
            cell.VerticalAlignment = PdfCell.ALIGN_TOP;
            cell.HorizontalAlignment = align;
            cell.PaddingBottom = 0f;
            cell.PaddingTop = 0f;
            return cell;
        }

    }
}