<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boitier.aspx.cs" Inherits="GeoSI.Website.Modules.Boitier.Boitier" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">
                         
            var applyFilter = function (field) {                
                var store = #{GridPanelMaster}.getStore();
                store.filterBy(getRecordFilter());                                                
            };
             
            var clearFilter = function () {
             
                #{imeiFilter}.reset();
                //#{GarantieFilter}.reset();
                #{DateAchatFilter}.reset();
                #{DateDebutGarantieFilter}.reset();
                #{DateFinGarantieFilter}.reset();
                #{ComboBox1}.reset();
                #{ComboBox2}.reset();
                #{StoreMaster}.clearFilter();

            }
 
            var filterString = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
                
                if (typeof val != "string") {
                    return value.length == 0;
                }
                
                return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
            };


            var filterDate = function (value, dataIndex, record) {
                var val = Ext.Date.clearTime(record.get(dataIndex), true).getTime();
 
                if (!Ext.isEmpty(value, false) && val != Ext.Date.clearTime(value, true).getTime()) {
                    return false;
                }
                return true;
            };
 
            var filterNumber = function (value, dataIndex, record) {
                var val = record.get(dataIndex);                
 
                if (!Ext.isEmpty(value, false) && val != value) {
                    return false;
                }
                
                return true;
            };
 
 
            var getRecordFilter = function () {
                var f = [];
 
                
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{imeiFilter}.getValue(), "imei", record);
                    }
                });
                
                //f.push({
                //    filter: function (record) {                         
                //        return filterNumber(#{GarantieFilter}.getValue(), "periode_garantie", record);
                //    }
                //}); 
 

                f.push({
                    filter: function (record) {                         
                        return filterDate(#{DateAchatFilter}.getValue(), "date_achat", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterDate(#{DateDebutGarantieFilter}.getValue(), "date_debut_garantie", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterDate(#{DateFinGarantieFilter}.getValue(), "date_fin_garantie", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "libelle", record);
                    }
                });
                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox2}.getValue()||"", "marque_boitier", record);
                    }
                });
 
 
                var len = f.length;
                 
                return function (record) {
                    for (var i = 0; i < len; i++) {
                        if (!f[i].filter(record)) {
                            return false;
                        }
                    }
                    return true;
                };
            };
        </script>
    </ext:XScript>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <ext:GridPanel ID="GridPanelMaster" runat="server"
        Layout="FitLayout" ForceFit="true" Border="false" Header="false">
        <Store>
                <ext:Store ID="StoreMaster" runat="server" OnReadData="MyData_Refresh" PageSize="10">
                <Model>
                    <ext:Model ID="Model1" runat="server">
                        <Fields>
                            <ext:ModelField Name="boitierid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="imei" />
                          <%--  <ext:ModelField Name="periode_garantie" />--%>
                             <ext:ModelField Name="date_debut_garantie" Type="Date"/>
                             <ext:ModelField Name="date_fin_garantie" Type="Date"/>
                            <ext:ModelField Name="marque_boitier" />
                            <ext:ModelField Name="libelle" />
                            <ext:ModelField Name="date_achat" Type="Date"/>
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="boitierid" Hidden="true" />
                
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Boitier_Imei%>" DataIndex="imei">
                <HeaderItems>
                            <ext:TextField ID="imeiFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                </HeaderItems>
                </ext:Column>
                  <ext:DateColumn ID="DateColumn2" runat="server" Text="<%$ Resources:Resource,Boitier_Date_Debut_Garantie%>" DataIndex="date_debut_garantie">
                <HeaderItems>
                            <ext:DateField ID="DateDebutGarantieFilter" runat="server" Editable="false">
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>
                            </ext:DateField>
                        </HeaderItems>
                </ext:DateColumn>
                 <ext:DateColumn ID="DateColumn3" runat="server" Text="<%$ Resources:Resource,Boitier_Date_Fin_Garantie%>" DataIndex="date_fin_garantie">
                <HeaderItems>
                            <ext:DateField ID="DateFinGarantieFilter" runat="server" Editable="false">
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>
                            </ext:DateField>
                        </HeaderItems>
                </ext:DateColumn>
              <%--  <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Boitier_Periode_garantie%>" DataIndex="periode_garantie">
                <HeaderItems>
                            <ext:TextField ID="GarantieFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>--%>
                  <ext:Column ID="Column3" runat="server" text="<%$ Resources:Resource,Boitier_Marque%>" DataIndex="marque_boitier">
                <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox2" 
                                runat="server"
                                TriggerAction="All"
                                DisplayField="marque_boitier"
                                ValueField="marque_boitier"
                                Editable="false">
                                <Store>
                                    <ext:Store ID="Store6" runat="server">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="marque_boitier" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>     
                            </ext:ComboBox>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column6" runat="server" text="<%$ Resources:Resource,Boitier_Type_Boitier%>" DataIndex="libelle">
                <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                TriggerAction="All"
                                DisplayField="boitiertype"
                                ValueField="boitiertype" 
                                Editable="false">
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="boitiertype" />
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>     
                            </ext:ComboBox>
                        </HeaderItems>
                </ext:Column>

                <ext:DateColumn ID="DateColumn1" runat="server" Text="<%$ Resources:Resource,Boitier_Date_Achat%>" DataIndex="date_achat">
                <HeaderItems>
                            <ext:DateField ID="DateAchatFilter" runat="server" Editable="false">
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>
                            </ext:DateField>
                        </HeaderItems>
                </ext:DateColumn>

                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridEdit%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="EditLightbox(record.data.boitierid);" />
                    </Listeners>
                </ext:CommandColumn>

                  <%--<ext:CommandColumn ID="CommandColumn4" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridDelete(record.data.boitierid);" />
                    </Listeners>
                </ext:CommandColumn> --%>

                <ext:CommandColumn ID="CommandColumn3" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Cancel" CommandName="Desactiver">
                            <ToolTip Text="<%$ Resources:Resource,GridDesactiver%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridDesactiver(record.data.boitierid);" />
                    </Listeners>
                </ext:CommandColumn>

                <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridDelete(record.data.boitierid);" />
                    </Listeners>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
        
        <SelectionModel>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
        </SelectionModel>
        
        <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>                        
                        <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,GridAdd%>" Icon="Add">
                         <Listeners>
                            <Click Handler="AddLightbox();" />
                        </Listeners>   
                        </ext:Button>
                                   
                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />            
                        <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Resource,DeleteFiltre%>">
                            <Listeners>
                                <Click Handler="clearFilter(null);" />
                             </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
        
    </ext:GridPanel>
</asp:Content>
