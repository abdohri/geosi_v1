<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Boitier.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
   <%-- <ext:XScript ID="XScript2" runat="server">
        <script type="text/javascript">

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
    </ext:XScript>--%>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:Viewport ID="Viewport1" runat="server" Layout="FitLayout" Cls="test">
        <Items>
    <ext:TabPanel ID="TabPanel1" 
            runat="server" 
            DeferredRender="false">
            <Items>
            <ext:Panel ID="Panel1" runat="server" Title=" <%$ Resources:Resource,Boitier_title_panel1%>">
            <Items>
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
            <ext:TextField ID="boitierid" runat="server" Text="" FieldLabel="id " Hidden="true" />
           
            <ext:TextField ID="imei" runat="server" FieldLabel="<%$ Resources:Resource,Boitier_Imei%> " Width="310" Vtype="chainenum"
             AllowBlank="false" MaxLength="30" />

          <%--  <ext:TextField ID="periode_garantie"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,Boitier_Periode_garantie%> "
                 Vtype="num" MaxLength="3" />--%>
             <ext:DateField ID="date_debut_garantie" 
                  runat="server" 
                 Width="310"  

                  EnableKeyEvents="true" 
                 FieldLabel="<%$ Resources:Resource,Boitier_Date_Debut_Garantie%> " >
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
                <%-- <CustomConfig>
                        <ext:ConfigItem Name="endDateField" Value="date_fin_garantie" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners>--%>
            </ext:DateField>


                  <ext:DateField ID="date_fin_garantie" 
                       runat="server" 
                      Width="310"
                     
                      EnableKeyEvents="true"
                      FieldLabel="<%$ Resources:Resource,Boitier_Date_Fin_Garantie%> " >
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
                
<%--                       <CustomConfig>
                        <ext:ConfigItem Name="startDateField" Value="date_debut_garantie" Mode="Value" />
                    </CustomConfig>
                    <Listeners>
                        <KeyUp Fn="onKeyUp" />
                    </Listeners> --%>
            </ext:DateField>


            <ext:DateField ID="date_achat"  
                runat="server"
                 Width="310"
                  FieldLabel="<%$ Resources:Resource,Boitier_Date_Achat%> " >
                <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
      
            </ext:DateField>
            <ext:ComboBox ID="marque_boitierid" DisplayField="marque_boitier" Width="310" Editable="false" ValueField="marque_boitierid" runat="server" FieldLabel="<%$ Resources:Resource,Boitier_Marque%>">
                <Store>
                    <ext:Store ID="Store6" runat="server">
                        <Model>
                            <ext:Model ID="Model6" runat="server">
                                <Fields>
                                    <ext:ModelField Name="marque_boitierid" />
                                    <ext:ModelField Name="marque_boitier" />
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


            <ext:ComboBox ID="typeboitierid" DisplayField="libelle" Width="310" Editable="false" ValueField="typeboitierid" runat="server" FieldLabel="<%$ Resources:Resource,Boitier_Type_Boitier%>">
                <Store>
                    <ext:Store ID="Store2" runat="server">
                        <Model>
                            <ext:Model ID="Model2" runat="server">
                                <Fields>
                                    <ext:ModelField Name="typeboitierid" />
                                    <ext:ModelField Name="libelle" />
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

            <ext:ComboBox ID="cartesimid" DisplayField="numero_tel" Width="310" MinChars="1" TypeAhead="true" 
                ForceSelection="true" ValueField="cartesimid" runat="server" FieldLabel="<%$ Resources:Resource,Boitier_Carte_Sim%>">
                <Store>
                    <ext:Store ID="Store3" runat="server">
                        <Model>
                            <ext:Model ID="Model3" runat="server">
                                <Fields>
                                    <ext:ModelField Name="cartesimid" />
                                    <ext:ModelField Name="numero_tel" />
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

            <ext:ComboBox ID="vehiculeid" DisplayField="matricule" Width="310" MinChars="1" TypeAhead="true"
                ForceSelection="true" ValueField="vehiculeid" runat="server" FieldLabel="<%$ Resources:Resource,Boitier_Vehiculeid%>">
                <Store>
                    <ext:Store ID="Store4" runat="server">
                        <Model>
                            <ext:Model ID="Model1" runat="server">
                                <Fields>
                                    <ext:ModelField Name="vehiculeid" />
                                    <ext:ModelField Name="matricule" />
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
    

            <ext:ComboBox ID="clientid" DisplayField="raison_sociale" Width="310" MinChars="1" TypeAhead="true"
                ForceSelection="true" ValueField="clientid" runat="server" FieldLabel="Client">
                <Store>
                    <ext:Store ID="Store7" runat="server">
                        <Model>
                            <ext:Model ID="Model7" runat="server">
                                <Fields>
                                    <ext:ModelField Name="clientid" />
                                    <ext:ModelField Name="raison_sociale" />
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


            <ext:Button ID="Button2" Type="Submit" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk">
                <Listeners>
                    <Click Handler="#{UserForm}.getForm().submit();" />
                </Listeners>
            </ext:Button>
        </Items>
    </ext:FormPanel>
    </Items>
    </ext:Panel>

     <ext:Panel ID="Panel2" runat="server" Title=" <%$ Resources:Resource,Boitier_title_panel2%>">
     
     <Items>
     
 <ext:Panel ID="Panel3" runat="server" Header="false" Border="false" >
     <Content>
      <fieldset id="divDesaffectation" runat="server" style="border-radius:5px;">
