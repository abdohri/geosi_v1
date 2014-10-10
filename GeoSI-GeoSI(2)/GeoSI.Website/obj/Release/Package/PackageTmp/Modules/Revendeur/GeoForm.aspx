<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Revendeur.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <style>
        .imageup
        {
            max-width: 150px;
            max-height: 150px;
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
        <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
            Method="POST">
             <%-- Définition des champs de la forme--%>
            <Items>
                <ext:TextField ID="revendeurid" runat="server" Text="" FieldLabel="<%$ Resources:Resource,Revendeur_Revendeurid%>"
                    Hidden="true" />


                <ext:TextField ID="raison_sociale" runat="server" FieldLabel="<%$ Resources:Resource,Revendeur_Raison_sociale%> "
                    Width="310" AllowBlank="false">
                </ext:TextField>
                <ext:TextField ID="sigle" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_Sigle%>">
                </ext:TextField>
                <ext:TextField ID="login" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_Login%> " AllowBlank="false"
                    Vtype="chainenum">
                </ext:TextField>
                <ext:TextField ID="pwd" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_password%> "
                    InputType="Password">
                </ext:TextField>
                <ext:FileUploadField ID="logo1" runat="server" Width="330" Name="logo" FieldLabel="<%$ Resources:Resource,Revendeur_Logo%>"
                    Icon="Attach">
                </ext:FileUploadField>
                <ext:Image ID="logo" runat="server" ImageUrl="" Cls="imageup">
                </ext:Image>
                <ext:TextField ID="site_web" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_Site_Web%> "
                    FieldCls="input1" Cls="ligne1">
                </ext:TextField>
                <ext:TextField ID="email" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_Email%> " AllowBlank="false"
                    Vtype="email">
                </ext:TextField>
                <ext:TextField ID="adresse" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Revendeur_Adresse%> "
                    AllowBlank="false" Vtype="chainenum">
                </ext:TextField>
                <ext:ComboBox ID="paysid" DisplayField="pays" Editable="false" Width="310" ValueField="paysid" AllowBlank="false"
                    runat="server" FieldLabel="<%$ Resources:Resource,Revendeur_Pays%>">
                    <Store>
                        <ext:Store ID="StoreComboboxPays" runat="server">
                            <Model>
                                <ext:Model ID="Model5" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="paysid" />
                                        <ext:ModelField Name="pays" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="villeid" DisplayField="ville" Editable="false" Width="310" ValueField="villeid" AllowBlank="false"
                    runat="server" FieldLabel="<%$ Resources:Resource,Revendeur_Ville%>">
                    <Store>
                        <ext:Store ID="StoreComboboxVille" runat="server">
                            <Model>
                                <ext:Model ID="Model4" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="villeid" />
                                        <ext:ModelField Name="ville" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:ComboBox ID="langueid" DisplayField="libelle" Editable="false" Width="310" ValueField="langueid"
                    runat="server" FieldLabel="<%$ Resources:Resource,Revendeur_Langue%>" AllowBlank="false">
                    <Store>
                        <ext:Store ID="StoreComboboxlangue" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="langueid" />
                                        <ext:ModelField Name="libelle" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:Button ID="Button2" Type="Submit" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="#{UserForm}.getForm().submit();"></Click>
                    </Listeners>
                </ext:Button>
            </Items>
        </ext:FormPanel>
    </form>
</body>
</html>
