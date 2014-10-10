<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RapportAlerte.aspx.cs" Inherits="GeoSI.Website.Modules.RapportAlerte.RapportAlerte" %>

<asp:content id="HeaderContent" runat="server" contentplaceholderid="HeadContent">
    <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">            //Filtres du grid 
            //Application des filtres                  
            var applyFilter = function (field) {                
                var store = #{GridPanelMaster}.getStore();
                store.filterBy(getRecordFilter());                                                
            };
          
            //Vider les champs des filtres

            var clearFilter = function () {
             
                #{CodeFilter}.reset();
                #{MatriculeFilter}.reset();
                #{ChassisFilter}.reset();
                #{ModeleFilter}.reset();
                #{kilometrageFilter}.reset();
                #{consomationFilter}.reset();
                #{ComboBox1}.reset();
                #{ComboBox2}.reset();
               
                #{StoreMaster}.clearFilter();
            }

            //Méthode pour filtrer un String 
 
            var filterString = function (value, dataIndex, record) {
                var val = record.get(dataIndex);
                
                if (typeof val != "string") {
                    return value.length == 0;
                }
                
                return val.toLowerCase().indexOf(value.toLowerCase()) > -1;
            };
            //Méthode pour filtrer un Number
            var filterNumber = function (value, dataIndex, record) {
                var val = record.get(dataIndex);                
 
                if (!Ext.isEmpty(value, false) && val != value) {
                    return false;
                }
                
                return true;
            };
            //Définition des filtres pour chaque champs du grid 
            var getRecordFilter = function () {
                var f = [];
 
                
                 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{CodeFilter}.getValue(), "code", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{MatriculeFilter}.getValue(), "matricule", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ChassisFilter}.getValue(), "numero_chassis", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ModeleFilter}.getValue(), "modele", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{kilometrageFilter}.getValue(), "kilometrage", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{consomationFilter}.getValue(), "consommation", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "marquevehicule", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox2}.getValue()||"", "typevehicule", record);
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
    </asp:content>
<asp:content id="BodyContent" runat="server" contentplaceholderid="ContentPlaceHolder1">
      <%--Déclaration du grid--%>
    <ext:GridPanel ID="GridPanelMaster" runat="server" Title="<%$ Resources:Resource,Vehicules_title_gridpanelmaster%>"
        Layout="FitLayout" ForceFit="true" Border="false" Header="false">
         <%--Définition des élémznts du store utilisé dans le grid--%>
        <Store>
            <ext:Store ID="StoreMaster" runat="server" PageSize="10" OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model1" runat="server" IDProperty="vehiculeid">
                        <Fields>
                            <ext:ModelField Name="vehiculeid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="imgVehicule" />
                            <ext:ModelField Name="code" />
                            <ext:ModelField Name="matricule" />
                            <ext:ModelField Name="numero_chassis" />
                            <ext:ModelField Name="consommation" />
                            <ext:ModelField Name="kilometrage" />
                            <ext:ModelField Name="modele" />
                            <ext:ModelField Name="marquevehicule" />
                            <ext:ModelField Name="typevehicule" />
                         
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
             <%-- Définition des colonnes du grid --%>
            <Columns>
                <ext:Column ID="Column1" runat="server" Text="VehiculeId" DataIndex="vehiculeid" Hidden="true" />
                   <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                Text="File" 
                                
                                DataIndex="url" 
                                TemplateString='<img style="width:60px;height:45px;" src="../../Ressources/Images/imagesupload/{imgVehicule}" />' 
                                />
                <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Vehicules_Code%>" DataIndex="code">
                <HeaderItems>
                            <ext:TextField ID="CodeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                
                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Vehicules_Matricule%>" DataIndex="matricule">
                <HeaderItems>
                            <ext:TextField ID="MatriculeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Vehicules_Numero_chassis%>" DataIndex="numero_chassis">
                <HeaderItems>
                            <ext:TextField ID="ChassisFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column7" runat="server" Text="<%$ Resources:Resource,Vehicules_Modèle%>" DataIndex="modele">
                <HeaderItems>
                            <ext:TextField ID="ModeleFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Vehicules_consommation%>" DataIndex="consommation">
                <HeaderItems>
                            <ext:TextField ID="consomationFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column9" runat="server" Text="<%$ Resources:Resource,Vehicules_kilometrage%>" DataIndex="kilometrage">
                <HeaderItems>
                            <ext:TextField ID="kilometrageFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column6" runat="server" text="<%$ Resources:Resource,Vehicules_Marque%>" DataIndex="marquevehicule">
                <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                DisplayField="marquevehicule"
                                ValueField="marquevehicule"
                                EnableKeyEvents="true"
                                >
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="marquevehicule" />
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
               

                <ext:Column ID="Column8" runat="server" text="<%$ Resources:Resource,Vehicules_Type_vehicule%>" DataIndex="typevehicule">
                <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox2" 
                                runat="server"
                                DisplayField="typevehicule"
                                ValueField="typevehicule"
                                EnableKeyEvents="true">
                                <Store>
                                    <ext:Store ID="Store3" runat="server">
                                        <Model>
                                            <ext:Model ID="Model3" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="typevehicule" />
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



                                <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="PageWhiteAcrobat" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridPdf%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="ralpdf(record.data.vehiculeid);" />
                    </Listeners>
                </ext:CommandColumn>

                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="PageWhiteExcel" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridExcel%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="ralexcel(record.data.vehiculeid);" />
                    </Listeners>
                </ext:CommandColumn>
 
               
            </Columns>
        </ColumnModel>
 
       
          <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
          <%--    Barre des boutons (ajouter, filterer)--%>
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
                                <Click Handler="clearFilter();" />
                             </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
    </ext:GridPanel>
</asp:content>

