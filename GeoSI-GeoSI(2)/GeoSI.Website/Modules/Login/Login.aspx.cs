﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using GeoSI.Website.Common;
using System.Data;
using System.Data.SqlClient;
namespace GeoSI.Website.Modules.Login
{


    public partial class Login : LoginGeo
    {

        UserInfo _user = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void tst(object sender, EventArgs e)
        {
            PageBase p = new PageBase();
            p.DepassementVitesseAlarme();

        }
        //Authentification client  (vérification)
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" && txtCaptcha.Text != "")
            {
                string Login = txtUsername.Text;

                string Password = this.Hash(txtPassword.Text);
                string _req = "select u.utilisateurid,u.clientid,l.code code from  utilisateur u " +
        "inner join client c on  u.clientid=c.clientid " +
        "inner join langue l on u.langueid=l.langueid " +
        "where u.login='" + Login + "' and u.actif='1' and  u.pwd='" + Password + "' and c.actif='1'";
                //      string _req = "select u.utilisateurid,u.clientid from utilisateur u,client c where u.clientid=c.clientid and u.login='" + Login + "' and u.pwd='" + Password + "' and u.actif='1' and c.actif='1'";


                List<string> usrId = this.Authentification(_req);

                // les champs login , mot de passe et code ont été saisi
                if (usrId.Count == 3)
                {
                    Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                    // En cas de saisie valide
                    if (Captcha1.UserValidated)
                    {
                        StatusBar.Text = "<img src=\"../../Ressources/Images/ajax-loader.gif\" style=\"margin-right:8px;\" /> Chargement";
                        
                        _user.setUserId(int.Parse(usrId.ElementAt(0)));
                        _user.setClientId(int.Parse(usrId.ElementAt(1)));
                        _user.setTypeCompte(3);
                        Session["Culture"] = usrId.ElementAt(2).ToString();

                        new PageBase().setCurrentUser(_user);



                        string _reqHabilitation = "select action from habilitation h " +
                                "inner join habilitation_profil hp on hp.habilitationid=h.habilitationid " +
                                "inner join profil p on p.profilid = hp.profilid " +
                                "inner join profil_user pu on pu.profilid=p.profilid " +
                                "inner join utilisateur u on u.utilisateurid=pu.utilisateurid " +
                                "inner join client c on c.clientid=u.clientid " +
                                "where pu.utilisateurid=" + usrId.ElementAt(0) + " and u.clientid=" + usrId.ElementAt(1) + " and c.actif='1'";
                        List<string> _ListAction = this.getHabilitation(_reqHabilitation);

                        Session["HabilitationAction"] = _ListAction;

                        //Redirection vers la page par defaut carte
                        Response.Redirect("../Carte/Tempsreel.aspx");
                        }
                        // Dans le cas où le login est invalide
                         else
                         {
                           StatusBar.ForeColor = System.Drawing.Color.Red;
                           StatusBar.Text = "<img src=\"../../Ressources/Images/exclamation.png\" style=\"margin-right:8px;\" /> Le code saisie est InValid";
                           txtCaptcha.Text = "";
                        }
                    }
                    //Dans le ca où  login et mot de passe ne sont pas  valides
                      else
                    {
                        txtCaptcha.Text = "";
                        StatusBar.ForeColor = System.Drawing.Color.Red;
                        StatusBar.Text = "<img src=\"../../Ressources/Images/exclamation.png\" style=\"margin-right:8px;\" /> Le login ou/et le mot de passe saisie est incorrect !!";
                    }
                }
                // Dans le cas où il n'y apas de saisie
                 else
                {
                    StatusBar.ForeColor = System.Drawing.Color.Red;
                    StatusBar.Text = "<img src=\"../../Ressources/Images/exclamation.png\" style=\"margin-right:8px;\" />Les champs login, mot de passe et code sont obligatoire !!";
                }
            }

       
    }

    
}