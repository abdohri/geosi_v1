<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Revendeur.aspx.cs" Inherits="GeoSI.Website.Modules.Authentification.Revendeur" %>

<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>Authentification Geomtec</title>
    <link href="../../Ressources/Styles/Authentification/css_authentification.css" rel="stylesheet"
        type="text/css" />
</head>
<body>
   <form id="form1" runat="server">
    <div class="HautAthentif">
        <div class="HautAthentif1">
            
                <div id="logo">

                </div>
                

                <div id="cadreright">
                    
                    <div id="cadreForm" >
                        
                        <div id="divlogin">     
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Login" CssClass="inputText"></asp:TextBox>
                        </div>
                        
                        <div id="divpasse">     
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Mot de passe" CssClass="inputText"></asp:TextBox>
                        </div>

                        <div id="divcaptcha">     
                        <cc1:CaptchaControl ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                            CaptchaHeight="55" CaptchaWidth="152" CaptchaLineNoise="None" CaptchaMinTimeout="5"
                            CaptchaMaxTimeout="240" FontColor="#030166" Width="151px" />
                        </div>

                        <div id="divcode">     
                        <asp:TextBox ID="txtCaptcha" runat="server" placeholder="Code" CssClass="inputText1"></asp:TextBox>
                        </div>

                        <div id="divbtnvalider"> 
                            <asp:Button ID="btnVerify" runat="server" Text="Connexion" CssClass="boutonbleu"
                            OnClick="btnVerify_Click" />
                        </div>
                        
                       <div style="clear:both;"></div>
                    </div>
                  
                    <div id="divStatusBar">
                    <asp:Label ID="StatusBar" runat="server" Text="" CssClass="StatusBar"></asp:Label>
                    </div>

               </div>
                
                        
        </div>
        
    </div>
   

       

<div class="Barmenu">
    </div>
    <div id="imgbas">
      
       </div>
    </form>

</body>
</html>
