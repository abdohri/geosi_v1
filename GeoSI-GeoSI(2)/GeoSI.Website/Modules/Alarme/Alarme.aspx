<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Alarme.aspx.cs" Inherits="GeoSI.Website.Modules.Alarme.Alarme" %>



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
                        return filterString(#{CodeFilter}.getValue(), "idNoti", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{MatriculeFilter}.getValue(), "imgVehicule", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ChassisFilter}.getValue(), "libelle", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ModeleFilter}.getValue(), "matricule", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{kilometrageFilter}.getValue(), "titre", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{consomationFilter}.getValue(), "Descriptione", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "DateAlert", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox2}.getValue()||"", "Vu", record);
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
    <ext:GridPanel ID="GridPanelMaster" runat="server" Title="Alarme"
        Layout="FitLayout" ForceFit="true" Border="false" Header="false">
         <%--Définition des élémznts du store utilisé dans le grid--%>
        <Store>
            <ext:Store ID="StoreMaster" runat="server" PageSize="14" OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model1" runat="server" IDProperty="idNoti">
                        <Fields>
                            <ext:ModelField Name="idNoti" Type="Int" />
                            <ext:ModelField Name="imgVehicule" />
                            <ext:ModelField Name="libelle" />
                            <ext:ModelField Name="matricule" />
                            <ext:ModelField Name="titre" />
                            <ext:ModelField Name="DateAlert" />
                            <ext:ModelField Name="Descriptione" />
                            <ext:ModelField Name="Vu" />
                         
                         
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
        <ColumnModel ID="ColumnModel1" runat="server">
             <%-- Définition des colonnes du grid --%>
            <Columns>
                <ext:Column ID="Column1" runat="server" Text="Reference Alarme" DataIndex="idNoti" />
                   <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                Text="Image" 
                                
                                DataIndex="url" 
                                TemplateString='<img style="width:60px;height:45px;" src="../../Ressources/Images/imagesupload/{imgVehicule}" />' 
                                />
                <ext:Column ID="Column5" runat="server" Text="Marque" DataIndex="libelle">
                <HeaderItems>
                            <ext:TextField ID="CodeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                
                <ext:Column ID="Column3" runat="server" Text="matricule" DataIndex="matricule">
                <HeaderItems>
                            <ext:TextField ID="MatriculeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column2" runat="server" Text="Type Alarme" DataIndex="titre">
                <HeaderItems>
                            <ext:TextField ID="ChassisFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column7" runat="server" Text="Description" DataIndex="Descriptione">
                <HeaderItems>
                            <ext:TextField ID="ModeleFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column4" runat="server" Text="Date Alarme" DataIndex="DateAlert">
                <HeaderItems>
                            <ext:TextField ID="consomationFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                
                  

                <ext:Column ID="Column9" runat="server" Text="Vu" DataIndex="Vu">
                <HeaderItems>
                            <ext:TextField ID="kilometrageFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                 <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="vu" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="UpdateVue(record.data.idNoti);" />
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
