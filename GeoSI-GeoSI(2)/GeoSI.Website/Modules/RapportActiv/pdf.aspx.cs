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

namespace GeoSI.Website.Modules.RapportActiv
{
    public partial class pdf : Form
    {
      //  string _connStr = ConfigurationManager.ConnectionStrings["ConnStr"].ConnectionString;
        int _startRowIndex = 0;
        int _pageSize = 400;
        int _thisPage = 1;
        String _idv;
        protected void Page_Load(object sender, EventArgs e)
        {
            
                    BindMyGrid();
                   _idv = Request.Params.Get("id").ToString();

                   hd.Items.Add("00:00"); hd.Items.Add("01:00"); hd.Items.Add("02:00"); hd.Items.Add("03:00");
                   hd.Items.Add("04:00"); hd.Items.Add("05:00"); hd.Items.Add("06:00"); hd.Items.Add("07:00");
                   hd.Items.Add("08:00"); hd.Items.Add("09:00"); hd.Items.Add("10:00"); hd.Items.Add("11:00");
                   hd.Items.Add("12:00"); hd.Items.Add("13:00"); hd.Items.Add("14:00"); hd.Items.Add("15:00");
                   hd.Items.Add("16:00"); hd.Items.Add("17:00"); hd.Items.Add("18:00"); hd.Items.Add("19:00");
                   hd.Items.Add("20:00"); hd.Items.Add("21:00"); hd.Items.Add("22:00"); hd.Items.Add("23:00");

                   hf.Items.Add("00:00"); hf.Items.Add("01:00"); hf.Items.Add("02:00"); hf.Items.Add("03:00");
                   hf.Items.Add("04:00"); hf.Items.Add("05:00"); hf.Items.Add("06:00"); hf.Items.Add("07:00");
                   hf.Items.Add("08:00"); hf.Items.Add("09:00"); hf.Items.Add("10:00"); hf.Items.Add("11:00");
                   hf.Items.Add("12:00"); hf.Items.Add("13:00"); hf.Items.Add("14:00"); hf.Items.Add("15:00");
                   hf.Items.Add("16:00"); hf.Items.Add("17:00"); hf.Items.Add("18:00"); hf.Items.Add("19:00");
                   hf.Items.Add("20:00"); hf.Items.Add("21:00"); hf.Items.Add("22:00"); hf.Items.Add("23:00");
            
        }
        public void pdf_g(object sender, EventArgs e)
        {

            PageBase pp = new PageBase();
            SqlDataReader dd = pp.Select(@"select v.matricule, p.nom+' '+p.prenom as name,ht.adr_depart,
ht.date_depart,ht.adr_fin,ht.date_fin,ht.duree,
ht.vitesse,ht.distance,a.titre+' : '+(cast( nt.Descriptione as nvarchar(max)))   as deescription
 from Historique_Trajet ht 
inner join vehicule_personnel vp on vp.vehiculeid=ht.vehiculeid  and vp.actif=1
inner join personnel p on p.personnelid=vp.personnelid
inner join vehicules v on v.vehiculeid=ht.vehiculeid 
inner join Notification nt on nt.vehiculeid=v.vehiculeid
inner join alerte a on a.alerteid=nt.alerteid
where v.vehiculeid in
    (select pv.vehiculeid from profil_vehicule pv  
  inner join profil_user pu on  pu.profilid=pv.profilid and    pu.utilisateurid='2' and pu.actif='1' 
    where pv.actif='1'   group by pv.vehiculeid  
     union  
     select gv.vehiculeid from groupe_vehicule gv 
      inner join Groupe_Profil gp on gp.groupeid=gv.groupeid and gp.actif='1'
       inner join profil_user pu on  pu.profilid=gp.profilid  and    pu.utilisateurid='2' and pu.actif='1'
         where gv.actif='1'  ) and cast(ht.date_depart AS datetime) >= '22/07/2014 08:00:00' 
 AND    cast(ht.date_depart AS datetime)  < '22/07/2014 18:00:00' and cast(ht.date_fin AS datetime) >= '22/07/2014 08:00:00' 
 AND    cast(ht.date_fin AS datetime)  < '22/07/2014 18:00:00' and v.vehiculeid='6' 
          ");
            DataTable dt= new DataTable();
            dt.Load(dd);
    Document document = new Document();
    PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
    document.Open();
         //   iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

    iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Server.MapPath("/Ressources/Images/logo.png"));
    jpg.ScaleToFit(80f, 50f);
    jpg.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;
    jpg.IndentationLeft = 9f;
    jpg.SpacingAfter = 9f;
    jpg.BorderWidthTop = 36f;
    jpg.BorderColorTop = Color.WHITE;
    document.Add(jpg);

    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));
    document.Add(new Paragraph("       "));


