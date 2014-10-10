<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Personnel.GeoForm" %>

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
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
            <ext:TextField ID="personnelid" runat="server" Name="personnelid" Text="" FieldLabel="personnelid "
                Hidden="true" />

            <ext:TextField ID="nom" runat="server" FieldLabel="<%$ Resources:Resource,Personnel_Nom%> " Width="310" Vtype="chaine" MaxLength="20" AllowBlank="false"/>

            <ext:TextField ID="prenom" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Personnel_Prenom%> " Vtype="chaine" MaxLength="20" AllowBlank="false"/>

            <ext:FileUploadField ID="photo1" Name="photo" runat="server" Width="330" FieldLabel="Image" Icon="Attach" />
            <ext:Image ID="photo" runat="server" ImageUrl="" Cls="imageup" />

            <ext:TextField ID="permis" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Personnel_Permis%> " vtype="chainenum" MaxLength="10"/>

            <ext:TextField ID="cin" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Personnel_Cin%> " Vtype="chainenum" MaxLength="20" AllowBlank="false"/>

            <ext:TextField ID="cnss" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Personnel_Cnss%> " Vtype="chainenum" MaxLength="20" />

            <ext:DateField ID="date_embauche"  runat="server" Width="310" Editable="false" FieldLabel="<%$ Resources:Resource,Personnel_Date_Embauche%>" >
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
      
            </ext:DateField>

            <ext:DateField ID="date_expiration"  runat="server" Width="310" Editable="false" FieldLabel="<%$ Resources:Resource,Personnel_Date_Expiration%>" >
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
      
            </ext:DateField>

            <ext:ComboBox ID="typepersonnelid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="typepersonnelid" runat="server" FieldLabel="<%$ Resources:Resource,Personnel_Typepersonnel%>" AllowBlank="false">
                <Store>
                    <ext:Store ID="Store3" runat="server">
                        <Model>
                            <ext:Model ID="Model3" runat="server">
                                <Fields>
                                    <ext:ModelField Name="typepersonnelid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>

           <ext:TextArea ID="remarque" runat="server" Height="50" Width="400" FieldLabel="<%$ Resources:Resource,Personnel_Remarque%> "
                MsgTarget="Side">
            </ext:TextArea>

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
