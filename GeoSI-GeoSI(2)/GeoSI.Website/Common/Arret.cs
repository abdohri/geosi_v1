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

    public class Arret
    {
        public DateTime dateF;
        public DateTime dateD;
        public string latitude;
        public string longitude;
        public string duree;
        public string vehicule;
        public int contact;
        public string adr;
        public void setcontact(int c)
        {
            this.contact = c;
        }
        public int getcontact()
        {
            return contact;
        }
        public Arret()
        {

        }

        public void setlatitude(string l)
        {
            this.latitude = l;
        }
        public void setadr(string l)
        {
            this.adr = l;
        }

        public void setlongitude(string l)
        {
            this.longitude = l;
        }

        public void setduree(string d)
        {
            this.duree = d;
        }

        public string getlatitude()
        {
            return this.latitude;
        }
        public string getlongitude()
        {
            return this.longitude;
        }
        public string getduree()
        {
            return this.duree;
        }


        public DateTime GetDateD()
        {
            return this.dateD;
        }
        public DateTime GetDateF()
        {
            return this.dateF;
        }
        public void SetDateD(DateTime d)
        {
            this.dateD = d;
        }
        public string Getvehcicule()
        {
            return this.vehicule;
        }
        public void SetDateF(DateTime d)
        {
            this.dateF = d;
        }
     
        public void Setvehicule(string id)
        {
            this.vehicule = id;
        }

    }
}