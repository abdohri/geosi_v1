<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Vehicules.GeoForm" %>

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
    <script type="text/javascript">
        function DesaffPersonnel(_iddesaffect) {
            X.DesaffectationPersonnel(_iddesaffect);
        }
    </script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X" />
        <ext:TabPanel ID="TabPanel1" 
            runat="server" 
            DeferredRender="false">
            <Items>
                 <%-- Onglet1: fiche de détails--%>
            <ext:Panel ID="Panel1" runat="server" Title="<%$ Resources:Resource,title_Module_Vehicules%>">
            <Items>
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
            <ext:TextField ID="vehiculeid" runat="server" Name="vehiculeid" Text="" FieldLabel="vehiculeid "
                Hidden="true" />

            <ext:TextField ID="code" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Code%> " Width="310" Vtype="chainenum" MaxLength="20" />

            <ext:TextField ID="matricule" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Vehicules_Matricule%> " AllowBlank="false"  MaxLength="20" />

            <ext:FileUploadField ID="imgVehicule1" Name="imgVehicule" runat="server" Width="330" FieldLabel="<%$ Resources:Resource,Vehicules_Image%>" Icon="Attach" />
            <ext:Image ID="imgVehicule" runat="server" ImageUrl="" Cls="imageup" />

            <ext:TextField ID="numero_chassis" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Vehicules_Numero_chassis%> " Vtype="chainenum" MaxLength="20" />

            <ext:TextField ID="modele" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Vehicules_Modèle%> " Vtype="num" MaxLength="4"/>

            <ext:TextField ID="kilometrage" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Vehicules_kilometrage%>  " Vtype="num" MaxLength="10"/>

            <ext:TextField ID="consommation" runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Vehicules_consommation%>  " Vtype="num" MaxLength="20"/>

            <ext:ComboBox ID="marquevehiculeid" DisplayField="libelle" Editable="false" Width="310"
                ValueField="marquevehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Marque%> " AllowBlank="false">
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
                ValueField="typevehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Type_vehicule%>" AllowBlank="false">
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
              

            <ext:MultiCombo ID="personnelid" runat="server" ValueField="personnelid" FieldLabel="<%$ Resources:Resource,Vehicules_Personnel%> " DisplayField="nom" Width="400">
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
                ForceSelection="true" ValueField="boitierid" runat="server" FieldLabel="<%$ Resources:Resource,Vehicules_Boitier%> ">
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

            <ext:Button ID="Button2" Type="Submit" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk">
                <Listeners>
                    <Click Handler="#{UserForm}.getForm().submit();" />
                </Listeners>
            </ext:Button>
        </Items>
    </ext:FormPanel>
                </Items>
                </ext:Panel>
                  <%-- Onglet2: affectation boitier--%>
                <ext:Panel ID="Panel2" runat="server" Title=" <%$ Resources:Resource,Vehicules_Boitier_desaffectes%>">
                    <Items>
                          <%--  Affectation courante--%>
                        <ext:Panel ID="Panel3" runat="server" Header="false" Border="false" >
       <Content>     
    <fieldset id="divDesaffectation" runat="server" style="border-radius:5px;">
<legend style="font-family:Arial;font-size:13px;">&nbsp; Affectation Courante : &nbsp;</legend>
<table style="width:100%;">
            <tr>
                <td>
                    Matricule</td>
                <td>
                    Boitier</td>
                <td>date affectation</td>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="MatriculeLabel" Text=""></ext:Label></td>
                <td><ext:Label runat="server" ID="BoitierLabel" Text=""></ext:Label></td>
                <td><ext:Label runat="server" ID="DateAffectationLabel" Text=""></ext:Label></td>
                <td><ext:Button runat="server" ID="ButtonDesaffectation" Text="<%$ Resources:Resource,BtnDesaffecter%>">
                <DirectEvents>
                <Click OnEvent="Desaffectation"></Click>
                </DirectEvents>
                </ext:Button></td>
            </tr>
        </table>
