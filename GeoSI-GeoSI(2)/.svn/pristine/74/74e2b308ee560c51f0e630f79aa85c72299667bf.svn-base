<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.CarteSim.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
</head>
<body>
       <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
 <%-- Onglet1: fiche de détails--%>
    <ext:Label ID="msgErreur" runat="server" Text="" />
         
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
          <%-- Définition des champs de la forme--%>
        <Items>
            <ext:TextField ID="cartesimid" runat="server"  Text="" FieldLabel="id "
                Hidden="true" />
            <ext:TextField ID="numero_serie" runat="server" FieldLabel="<%$ Resources:Resource,CarteSim_Numero_serie%> "
                Width="310" Vtype="num" AllowBlank="false" MaxLength="30"  />
               
            <ext:TextField ID="numero_tel"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,CarteSim_Numero_tel%> "
              AllowBlank="false" MaxLength="15" Vtype="num" />

            <ext:TextField ID="code_pin"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,CarteSim_Code_PIN%> "
                MaxLength="10" Vtype="num" />

            <ext:TextField ID="code_puk"  runat="server" Width="310" FieldLabel="<%$ Resources:Resource,CarteSim_Code_PUK%> "
              MaxLength="20" Vtype="num" />

            <ext:ComboBox ID="operateurid" DisplayField="libelle" Width="310" Editable="false" ValueField="operateurid" runat="server" FieldLabel="<%$ Resources:Resource,CarteSim_OperateurTelecom%> "  AllowBlank="false">
                <Store>
                    <ext:Store ID="Store2" runat="server">
                        <Model>
                            <ext:Model ID="Model2" runat="server">
                                <Fields>
                                    <ext:ModelField Name="operateurid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
            </ext:ComboBox>

            <ext:ComboBox ID="BoitierId" DisplayField="imei" Width="310" MinChars="1" TypeAhead="true"
                ForceSelection="true" ValueField="boitierid" runat="server" FieldLabel="<%$ Resources:Resource,CarteSim_Boitier%> ">
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

            <ext:Button ID="Button2" Type="Submit" runat="server" Text="Enregister"
                Icon="Disk">
                <Listeners>
                    <Click Handler="#{UserForm}.getForm().submit();" />
                </Listeners>
            </ext:Button>
        </Items>
         <%--  Affectation courante--%>
    </ext:FormPanel>
    <fieldset id="divDesaffectation" runat="server" style="border-radius: 5px;">
        <legend style="font-family: Arial; font-size: 13px;">&nbsp; Affectation Courante : &nbsp;</legend>
        <table style="width: 100%;">
            <tr>
                <td>
                    Carte Sim
                </td>
                <td>
                    Boitier
                </td>
                <td>
                    date affectation
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <ext:Label runat="server" ID="numeroserieLabel" Text="">
                    </ext:Label>
                </td>
                <td>
                    <ext:Label runat="server" ID="boitierLabel" Text="">
                    </ext:Label>
                </td>
                <td>
                    <ext:Label runat="server" ID="DateAffectationLabel" Text="">
                    </ext:Label>
                </td>
                <td>
                    <ext:Button runat="server" ID="ButtonDesaffectation" Text="Desaffecter">
                        <DirectEvents>
                            <Click OnEvent="Desaffectation">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </td>
            </tr>
        </table>
    </fieldset>
         <%--  Historique des Affectations --%>
    <ext:GridPanel ID="GridPanel1" runat="server" ForceFit="true" Border="false" Header="false">
        <Store>
            <ext:Store ID="Store1" runat="server" RemoteSort="true" PageSize="10" OnReadData="MyData_Refresh">
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
                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,CarteSim_Numero_tel%> " DataIndex="numero_tel"
                    Flex="1" />
                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,CarteSim_Numero_serie%>" DataIndex="imei" Flex="1" />
                 <ext:Column ID="Column1" runat="server" Text="<%$ Resources:Resource,CarteSim_Date_affectation%> " DataIndex="date_affectation" Flex="1" />
                 <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,CarteSim_Date_desaffectation%> " DataIndex="date_desaffectation" Flex="1" />
            </Columns>
        </ColumnModel>
        <BottomBar>
            <ext:PagingToolbar ID="PagingToolbar1" runat="server">
                <Items>
                    <ext:Label ID="Label2" runat="server" Text="Page size:" />
                    <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                    <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                        <Items>
                            <ext:ListItem Text="1" />
                            <ext:ListItem Text="2" />
                            <ext:ListItem Text="10" />
                            <ext:ListItem Text="20" />
                        </Items>
                        <SelectedItems>
                            <ext:ListItem Value="10" />
                        </SelectedItems>
                        <Listeners>
                            <Select Handler="#{GridPanel1}.store.pageSize = parseInt(this.getValue(), 10); #{GridPanel1}.store.reload();" />
                        </Listeners>
                    </ext:ComboBox>
                </Items>
            </ext:PagingToolbar>
        </BottomBar>
    </ext:GridPanel>
    </form>
</body>
</html>