    PdfPTable table = new PdfPTable(dt.Columns.Count);
    PdfPRow row = null;
    float[] widths = new float[] { 5f, 5f,6f,6f,6f,6f,4f,4f,4f,11f};
    iTextSharp.text.Font font5= FontFactory.GetFont("Arial", 8);
    iTextSharp.text.Font font6 = FontFactory.GetFont("Arial", 9);

    iTextSharp.text.Font font1 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD,iTextSharp.text.Color.BLUE);

    table.SetWidths(widths);

    table.WidthPercentage = 100;
    int iCol = 0;
    string colname = "";
    PdfPCell cell = new PdfPCell(new Phrase("Rapport d'activité",font1));

    cell.Colspan = dt.Columns.Count;

    cell.Border = 0;

    cell.HorizontalAlignment = 1;

    table.AddCell(cell);

    foreach (DataColumn c in dt.Columns)
    {

        table.AddCell(new Phrase(c.ColumnName, font6));
    }

    foreach (DataRow r in dt.Rows)
    {
        if (dt.Rows.Count > 0)
        {
            table.AddCell(new Phrase(r[0].ToString(), font5));
            table.AddCell(new Phrase(r[1].ToString(), font5));
            table.AddCell(new Phrase(r[2].ToString(), font5));
            table.AddCell(new Phrase(r[3].ToString(), font5));
            table.AddCell(new Phrase(r[4].ToString(), font5));
            table.AddCell(new Phrase(r[5].ToString(), font5));
            table.AddCell(new Phrase(r[6].ToString(), font5));
            table.AddCell(new Phrase(r[7].ToString(), font5));
            table.AddCell(new Phrase(r[8].ToString(), font5));

            table.AddCell(new Phrase(r[9].ToString(), font5));

          
        }          
    } 
         document.Add(table);
        document.Close();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;" +

                                       "filename=Rapport" + DateTime.Now.Ticks.ToString() + ".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(document);
        Response.End();


        }
        public void pdf_go(object sender, EventArgs e)
        {
            Document doc = new Document();

            try
            {


                PdfWriter.GetInstance(doc,Response.OutputStream);

                doc.Open();



                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance("C:/Users/Public/Pictures/Sample Pictures/aa.jpg");

                Paragraph paragraph = new Paragraph(@"Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Suspendisse blandit blandit turpis. Nam in lectus ut dolor consectetuer bibendum. Morbi neque ipsum, laoreet id; dignissim et, viverra id, mauris. Nulla mauris elit, consectetuer sit amet, accumsan eget, congue ac, libero. Vivamus suscipit. Nunc dignissim consectetuer lectus. Fusce elit nisi; commodo non, facilisis quis, hendrerit eu, dolor? Suspendisse eleifend nisi ut magna. Phasellus id lectus! Vivamus laoreet enim et dolor. Integer arcu mauris, ultricies vel, porta quis, venenatis at, libero. Donec nibh est, adipiscing et, ullamcorper vitae, placerat at, diam. Integer ac turpis vel ligula rutrum auctor! Morbi egestas erat sit amet diam. Ut ut ipsum? Aliquam non sem. Nulla risus eros, mollis quis, blandit ut; luctus eget, urna. Vestibulum vestibulum dapibus erat. Proin egestas leo a metus?");

                paragraph.Alignment = Element.ALIGN_JUSTIFIED;

                jpg.ScaleToFit(250f, 250f);

                jpg.Alignment = iTextSharp.text.Image.TEXTWRAP | iTextSharp.text.Image.ALIGN_RIGHT;

                jpg.IndentationLeft = 9f;

                jpg.SpacingAfter = 9f;

                jpg.BorderWidthTop = 36f;

                jpg.BorderColorTop = Color.WHITE;

                doc.Add(jpg);

                doc.Add(paragraph);

                PdfPTable table = new PdfPTable(4);

                table.TotalWidth = 400f;

                table.LockedWidth = true;

                PdfPCell header = new PdfPCell(new Phrase("Rapport d'activité"));

                header.Colspan = 4;

                table.AddCell(header);

                table.AddCell("Nom");

                table.AddCell("prenom");

                table.AddCell("email");

                table.AddCell("password");

                PdfPTable nested = new PdfPTable(1);

                nested.AddCell("Nested Row 1");

                nested.AddCell("Nested Row 2");

                nested.AddCell("Nested Row 3");

                PdfPCell nesthousing = new PdfPCell(nested);

                nesthousing.Padding = 0f;

                table.AddCell(nesthousing);

                PdfPCell bottom = new PdfPCell(new Phrase("bottom"));

                bottom.Colspan = 3;

                table.AddCell(bottom);

                doc.Add(table);


                /////////////////////////////////
                Font font8 = FontFactory.GetFont("ARIAL", 7);
                PdfPTable PdfTable = new PdfPTable(3);
                PdfPCell PdfPCell = null;


                //Add Header of the pdf table
                PdfPCell = new PdfPCell(new Phrase(new Chunk("nom", font8)));
                PdfTable.AddCell(PdfPCell);

                PdfPCell = new PdfPCell(new Phrase(new Chunk("prenom", font8)));
                PdfTable.AddCell(PdfPCell);

                PdfPCell = new PdfPCell(new Phrase(new Chunk("age", font8)));
                PdfTable.AddCell(PdfPCell);


                //How add the data from datatable to pdf table
                for (int rows = 0; rows < 3; rows++)
                {
                    for (int column = 0; column < 3; column++)
                    {
                        PdfPCell = new PdfPCell(new Phrase(new Chunk("yep", font8)));
                        PdfTable.AddCell(PdfPCell);
                    }
                }

                PdfTable.SpacingBefore = 15f; // Give some space after the text or it may overlap the table

                doc.Add(PdfTable); 

                //////////////////////////////::

            }

            catch (Exception ex)
            {

                //Log error;

            }

            finally
            {

                doc.Close();

            }

        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;" +

                                       "filename=sample"+DateTime.Now.Ticks.ToString()+".pdf");

        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Write(doc);
        Response.End();

        }


        protected void GeneratePDFwithImage(object sender, EventArgs e)
        {
            string path = Server.MapPath("~/Ressources/Images/");
            string fileName = "pdfDocument" + DateTime.Now.Ticks + ".pdf";

            Document doc = new Document();
            try
            {
                Response.OutputStream.Close();
                Response.Clear();

                PdfWriter.GetInstance(doc, new FileStream(path + fileName, FileMode.Create));
                doc.Open();
                doc.Add(new Paragraph("ITFunda.Com"));
                iTextSharp.text.Image gif = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Ressources/Images/logo.png"));
                doc.Add(gif);
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Flush();
                Response.End();

            }
            catch (Exception ex)
            {
                lblMessage.Text = ex.ToString();
            }
            finally
            {
                doc.Close();
            }
        }

        protected void GeneratePDFWithText(object sender, EventArgs e)
        {
            string fileName = "pdfDocument" + DateTime.Now.Ticks + ".pdf";
            string text = "<b>DotNetFunda.Com</b> is a <i>great</i> <u>resource for .NET.</u>";

            Response.Clear();
            GeneratePDFe("", fileName, true, text);
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=Rapport_.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Flush();
            Response.End();
            Response.Close();
        }

        protected void Gen(object sender, EventArgs e)
        {
            //string _dateDebut = this.DateField1.Text.ToString();
            //string _dateFin = this.DateField2.Text.ToString();
            //string _id = this.vehiculeid.Text.ToString();
            string _req = "select * from alerte ";
           DataTable dt = GetData(_req);

            dt.TableName = "Rapport";
            dt.WriteXml(Server.MapPath(".") + @"\finalData.xls", XmlWriteMode.IgnoreSchema);
            Response.Redirect("finalData.xls");
        }

       
        protected void GeneratePDFAndDownload(object sender, EventArgs e)
        {

            string fileName = "pdfDocument" + DateTime.Now.Ticks + ".pdf";
            Response.Clear();
            GeneratePDFe("", fileName, true, "");
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
            Response.Flush();
            Response.End();
        }

        private void GeneratePDFe(string path, string fileName, bool download, string text)
        {
            var document = new Document();
            try
            {
                if (download)
                {
                    PdfWriter.GetInstance(document, Response.OutputStream);
                }
                else
                {
                    PdfWriter.GetInstance(document, new FileStream(path + fileName, FileMode.Create));
                }

                // generates the grid first
                StringBuilder strB = new StringBuilder();
                document.Open();

                if (text.Length.Equals(0)) // export the text
                {
                    BindMyGrid();
                    using (StringWriter sWriter = new StringWriter(strB))
                    {
                        using (HtmlTextWriter htWriter = new HtmlTextWriter(sWriter))
                        {
                            GridView1.RenderControl(htWriter);
                        }
                    }
                }
                else // export the grid
                {
                    strB.Append(text);
                }

                // now read the Grid html one by one and add into the document object
                using (TextReader sReader = new StringReader(strB.ToString()))
                {
                    ArrayList list = HTMLWorker.ParseToList(sReader, new StyleSheet());
                    document.NewPage(); // add Page here
                    foreach (IElement elm in list)
                    {
                      document.Add(elm);
                    }
                    sReader.Close();
                }
            }
            catch (Exception ee)
            {
                lblMessage.Text = ee.ToString();
            }
            finally
            {
                document.Close();
            }
        }

      
        private void BindMyGrid()
        {
            // sql for paging. In production write this in the Stored Procedure
            string sql = "select * from vehiculeConf";


            DataTable table = new DataTable();
            int totalCount = 0;

            // get the data now
            using (SqlConnection conn = Common._Global.CurrentConnection)
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandType = CommandType.Text;
                    SqlParameter p = new SqlParameter("@startRowIndex", SqlDbType.Int);
                    p.Value = _startRowIndex + 1;
                    cmd.Parameters.Add(p);
                    p = new SqlParameter("@pageSize", SqlDbType.Int);
                    p.Value = _pageSize;
                    cmd.Parameters.Add(p);

                    // get the data first
                    using (SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        ad.Fill(table);
                    }

                    // get the total count of the records now
                    sql = "select count(*) from vehiculeConf";
                    cmd.Parameters.Clear();
                    cmd.CommandText = sql;
                    object obj = cmd.ExecuteScalar();
                    totalCount = Convert.ToInt32(obj);

                    conn.Close();
                }
            }

            // bind the data to the grid
            GridView1.DataSource = table;
            GridView1.DataBind();

        }



        public void DoPdf(object sender, EventArgs e)
        {
            string _dateDebut = this.startdate.Text.ToString() +" "+hd.SelectedItem.Text;
            string _dateFin = this.enddate.Text.ToString() + " " + hf.SelectedItem.Text;
            string _id =_idv;
            ////string _contact = "L'Etat du moteur";
            ////string _speed = "Vitesse";

             string repp="select v.matricule, p.nom+' '+p.prenom as name,ht.adr_depart,"
+" ht.date_depart,ht.adr_fin,ht.date_fin,ht.duree,"
+" ht.vitesse,ht.distance,a.titre+' : '+(cast( nt.Descriptione as nvarchar(max)))   as Alarme from Historique_Trajet ht "
+" inner join vehicule_personnel vp on vp.vehiculeid=ht.vehiculeid  and vp.actif=1"
+" inner join personnel p on p.personnelid=vp.personnelid"
+" inner join vehicules v on v.vehiculeid=ht.vehiculeid "
+" inner join Notification nt on nt.vehiculeid=v.vehiculeid"
+" inner join alerte a on a.alerteid=nt.alerteid"
+"  where v.vehiculeid in"
+"   (select pv.vehiculeid from profil_vehicule pv  "
 +"  inner join profil_user pu on  pu.profilid=pv.profilid and   pu.utilisateurid='" + this.getCurrentUser().getUserId() +"' and pu.actif='1' "
  +"   where pv.actif='1'   group by pv.vehiculeid  "
   +"   union  "
  +"    select gv.vehiculeid from groupe_vehicule gv "
  +"     inner join Groupe_Profil gp on gp.groupeid=gv.groupeid and gp.actif='1'"
   +"     inner join profil_user pu on  pu.profilid=gp.profilid  and    pu.utilisateurid='" + this.getCurrentUser().getUserId() + "' and pu.actif='1'"
   +"       where gv.actif='1'  ) and cast(ht.date_depart AS datetime) >= '" + _dateDebut  
 +"'  AND    cast(ht.date_depart AS datetime)  < '" + _dateFin + "' and v.vehiculeid=" + _id;
              //  string _req = "select * from notification where idNoti <19 ";


             DataTable dat = GetData(repp);
             if (dat.Rows.Count > 0)
             {
                 DataRow dr = dat.Rows[0];
                 Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                 Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
                 using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
                 {
                     float[] widths = new float[] { 5f, 5f, 6f, 6f, 6f, 6f, 4f, 4f, 4f, 11f };
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
                     int ii = 0;
                     foreach (DataRow row in dat.Rows)
                     {
                         somkm += (double)row["distance"];
                         tpm += (double)row["duree"];
                         vts += (double)row["vitesse"];
                         ii++;

                     }

                     vts = vts / ii;
                     //Company Logo
                     cell = ImageCell("~/Ressources/Images/logo.png", 70f, PdfPCell.ALIGN_CENTER);
                     table.AddCell(cell);

                     //Company Name and Address
                     phrase = new Phrase();
                     phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                     phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                     phrase.Add(new Chunk("Le rapport d'activité \n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.GRAY)));
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

                     DateTime d1 = DateTime.ParseExact(startdate.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                     DateTime d2 = DateTime.ParseExact(enddate.Text + " 00:00:00", "dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                     TimeSpan ts = d2 - d1;
                     TimeSpan def = ts - tm;

                     phrase.Add(new Chunk("Temps en arret : " + def + " (J.hh:mm:ss )", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                     phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

                     phrase.Add(new Chunk("Vitesse moyenne : " + vts + " Km/h", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                     phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));

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