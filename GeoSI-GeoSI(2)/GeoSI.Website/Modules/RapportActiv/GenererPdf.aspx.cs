using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Ext.Net;
using System.Threading;
using System.Globalization;
using GeoSI.Website.Common;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;

using System.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Reflection;
using System.Net;
using System.Xml.Linq;

namespace GeoSI.Website.Modules.RapportActiv
{

    public partial class GenererPdf : Form
    {
        

        public string test(string longitude) {

            return "";
        
        }

        String add = "aa";
        static string baseUri = "http://maps.googleapis.com/maps/api/" + "geocode/xml?latlng={0},{1}&sensor=false";

        public string RetrieveFormatedAddress(string lat, string lng)
        {
            string requestUri = string.Format(baseUri, lat, lng);
            using (WebClient wc = new WebClient())
            {
                wc.DownloadStringCompleted += new DownloadStringCompletedEventHandler(wc_DownloadStringCompleted);
                return wc.DownloadString(new Uri(requestUri));


            }
        }
        public void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            var xmlElm = XElement.Parse(e.Result);
            var status = (from elm in xmlElm.Descendants() where elm.Name == "status" select elm).FirstOrDefault();
            if (status.Value.ToLower() == "ok")
            {
                var res = (from elm in xmlElm.Descendants() where elm.Name == "formatted_address" select elm).FirstOrDefault();
                add = res.Value;

                // Console.WriteLine(res.Value); 
            }
            else
            {
                //Console.WriteLine("No Address Found");
                add = "NOOOOOOO";
            }
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            this.SetNomModule("Vehicules");
            this.PreSchema("Vehicules", "VehiculeId");
            if (!X.IsAjaxRequest)
            {   
                    string id = Request.Params.Get("id").ToString();
                    if (id != "0")
                    {
                        this.InitForm(id, this.UserForm);


                    }

                    // Remplissage des combobox existant dans la forme
                    string _marque = "select marquevehiculeid,libelle from marquevehicule where actif='1' and ClientId=-1 or ClientId=" + this.getCurrentUser().getClientId();
                    this.FillStore(_marque, this.Store2);

                    string _type = "select typevehiculeid,libelle from typevehicule where actif='1' and clientid=-1 or clientid=" + this.getCurrentUser().getClientId();
                    this.FillStore(_type, this.Store3);


                    string _comboBoitier = "select boitierid,imei from boitier where actif='1' and ClientId=" + this.getCurrentUser().getClientId() + " and BoitierId NOT IN (select BoitierId from affectation_vehicule_boitier where ClientId=" + this.getCurrentUser().getClientId() + " and actif='1')";
                    this.FillStore(_comboBoitier, this.Store4);

                    string _comboPersonnel = "Select personnelid,nom+' '+prenom nom From personnel where actif='1' and clientid=" + this.getCurrentUser().getClientId() + " and personnelid not in(select personnelid from vehicule_personnel where actif='1')";
                    this.FillStore(_comboPersonnel, this.Store5);
                

            }
        }

       [DirectMethod(ShowMask = true, Msg = "Loading...")]
        public void make_pdf(object sender, EventArgs e)
        {
               string _dateDebut = this.DateField1.Text.ToString();
            string _dateFin = this.DateField2.Text.ToString();
            string _id = this.vehiculeid.Text.ToString();
            PageBase pp = new PageBase();
          string repp="select v.matricule, p.nom+' '+p.prenom as name,ht.adr_depart,"
+" ht.date_depart,ht.adr_fin,ht.date_fin,ht.duree,"
+" ht.vitesse,ht.distance,a.titre+' : '+(cast( nt.Descriptione as nvarchar(max)))   as deescription from Historique_Trajet ht "
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
          SqlDataReader dd = pp.Select(repp);
            DataTable dt = new DataTable();
            dt.Load(dd);
            Document document = new Document();
            PdfWriter writer = PdfWriter.GetInstance(document, Response.OutputStream);
            document.Open();
            //   iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(Server.MapPath("/Ressources/Images/logo.png"));
            jpg.ScaleToFit(141f, 70f);
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
      


            PdfPTable table = new PdfPTable(dt.Columns.Count);
            PdfPRow row = null;
            float[] widths = new float[] { 5f, 5f, 6f, 6f, 6f, 6f, 4f, 4f, 4f, 11f };
            iTextSharp.text.Font font5 = FontFactory.GetFont("Arial", 8);
            iTextSharp.text.Font font6 = FontFactory.GetFont("Arial", 9);

            iTextSharp.text.Font font1 = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD, iTextSharp.text.Color.BLUE);

            table.SetWidths(widths);

