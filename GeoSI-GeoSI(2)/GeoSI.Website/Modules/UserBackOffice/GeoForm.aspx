<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.UserBackOffice.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
    .imageup
    {
        max-width:150px;
        max-height:150px;
    }
    </style>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <%--Onglet: fiche détail--%>
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
            <%--Déclaration des champs--%>
            <ext:TextField ID="userbackofficeid" runat="server" Name="userbackofficeid" Text="" FieldLabel="userbackofficeid "
                Hidden="true" />

            <ext:TextField ID="nom" runat="server" Text="" FieldLabel="<%$ Resources:Resource,Utilisateur_Nom%> " Vtype="chaine" MaxLength="10" AllowBlank="false"/>

            <ext:TextField ID="prenom" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Prenom%> " Vtype="chaine" MaxLength="10"  AllowBlank="false" />

            <ext:TextField ID="email" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Email%> " Vtype="email" MaxLength="30"  AllowBlank="false" />

            <ext:TextField ID="login" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Login%> " Vtype="chainenum" MaxLength="30" />

            <ext:TextField ID="tel" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Tel%> " Vtype="num" MaxLength="10"  AllowBlank="false" />

            <ext:TextField ID="pwd" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Password%> " Vtype="chainenum" MaxLength="30 " InputType="Password" />

            
            <ext:Button ID="Button2" Type="Submit" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk">
                <Listeners>
                    <Click Handler="#{UserForm}.getForm().submit();" />
                </Listeners>
            </ext:Button>
        </Items>
    </ext:FormPanel>
        </form>
</body>
</html>
