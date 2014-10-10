<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserBackOffice.aspx.cs" Inherits="GeoSI.Website.Modules.UserBackOffice.UserBackOffice" %>

<asp:content id="HeaderContent" runat="server" contentplaceholderid="HeadContent">
    <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript"> //Filtres du grid 
            //Application des filtres    
                                   
            var applyFilter = function (field) {                
                var store = #{GridPanelMaster}.getStore();
                store.filterBy(getRecordFilter());                                                
            };
          
            //Vider les champs des filtres

            var clearFilter = function () {
             
                #{NomFilter}.reset();
                #{PrenomFilter}.reset();
                #{EmailFilter}.reset();
                #{LoginFilter}.reset(); 
                #{TelFilter}.reset(); 
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
                        return filterString(#{NomFilter}.getValue(), "nom", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{PrenomFilter}.getValue(), "prenom", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{EmailFilter}.getValue(), "email", record);
                    }
                }); 
                f.push({
                    filter: function (record) {                         
                        return filterString(#{TelFilter}.getValue(), "tel", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{LoginFilter}.getValue(), "login", record);
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
  <ext:GridPanel ID="GridPanelMaster" runat="server" Layout="FitLayout" ForceFit="true" Border="false" Header="false">
      <%--Définition des éléments du store utilisé dans le grid--%>
        <Store>
                <ext:Store ID="StoreMaster" runat="server" OnReadData="MyData_Refresh" PageSize="10">
                    <Model>
                        <ext:Model ID="Model1" runat="server" IDProperty="userbackofficeid">
                            <Fields>
                            <ext:ModelField Name="userbackofficeid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="nom" />
                            <ext:ModelField Name="prenom" />
                            <ext:ModelField Name="login" />
                            <ext:ModelField Name="email" />
                            <ext:ModelField Name="tel" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
       <%-- Définition des colonnes du grid --%>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                  <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="userbackofficeid" Hidden="true" />
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Utilisateur_Nom%>" DataIndex="nom">
                    <HeaderItems>
                            <ext:TextField ID="NomFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>

                    </ext:Column>
                    

                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Utilisateur_Prenom%>" DataIndex="prenom">
                <HeaderItems>
                            <ext:TextField ID="PrenomFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                    <ext:Column ID="Column6" runat="server" text="<%$ Resources:Resource,Utilisateur_Login%>" DataIndex="login">
                <HeaderItems>
                            <ext:TextField ID="LoginFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                    <ext:Column ID="Column5" runat="server" text="<%$ Resources:Resource,Utilisateur_Email%>" DataIndex="email">
                <HeaderItems>
                            <ext:TextField ID="EmailFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                    <ext:Column ID="Column4" runat="server" text="<%$ Resources:Resource,Utilisateur_Tel%>" DataIndex="tel">
                <HeaderItems>
                            <ext:TextField ID="TelFilter" runat="server" EnableKeyEvents="true">
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
                        <Command Handler="EditLightbox(record.data.userbackofficeid);" />
                    </Listeners>
                </ext:CommandColumn> 
                           <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                         <Command Handler="GridDelete(record.data.userbackofficeid);" />
                    </Listeners>
                </ext:CommandColumn>   
                </Columns>
            </ColumnModel>
            <SelectionModel>
                 <%--    Barre des boutons (ajouter, filterer)--%>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
        </SelectionModel>
             <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" />
            </BottomBar>
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
    </ext:GridPanel>
</asp:content>
