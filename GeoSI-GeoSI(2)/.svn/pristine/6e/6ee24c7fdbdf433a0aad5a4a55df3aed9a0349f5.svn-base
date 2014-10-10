<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Client.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .imageup
        {
            max-width: 150px;
            max-height: 150px;
        }
    </style>
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
             <%--Onglet: fiche détail--%>
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
             <%-- Définition des champs de la forme--%>
            <ext:TextField ID="clientid" runat="server"  Text="" FieldLabel="clientid" Hidden="true">
            </ext:TextField>
            <ext:Button ID="Button2" Type="Submit" Cls="btn1" runat="server" Text="Enregister"
                Icon="Disk">
                <Listeners>
                    <Click Handler="#{UserForm}.getForm().submit();" ></Click>
                </Listeners>
            </ext:Button>
            <ext:TextField ID="raison_sociale" runat="server" FieldLabel="<%$ Resources:Resource,Client_Raison_sociale%>" 
                 Width="310" AllowBlank="false" MsgTarget="Side" Vtype="chaine">
            </ext:TextField>

            <ext:TextField ID="sigle"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Sigle%>"
                             MsgTarget="Side" Vtype="chainenum">
            </ext:TextField>
            <ext:FileUploadField ID="logo1" Name="logo" runat="server" Width="330" FieldLabel="Image"
                Icon="Attach">
            </ext:FileUploadField>
            <ext:Image ID="logo" runat="server" ImageUrl="" Cls="imageup">
            </ext:Image>
            <ext:TextField ID="site_web" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Site_Web%> "
                 MsgTarget="Side" >
            </ext:TextField>
            <ext:TextField ID="email" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Email%> "
                 MsgTarget="Side" Vtype="email" >
            </ext:TextField>
            <ext:TextField ID="tel"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Tel%> "
                MaxLength="15" MsgTarget="Side" Vtype="num">
            </ext:TextField>
            <ext:TextField ID="fax"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Fax%> "
               MaxLength="15" MsgTarget="Side" Vtype="num">
            </ext:TextField>
            <ext:TextField ID="capital" LabelCls="label1" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Capital%> "
               MaxLength="20" MsgTarget="Side" Vtype="num">
            </ext:TextField>
            <ext:TextField ID="annee_creation"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Annee_creation%>"
                MaxLength="4" MsgTarget="Side" Vtype="num" AllowBlank="false">
            </ext:TextField>
            <ext:TextField ID="cnss" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Num_Affiliation_CNSS%>" 
               MaxLength="15" Vtype="chainenum">
            </ext:TextField>
            <ext:TextField ID="identifiant_fiscal"  runat="server" Width="310"
                FieldLabel= "<%$ Resources:Resource,Client_Num_Identification_fiscale%>"  MaxLength="15" Vtype="chainenum" >
            </ext:TextField>
            <ext:TextField ID="registre_commerce"  runat="server" Width="310"
                FieldLabel="<%$ Resources:Resource,Client_Registre_commerce%> "  MaxLength="15" Vtype="chainenum">
            </ext:TextField>
            <ext:TextField ID="patente" runat="server" Width="310" FieldLabel=" <%$ Resources:Resource,Client_Num_Patente%> "
                MaxLength="15" Vtype="num">
            </ext:TextField>
            <ext:TextField ID="effectif" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Effectif%>"
                MaxLength="15" Vtype="num">
            </ext:TextField>
            <ext:ComboBox ID="juridiqueid" DisplayField="juridique" Editable="false" Width="310"
                ValueField="juridiqueid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Forme_juridique%>">
                <Store>
                    <ext:Store ID="StoreComboboxJuridique" runat="server">
                        <Model>
                            <ext:Model ID="Model6" runat="server">
                                <Fields>
                                    <ext:ModelField Name="juridiqueid" />
                                    <ext:ModelField Name="juridique" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>
            <ext:ComboBox ID="typeabonnementid" DisplayField="typeabonnement" Editable="false"
                Width="310" ValueField="typeabonnementid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Type_Abonnement%>">
                <Store>
                    <ext:Store ID="StoreComboboxTypeAbonnement" runat="server">
                        <Model>
                            <ext:Model ID="Model7" runat="server">
                                <Fields>
                                    <ext:ModelField Name="typeabonnementid" />
                                    <ext:ModelField Name="typeabonnement" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>
            <ext:TextField ID="adresse" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Client_Adresse%> "
                  MsgTarget="Side" AllowBlank="false" MaxLength="50">
            </ext:TextField>
            <ext:ComboBox ID="villeid" DisplayField="ville" Editable="false" Width="310" ValueField="villeid"
                runat="server" FieldLabel="<%$ Resources:Resource,Client_Ville%> " MsgTarget="Side" AllowBlank="false">
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
            <ext:ComboBox ID="paysid" DisplayField="pays" Editable="false" Width="310" ValueField="paysid"
                runat="server" FieldLabel="<%$ Resources:Resource,Client_Pays%> " MsgTarget="Side" AllowBlank="false">
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
            <ext:DateField ID="date_expiration"  runat="server" Width="310" Editable="false"
                FieldLabel="<%$ Resources:Resource,Client_Date_Expiration%> " FieldCls="input1" MsgTarget="Side" AllowBlank="false">
            </ext:DateField>
            <ext:ComboBox ID="profilclientid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="profilclientid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Type_Client%>" Cls="ligne1"
                AllowBlank="false">
                <Store>
                    <ext:Store ID="StoreComboboxProfilclient" runat="server">
                        <Model>
                            <ext:Model ID="Model3" runat="server">
                                <Fields>
                                    <ext:ModelField Name="profilclientid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
            <ext:ComboBox ID="langueid" DisplayField="libelle" Editable="false" Width="310" ValueField="langueid"
                runat="server" FieldLabel="<%$ Resources:Resource,Client_Langue%>" Cls="ligne1" AllowBlank="false">
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
             <ext:ComboBox ID="societe_mereid" DisplayField="societe_mere" Editable="false" Width="310"
                ValueField="societe_mereid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Societe_Mere%>">
                <Store>
                    <ext:Store ID="StoreComboboxSociteMere" runat="server">
                        <Model>
                            <ext:Model ID="Model8" runat="server">
                                <Fields>
                                    <ext:ModelField Name="societe_mereid" />
                                    <ext:ModelField Name="societe_mere" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>
             <ext:ComboBox ID="bourseid" DisplayField="bourse" Editable="false" Width="310"
                ValueField="bourseid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Bourse%>">
                <Store>
                    <ext:Store ID="StoreComboboxBourse" runat="server">
                        <Model>
                            <ext:Model ID="Model9" runat="server">
                                <Fields>
                                    <ext:ModelField Name="bourseid" />
                                    <ext:ModelField Name="bourse" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>
             <ext:ComboBox ID="carte_dataid" DisplayField="carte_data" Editable="false" Width="310"
                ValueField="carte_dataid" runat="server" FieldLabel="<%$ Resources:Resource,Client_CarteData%>">
                <Store>
                    <ext:Store ID="StoreComboboxCarteData" runat="server">
                        <Model>
                            <ext:Model ID="Model10" runat="server">
                                <Fields>
                                    <ext:ModelField Name="carte_dataid" />
                                    <ext:ModelField Name="carte_data" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>
            <ext:ComboBox ID="cartegeographieid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="cartegeographieid" runat="server" FieldLabel="<%$ Resources:Resource,Client_Carte%>" MsgTarget="Side"
                AllowBlank="false">
                <Store>
                    <ext:Store ID="StoreComboboxcarte" runat="server">
                        <Model>
                            <ext:Model ID="Model2" runat="server">
                                <Fields>
                                    <ext:ModelField Name="cartegeographieid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
            
        </Items>
    </ext:FormPanel>
    </form>
</body>
</html>
