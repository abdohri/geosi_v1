using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GeoSI.Website.Common
{

    public class UserInfo
    {   //Récuperer utilisateur id
        public int getUserId()
        {
            return UserId;
        }
        //Modifier utilisateur id
        public void setUserId(int userId)
        {
            UserId = userId;
        }
        //Récuperer revendeur id
        public int getRevendeurId()
        {
            return this.RevendeurId;
        }
        //Récuperer revendeur id 
        public void setRevendeurId(int RevendeurId)
        {
            this.RevendeurId = RevendeurId;
        }
        //Récuperer client id
        public int getClientId()
        {
            return ClientId;
        }
        //Modifier client id
        public void setClientId(int clientId)
        {
            ClientId = clientId;
        }
        //Récuperer session id
        public String getSessionId()
        {
            return SessionId;
        }
        //Modifier session id
        public void setSessionId(String sessionId)
        {
            SessionId = sessionId;
        }
        //Récuperer revendeur
        public String getRevendeur()
        {
            return this.Revendeur;
        }
        //Modifier revendeur
        public void setRevendeur(String Revendeur)
        {
            this.Revendeur = Revendeur;
        }
        //Récuperer TypeCompte 
        public int getTypeCompte()
        {
            return TypeCompte;
        }
        //Modifier TypeCompte
        public void setTypeCompte(int typeCompte)
        {
            TypeCompte = typeCompte;
        }
        //Récuperer BackOffice id
        public int getBackOfficeId()
        {
            return this.BackOfficeId;
        }
        //Modifier BackOffice id
        public void setBackOfficeId(int BackOfficeId)
        {
            this.BackOfficeId = BackOfficeId;
        }
        //Récuperer BackOffice
        public string getBackOffice()
        {
            return this.BackOffice;
        }
        //Modifier BackOffice
        public void setBackOffice(string BackOffice)
        {
            this.BackOffice = BackOffice;
        }

        private int UserId;

        private int ClientId;
        private String SessionId;
        private String Revendeur = "";
        private int TypeCompte;
        private int RevendeurId;
        private int BackOfficeId;
        private String BackOffice = "";
    }
}