            table.WidthPercentage = 100;
            int iCol = 0;
            string colname = "";
            PdfPCell cell = new PdfPCell(new Phrase("Rapport d'activité", font1));

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


            dt.Columns.Add("adress", typeof(string));


            foreach (DataRow dr in dt.Rows)
            {

                //float a = (float)dr["longitude"];

                //dr["adress"] = test(dr["longitude"].ToString());
                
                //string lat =dr["latitude"].ToString();
                //string longi = dr["longitude"].ToString();
                //string adr = RetrieveFormatedAddress(longi, lat);
                dr["adress"] = "1";
                    //
            }

            //dt.Columns.RemoveAt(4);
            //dt.Columns.RemoveAt(5);
            
            

            return dt;


        }


        [DirectMethod(ShowMask = true, Msg = "Loading...")]
        public void GeneratePDF()
        {
            string _dateDebut = this.DateField1.Text.ToString();
            string _dateFin = this.DateField2.Text.ToString();
            string _id = this.vehiculeid.Text.ToString();
            ////string _contact = "L'Etat du moteur";
            ////string _speed = "Vitesse";


            if (_dateDebut != "01/01/0001 00:00:00" || _dateFin != "01/01/0001 00:00:00")
            {


                string _req = "select v.matricule matricule,d.SendingDateTime date,d.contact  , d.speed , d.latitude latitude, d.longitude longitude from  Datatracker d "
                   + "INNER join boitier b on b.imei=d.imei "
                   + "INNER join affectation_vehicule_boitier avb on  avb.boitierid=b.boitierid "
                   + "INNER join vehicules v on v.vehiculeid=avb.vehiculeid "
                   + "where v.clientid= " + this.getCurrentUser().getClientId() + " and v.vehiculeid=6 and d.SendingDateTime between '" + _dateDebut + "' and '" + _dateFin + "' and v.actif='1';";

 



                DataRow dr = GetData(_req).Rows[0]; ; ;
                Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);
                Font NormalFont = FontFactory.GetFont("Arial", 12, Font.NORMAL, Color.BLACK);
                using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())

                {


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

                    //Company Logo
                    cell = ImageCell(Server.MapPath("/Ressources/Images/logo.png"), 70f, PdfPCell.ALIGN_CENTER);
                    table.AddCell(cell);

                    //Company Name and Address
                    phrase = new Phrase();
                    phrase.Add(new Chunk("Le rapport d'activité \n\n", FontFactory.GetFont("Arial", 16, Font.BOLD, Color.BLUE)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Site web : www.geomtec.ma\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("E-mail :support@geomtec.com\n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk(" \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
                    phrase.Add(new Chunk("Tel :05.22.30.31.00 \n", FontFactory.GetFont("Arial", 10, Font.NORMAL, Color.BLACK)));
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
                    DrawLine(writer, 25f, document.Top - 100f, document.PageSize.Width - 25f, document.Top - 100f, color);
                    DrawLine(writer, 25f, document.Top - 100f, document.PageSize.Width - 25f, document.Top - 100f, color);


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
                    table2 = new PdfPTable(GetData(_req).Columns.Count);
                    table2.TotalWidth = 500f;
                    table2.LockedWidth = true;
                    table2.WidthPercentage = 100;

                    
                    
                    //table2.SetWidths(new float[] { 0.4f, 0.6f });
                    iTextSharp.text.Font font5 = FontFactory.GetFont("Arial", 8);
                    iTextSharp.text.Font font6 = FontFactory.GetFont("Arial", 9);


                    for (int j = 0; j < GetData(_req).Columns.Count; j++)
                    {
                        table2.AddCell(new Phrase(GetData(_req).Columns[j].ColumnName, font6));
                    }

                    table2.HeaderRows = 1;


                    for (int i = 0; i < GetData(_req).Rows.Count; i++)
                    {

                        for (int k = 0; k < GetData(_req).Columns.Count; k++)
                        {

                            if (GetData(_req).Rows[i][k] != null)
                            {
                                table2.AddCell(new Phrase(GetData(_req).Rows[i][k].ToString(),font5));
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
                    Response.AddHeader("Content-Disposition", "attachment; filename=Rapport_" + dr["matricule"] + ".pdf");
                    Response.Write(msg1);
                    Response.Buffer = true;
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.BinaryWrite(bytes);
                    Response.End();
                    Response.Close();

                }

            }

            else {
                X.Msg.Show(new MessageBoxConfig
                {
                    Title = Resources.Resource.Information,
                    Message = Resources.Resource.DateValid,
                    Buttons = MessageBox.Button.OK,
                    Icon = MessageBox.Icon.INFO
                });
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