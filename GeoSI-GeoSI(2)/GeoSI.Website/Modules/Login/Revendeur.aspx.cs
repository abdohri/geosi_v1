using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GeoSI.Website.Common;

namespace GeoSI.Website.Modules.Authentification
{
    public partial class Revendeur : LoginGeo
    {

        UserInfo _user = new UserInfo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //Authentification Revendeur (vérification)
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "" && txtCaptcha.Text != "")
            {
                string Login = txtUsername.Text;

                string Password = this.Hash(txtPassword.Text);

                string _req = "select revendeurid,raison_sociale , l.code code from revendeur r inner join langue l on r.langueid=l.langueid where login='" + Login + "' and pwd='" + Password + "' and actif='1'";


                List<string> usrId = this.Authentification(_req);

                // les champs login , mot de passe et code ont été saisi
                if (usrId.Count == 3)
                {
                    Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
                    // En cas de saisie valide
                    if (Captcha1.UserValidated)
                    {
                        StatusBar.Text = "<img src=\"../../Ressources/Images/ajax-loader.gif\" style=\"margin-right:8px;\" /> Chargement";
                         _user.setClientId(0);
                        _user.setUserId(0);
                        _user.setTypeCompte(2);
                        _user.setRevendeurId(int.Parse(usrId.ElementAt(0)));
                        _user.setRevendeur(usrId.ElementAt(1));
                        Session["Culture"] = usrId.ElementAt(2).ToString();
                        new PageBase().setCurrentUser(_user);
                        //Redirection vers la page par defaut carte
                        Response.Redirect("../Client/Client.aspx");
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