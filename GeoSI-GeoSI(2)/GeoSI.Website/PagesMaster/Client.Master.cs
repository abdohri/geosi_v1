using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace GeoSI.Website.PagesMaster
{
    public partial class Client : System.Web.UI.MasterPage
    {
      public  UserInfo s = new UserInfo();
      public PageBase p = new PageBase();
      public SqlDataReader d;
      public Notification not = new Notification();
      public List<Notification> lst = new List<Notification>();
      public List<vehicules> lstv = new List<vehicules>();
      
        protected void Page_Load(object sender, EventArgs e)
        {
           
//this.Label1.Text = count.ToString() + ">>>>"+lstv[0].matricule.ToString()  ;// + v.matricule.ToString();
//this.Label2.Text = count.ToString();
           

        }

        public String getAlarmeById(int id)
        {
            String res = "";

            try
            {
                d = p.Select("select * from alerte where alerteid=" + id);
                if (d.HasRows)
                {
                    while (d.Read())
                    {

                        res = d[1].ToString();



                    }
                }
                d.Close();
            }
            catch (Exception ex) { }
            finally { d.Close(); }
            return res;
        }
         public List<Notification> getLisNot()
        {
            List<Notification> lst = new List<Notification>();

            try
            {

                s = p.getCurrentUser();
                d = p.Select("select * from Notification where utilisateurid=" + s.getUserId() + " and Vu='non'");
                int count = 0;

                if (d.HasRows)
                {
                    while (d.Read())
                    {
                        count++;
                        Notification n = new Notification();
                        n.vehiculeid = (int)d[2];
                        n.alerteid = (int)d[3];
                        n.DateAlert = (DateTime)d[4];
                        n.Descriptione = d[5].ToString();

                        lst.Add(n);


                    }
                }
                d.Close();
            }
            catch (Exception ex) { }
            finally
            {
                d.Close();
            }

            //for (int i = 0; i < lst.Count; i++)
            //{
            //    lstv.Add(p.GetVehByID("select * from vehicules where vehiculeid=" + lst[i].vehiculeid + ""));
            //}
            if (lst.Count > 0)
            {
                return lst;
            }
            else
            {
                return null;
            }


        }
    }
}