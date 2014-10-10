<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Groupe.aspx.cs" Inherits="GeoSI.Website.Modules.Groupe.Groupe" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
   <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    
   <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">  //Filtres du grid 
            //Application des filtres    
                         
            var applyFilter = function (field) {                
                var store = #{GridPanelMaster}.getStore();
                store.filterBy(getRecordFilter());                                                
            };
            //Vider les champs des filtres
            var clearFilter = function () {
             
                #{libelleFilter}.reset();
                #{parentFilter}.reset();
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

            //Méthode pour filtrer une date
            var filterDate = function (value, dataIndex, record) {
                var val = Ext.Date.clearTime(record.get(dataIndex), true).getTime();
 
                if (!Ext.isEmpty(value, false) && val != Ext.Date.clearTime(value, true).getTime()) {
                    return false;
                }
                return true;
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
                        return filterString(#{libelleFilter}.getValue(), "libelle", record);
                    }
                });
                
              
                f.push({
                    filter: function (record) {                         
                        return filterString(#{parentFilter}.getValue(), "parent", record);
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
      <%--Déclaration du grid--%>
    <ext:GridPanel ID="GridPanelMaster" runat="server"
        Layout="FitLayout" ForceFit="true" Border="false" Header="false">
        <%--Définition des éléments du store utilisé dans le grid--%>
        <Store>
                <ext:Store ID="StoreMaster" runat="server" OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model1" runat="server">
                        <Fields>
                            <ext:ModelField Name="groupeid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="libelle" />
                             <ext:ModelField Name="parent"/>
       
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
         <%-- Définition des colonnes du grid --%>
          <ColumnModel ID="ColumnModel1" runat="server">
            <Columns>
                <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="groupeid" Hidden="true" />
                
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Groupe_libelle%>" DataIndex="libelle">
                <HeaderItems>
                <ext:TextField ID="libelleFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                </ext:TextField>
                </HeaderItems>
                </ext:Column>

               

                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Groupe_Parent%>" DataIndex="parent">
                <HeaderItems>
                            <ext:TextField ID="parentFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                </HeaderItems>
                </ext:Column>

                   <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridEdit%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="EditLightbox(record.data.groupeid);" />
                    </Listeners>
                </ext:CommandColumn>
                 <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                         <Command Handler="GridDelete(record.data.groupeid);" />
                    </Listeners>
                </ext:CommandColumn> 
            </Columns>
           </ColumnModel>
         <%--    Barre des boutons (ajouter, filterer)--%>
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