<legend style="font-family:Arial;font-size:13px;">&nbsp;affectation courante: &nbsp;</legend>
<table style="width:100%;">
            <tr>
                <td>
                  Carte SIM</td>
                <td>
                    Boitier</td>
                <td> Date affectation</td>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="numerotelLabel" Text=""></ext:Label></td>
                <td><ext:Label runat="server" ID="boitierLabel" Text=""></ext:Label></td>
                <td><ext:Label runat="server" ID="DateAffectationLabel" Text=""></ext:Label></td>
                <td><ext:Button runat="server" ID="ButtonDesaffectation" Text="<%$ Resources:Resource,BtnDesaffecter%> " Width="100" Height="20">
                <DirectEvents>
                <Click OnEvent="Desaffectation"></Click>
                </DirectEvents>
                </ext:Button></td>
            </tr>
        </table>
</fieldset>
</Content>
</ext:Panel>
    <ext:GridPanel ID="GridPanel1" runat="server" ForceFit="true"
        Border="false" Header="false">
        <Store>
            <ext:Store ID="Store1" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh1">
                <Model>
                    <ext:Model ID="Model4" runat="server">
                        <Fields>
                            <ext:ModelField Name="numero_tel" />
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
                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Boitier_Numero_Tel%>" DataIndex="numero_tel" />
                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Boitier_Imei%>" DataIndex="imei" />
                 <ext:Column ID="Column7" runat="server" Text="<%$ Resources:Resource,Boitier_Date_affectation%>" DataIndex="date_affectation" />
                <ext:Column ID="Column8" runat="server" Text="<%$ Resources:Resource,Boitier_Date_desaffectation%>" DataIndex="date_desaffectation" />
            </Columns>
        </ColumnModel>

        <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
                </ext:GridPanel>
    </Items>
    </ext:Panel>


    <ext:Panel ID="Panel4" runat="server" Title=" <%$ Resources:Resource,Boitier_title_panel4%>">
     
     <Items>
     
 <ext:Panel ID="Panel5" runat="server" Header="false" Border="false" >
     <Content>
      <fieldset id="Fieldset1" runat="server" style="border-radius:5px;">
<legend style="font-family:Arial;font-size:13px;"> affectation courante: &nbsp;</legend>
<table style="width:100%;">
            <tr>
                <td>
                    Matricule</td>
                <td>
                    Boitier</td>
                <td> Date affectation</td>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td><ext:Label runat="server" ID="MatriculeLabel" Text=""></ext:Label></td>
                <td><ext:Label runat="server" ID="BoitierLabelVehicule" Text=""></ext:Label></td>

                <td><ext:Label runat="server" ID="DateAffectationLabelVehicule" Text=""></ext:Label></td>
                <td><ext:Button runat="server" ID="ButtonDesaffectationVehicule" Text=" <%$ Resources:Resource,BtnDesaffecter%>" Width="100" Height="20">
                <DirectEvents>
                <Click OnEvent="DesaffectationVehicule"></Click>
                </DirectEvents>
                </ext:Button></td>
            </tr>
        </table>
</fieldset>
</Content>
</ext:Panel>
    <ext:GridPanel ID="GridPanel2" runat="server" ForceFit="true"
        Border="false" Header="false">
        <Store>
            <ext:Store ID="Store5" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh2">
                <Model>
                    <ext:Model ID="Model5" runat="server">
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
        <ColumnModel ID="ColumnModel2" runat="server">
            <Columns>
                <ext:Column ID="Column1" runat="server" Text="<%$ Resources:Resource,Boitier_Matricule%>" DataIndex="matricule" />
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Boitier_Imei%>" DataIndex="imei" />
                  <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Boitier_Date_affectation%>" DataIndex="date_affectation" />
                <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Boitier_Date_desaffectation%>" DataIndex="date_desaffectation" />
            </Columns>
        </ColumnModel>
        
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar2" runat="server" />
            </BottomBar>
    </ext:GridPanel>
    </Items>
    </ext:Panel>
    

    </Items>
    </ext:TabPanel>
    </Items>
    </ext:Viewport>
    </form>
</body>
</html>

