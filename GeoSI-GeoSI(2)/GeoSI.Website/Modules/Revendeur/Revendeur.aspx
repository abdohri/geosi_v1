<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Revendeur.aspx.cs" Inherits="GeoSI.Website.Modules.Revendeur.Revendeur" %>

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
                #{raison_socialeFilter}.reset();
                #{loginFilter}.reset();
                #{sigleFilter}.reset();
                #{emailFilter}.reset();
                #{adresseFilter}.reset(); 
                #{site_webFilter}.reset(); 
                #{ComboBox1}.reset();
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
                        return filterString(#{raison_socialeFilter}.getValue(), "raison_sociale", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{sigleFilter}.getValue(), "sigle", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{LoginFilter}.getValue(), "login", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{emailFilter}.getValue(), "email", record);
                    }
                });                 
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{site_webFilter}.getValue(), "site_web", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{adresseFilter}.getValue(), "adresse", record);
                    }
                }); 



                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "langue", record);
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
    <ext:GridPanel ID="GridPanelMaster" runat="server" Layout="FitLayout" ForceFit="true" Border="false"
        Header="false">
        <%--Définition des éléments du store utilisé dans le grid--%>
        <Store>
            <ext:Store ID="StoreMaster" runat="server" RemoteSort="true" AutoSync="true" PageSize="10"
                OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model1" runat="server" IDProperty="revendeurid">
                        <Fields>
                            <ext:ModelField Name="revendeurid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="raison_sociale" />
                            <ext:ModelField Name="sigle" />
                            <ext:ModelField Name="login" />
                            <ext:ModelField Name="logo" />
                            <ext:ModelField Name="site_web" />
                            <ext:ModelField Name="email" />
                            <ext:ModelField Name="adresse" />
                            <ext:ModelField Name="langue" />

                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
         <%-- Définition des colonnes du grid --%>
           <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
               
                <ext:Column ID="Column1"  runat="server" Text="<%$ Resources:Resource,Revendeur_Id%>" DataIndex="clientid"  Hidden="true" >
                </ext:Column>
                <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                Text="File" 
                                DataIndex="url" 
                                TemplateString='<img style="width:60px;height:45px;" src="../../Ressources/Images/imagesupload/{logo}" />' >
                </ext:TemplateColumn>
                 <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Revendeur_Raison_sociale%>" DataIndex="raison_sociale">
                         <HeaderItems>
                            <ext:TextField ID="raison_socialeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column8" runat="server" Text="<%$ Resources:Resource,Revendeur_Login%>"
                    DataIndex="login"    > 
                        <HeaderItems>
                            <ext:TextField ID="LoginFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Revendeur_Sigle%>"
                    DataIndex="sigle"  >   
                         <HeaderItems>
                            <ext:TextField ID="sigleFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Revendeur_Email%>" DataIndex="email">
                      <HeaderItems>
                            <ext:TextField ID="emailFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Revendeur_Site_Web%>"
                    DataIndex="site_web">
                        <HeaderItems>
                            <ext:TextField ID="site_webFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Revendeur_Adresse%>" DataIndex="adresse">
               
                         <HeaderItems>
                            <ext:TextField ID="adresseFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column7" runat="server" Text="<%$ Resources:Resource,Revendeur_Langue%>"
                    DataIndex="langue" >
                     <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                TriggerAction="All"
                                DisplayField="langue"
                                ValueField="langue"
                                Editable="false">
                                <Store>
                                    <ext:Store ID="StoreLangue" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="langue" ></ext:ModelField>
                                                </Fields>
                                            </ext:Model>
                                        </Model>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Select Handler="applyFilter(this);" ></Select>
                                </Listeners>     
                            </ext:ComboBox>
                        </HeaderItems>
                </ext:Column>
                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridEdit%>" ></ToolTip>
                        </ext:GridCommand>

                    </Commands>
                    <Listeners>
                        <Command Handler="EditLightbox(record.data.revendeurid);" ></Command>
                    </Listeners>
                </ext:CommandColumn>
                <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                         <Command Handler="GridDelete(record.data.revendeurid);" />
                    </Listeners>
                </ext:CommandColumn>    
            </Columns>
        </ColumnModel>
        <SelectionModel>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" >
            </ext:CheckboxSelectionModel>
        </SelectionModel>
        <Plugins>
            <ext:CellEditing ID="CellEditing1" runat="server">
            </ext:CellEditing>
        </Plugins>
         <%--    Barre des boutons (ajouter, filterer)--%>
       <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>                        
                        <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,GridAdd%>" Icon="Add">
                          <Listeners>
                            <Click Handler="AddLightbox();"></Click>
                        </Listeners>   
                        </ext:Button>
                                
                        <ext:ToolbarFill ID="ToolbarFill1"  runat="server" >
                        </ext:ToolbarFill>           
                        <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Resource,DeleteFiltre%>">
                            <Listeners>
                                <Click Handler="clearFilter(null);" ></Click>
                             </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
           </TopBar>
           <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1"  runat="server" >
                </ext:PagingToolbar>
           </BottomBar>
    </ext:GridPanel>
</asp:content>
