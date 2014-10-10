﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenererPdf.aspx.cs" Inherits="GeoSI.Website.Modules.RapportActiv.GenererPdf" %>




<!DOCTYPE>
<html>
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
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    <script type="text/javascript">
        function DesaffPersonnel(_iddesaffect) {
            X.DesaffectationPersonnel(_iddesaffect);
        }
    </script>
    <script>
        var onKeyUp = function () {
            var me = this,
                v = me.getValue(),
                field;

            if (me.startDateField) {
                field = Ext.getCmp(me.startDateField);
                field.setMaxValue(v);
                me.dateRangeMax = v;
            } else if (me.endDateField) {
                field = Ext.getCmp(me.endDateField);
                field.setMinValue(v);
                me.dateRangeMin = v;
            }

            field.validate();
        };
    </script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server" Method="GET">
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X" />
        <ext:TabPanel ID="TabPanel1" 
            runat="server" 
            DeferredRender="false">
            <Items>
                 <%-- Onglet1: fiche de détails--%>
            <ext:Panel ID="Panel1" runat="server" Title="<%$ Resources:Resource,title_Module_Vehicules%>">
            <Items>
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GenererPdf.aspx"
        Method="GET">
        <Items>
            <ext:TextField ID="vehiculeid" runat="server" Name="vehiculeid" Text="" FieldLabel="vehiculeid "
                Hidden="true" />


                <ext:DateField 
                    ID="DateField1" 
                    runat="server"
                    Vtype="daterange"
                    FieldLabel="<%$ Resources:Resource,Date_debut%>"
                    EnableKeyEvents="true">  
                    <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="DateField2" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                

                    
                <ext:DateField 
                    ID="DateField2"
                    runat="server" 
                    Vtype="daterange"
                    FieldLabel="<%$ Resources:Resource,Date_fin%>"
                    EnableKeyEvents="true">    
                    <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="DateField1" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>
                </ext:DateField>
                
                


           
            <ext:ComboBox ID="marquevehiculeid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="marquevehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Marque%> " AllowBlank="false" Hidden="true">
                <Store>
                    <ext:Store ID="Store2" runat="server">
                        <Model>
                            <ext:Model ID="Model2" runat="server">
                                <Fields>
                                    <ext:ModelField Name="marquevehiculeid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>

            <ext:ComboBox ID="typevehiculeid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="typevehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Type_vehicule%>" AllowBlank="false" Hidden="true">
                <Store>
                    <ext:Store ID="Store3" runat="server">
                        <Model>
                            <ext:Model ID="Model3" runat="server">
                                <Fields>
                                    <ext:ModelField Name="typevehiculeid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
              

            <ext:MultiCombo ID="personnelid" runat="server" ValueField="personnelid" FieldLabel="<%$ Resources:Resource,Vehicules_Personnel%> " DisplayField="nom" Width="400" Hidden="true">
               <Store>
                    <ext:Store ID="Store5" runat="server">
                        <Model>
                            <ext:Model ID="Model5" runat="server">
                                <Fields>
                                    <ext:ModelField Name="personnelid" />
                                    <ext:ModelField Name="nom" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
        </ext:MultiCombo>



            <ext:ComboBox ID="BoitierId" DisplayField="imei" Width="310" MinChars="1" TypeAhead="true"
                ForceSelection="true" ValueField="boitierid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Boitier%> " Hidden="true">
                <Store>
                    <ext:Store ID="Store4" runat="server">
                        <Model>
                            <ext:Model ID="Model1" runat="server">
                                <Fields>
                                    <ext:ModelField Name="boitierid" />
                                    <ext:ModelField Name="imei" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                </Triggers>
                <Listeners>
                    <Select Handler="this.getTrigger(0).show();" />
                    <BeforeQuery Handler="this.getTrigger(0)[this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                    <TriggerClick Handler="if (index == 0) { 
                                           this.clearValue(); 
                                           this.getTrigger(0).hide();
                                       }" />
                </Listeners>
            </ext:ComboBox>

            <ext:Button ID="Button2" Type="Button" Cls="btn1" runat="server"  OnDirectClick="make_pdf" Text="<%$ Resources:Resource,BtnPdf%> "
                Icon="PageWhiteAcrobat">
                    
            </ext:Button>
            
        </Items>
    </ext:FormPanel>
                </Items>
                </ext:Panel>

                </Items>
                </ext:TabPanel>
        <asp:Button ID="Button3" runat="server" Text="Generate PDF " OnClick="make_pdf" />
    </form>
</body>
</html>