</fieldset>
           </Content>
                            </ext:Panel>
                    
    <ext:GridPanel ID="GridPanel1" runat="server" Title="<%$ Resources:Resource,Vehicules_title_gridpanel1%>" ForceFit="true"
        Border="false" Header="false">
         <%--     Historique d'affectation--%>
        <Store>
            <ext:Store ID="Store1" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model4" runat="server" IDProperty="imei" Name="Boitier">
                        <Fields>
                            <ext:ModelField Name="matricule" />
                            <ext:ModelField Name="imei" />
                            <ext:ModelField Name="date_affectation" />
                            <ext:ModelField Name="date_desaffectation" />
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Vehicules_Matricule%>" DataIndex="matricule" Flex="1" />
                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Vehicules_Imei%>" DataIndex="imei" Flex="1" />
                <ext:Column ID="Column1" runat="server" Text="<%$ Resources:Resource,Vehicules_Date_affectation%>" DataIndex="date_affectation" Flex="1" />
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Vehicules_Date_desaffectation%>" DataIndex="date_desaffectation" Flex="1" />
            </Columns>
        </ColumnModel>
        <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
    </ext:GridPanel>
                </Items>
                </ext:Panel>

                 <%-- Onglet3: Personnel affecté--%>

                <ext:Panel ID="Panel4" runat="server" Title=" <%$ Resources:Resource,Vehicules_title_panel4%>">
     
     <Items>

    <ext:GridPanel ID="GridPanel2" runat="server" ForceFit="true"
        Border="false" Header="false">
        <Store>
            <ext:Store ID="Store6" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh2">
                <Model>
                    <ext:Model ID="Model6" runat="server">
                        <Fields>
                            <ext:ModelField Name="id" />
                            <ext:ModelField Name="matricule" />
                            <ext:ModelField Name="nom" />
                            <ext:ModelField Name="date_affectation" />
                          
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel2" runat="server">
            <Columns>
                <ext:Column ID="Column8" runat="server" Text="Id" DataIndex="id" Hidden="true" />
                <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Vehicules_Matricule%>" DataIndex="matricule" />
                <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Vehicules_nom%>" DataIndex="nom" />
                  <ext:Column ID="Column7" runat="server" Text="<%$ Resources:Resource,Vehicules_Date_affectation%>" DataIndex="date_affectation" />
            <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="Desaffecter" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="DesaffPersonnel(record.data.id);" />
                    </Listeners>
                </ext:CommandColumn> 
            </Columns>
        </ColumnModel>
        
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar2" runat="server" />
            </BottomBar>
    </ext:GridPanel>

          <%--  Affectation courante--%>
          <ext:GridPanel ID="GridPanel3" runat="server" ForceFit="true"
        Border="false" Header="false">
        <Store>
            <ext:Store ID="Store7" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh3">
                <Model>
                    <ext:Model ID="Model7" runat="server">
                        <Fields>
                          
                            <ext:ModelField Name="matricule" />
                            <ext:ModelField Name="nom" />
                            <ext:ModelField Name="date_affectation" />
                          <ext:ModelField Name="date_desaffectation" />
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel3" runat="server">
            <Columns>
            
                <ext:Column ID="Column10" runat="server" Text="<%$ Resources:Resource,Vehicules_Matricule%>" DataIndex="matricule" />
                <ext:Column ID="Column11" runat="server" Text="Nom" DataIndex="nom" />
                  <ext:Column ID="Column12" runat="server" Text="<%$ Resources:Resource,Vehicules_Date_affectation%>" DataIndex="date_affectation" />
           <ext:Column ID="Column9" runat="server" Text="<%$ Resources:Resource,Vehicules_Date_desaffectation%>" DataIndex="date_affectation" /> 
            </Columns>
        </ColumnModel>
        
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar3" runat="server" />
            </BottomBar>
    </ext:GridPanel>

    </Items>
    </ext:Panel>
                </Items>
                </ext:TabPanel>
    </form>
</body>
</html>
