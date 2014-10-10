<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Utilisateur.aspx.cs" Inherits="GeoSI.Website.Modules.Utilisateur.Utilisateur" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
    <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">    //Filtres du grid 
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
                #{adresseFilter}.reset(); 
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
                        return filterString(#{Prenomfilter}.getValue(), "prenom", record);
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
                        return filterString(#{adresseFilter}.getValue(), "adresse", record);
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

</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">

      <%--Déclaration du grid--%>
  <ext:GridPanel ID="GridPanelMaster" runat="server" Layout="FitLayout" ForceFit="true" Border="false" Header="false">
        <Store>
            <%--Définition des élémznts du store utilisé dans le grid--%>
                <ext:Store ID="StoreMaster" runat="server" OnReadData="MyData_Refresh" PageSize="10">
                    <Model>
                        <ext:Model ID="Model1" runat="server" IDProperty="utilisateurid">
                            <Fields>
                            <ext:ModelField Name="utilisateurid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="nom" />
                            <ext:ModelField Name="prenom" />
                            <ext:ModelField Name="login" />
                            <ext:ModelField Name="email" />
                            <ext:ModelField Name="tel" />
                            <ext:ModelField Name="adresse" />
                            <ext:ModelField Name="langueid" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <%-- Définition des colonnes du grid --%>
                <Columns>
                  <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="cartesimid" Hidden="true" />
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

                    <ext:Column ID="Column5" runat="server" text="<%$ Resources:Resource,Utilisateur_Email%>" DataIndex="email">
                <HeaderItems>
                            <ext:TextField ID="EmailFilter" runat="server" EnableKeyEvents="true">
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

                    <ext:Column ID="Column4" runat="server" text="<%$ Resources:Resource,Utilisateur_Tel%>" DataIndex="tel">
                <HeaderItems>
                            <ext:TextField ID="TelFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                    <ext:Column ID="Column7" runat="server" text="<%$ Resources:Resource,Utilisateur_Adresse%>" DataIndex="adresse">
                <HeaderItems>
                            <ext:TextField ID="adresseFilter" runat="server" EnableKeyEvents="true">
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
                        <Command Handler="EditLightbox(record.data.utilisateurid);" />
                    </Listeners>
                </ext:CommandColumn> 
                           <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                            <Commands>
                                <ext:GridCommand Icon="Delete" CommandName="delete">
                                    <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                                </ext:GridCommand>
                            </Commands>
                            <Listeners>
                                <Command Handler="GridDelete(record.data.utilisateurid);" />
                            </Listeners>
                        </ext:CommandColumn>   
                </Columns>
            </ColumnModel>
            <SelectionModel>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
        </SelectionModel>
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
                                <Click Handler="clearFilter(null);" />
                             </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
    </ext:GridPanel>
</asp:Content>
