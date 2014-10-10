<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Client.aspx.cs" Inherits="GeoSI.Website.Modules.Client.Client" %>

<asp:content id="HeaderContent" runat="server" contentplaceholderid="HeadContent">
    <link href="../../Ressources/Styles/common/colorbox.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/jquery.colorbox.js" type="text/javascript"></script>
    <script src="../../Ressources/Scripts/common/js_common_module.js" type="text/javascript"></script>
     <style type="text/css">        
        .new-row .x-grid-cell{
	        background: #FFE4C4;
        } 
    </style>
      <ext:XScript ID="XScript1" runat="server">
        <script type="text/javascript">            //Filtres du grid 
            var getRowClass = function (record) {
                var r=record.data.raison_sociale;
                
                if (record.data.actif=="0"){
                    return "new-row";
                }
                
           
            }
            //Application des filtres    
                         
            var applyFilter = function (field) {                
                var store = #{GridPanelMaster}.getStore();
                store.filterBy(getRecordFilter());                                                
            };
            //Vider les champs des filtres
            var clearFilter = function () {
                #{raison_socialeFilter}.reset();
                #{sigleFilter}.reset();
                #{emailFilter}.reset();
                #{adresseFilter}.reset(); 
                #{site_webFilter}.reset(); 
                #{capitalFilter}.reset();
                #{annee_creationFilter}.reset();
                #{effectifFilter}.reset(); 
                #{patenteFilter}.reset(); 
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
                        return filterString(#{capitalFilter}.getValue(), "capital", record);
                    }
                });
                
              
                   
                f.push({
                    filter: function (record) {                         
                        return filterString(#{effectifFilter}.getValue(), "effectif", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{patenteFilter}.getValue(), "patente", record);
                    }
                }); 
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
                        return filterString(#{emailFilter}.getValue(), "email", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{adresseFilter}.getValue(), "adresse", record);
                    }
                }); 

                  f.push({
                    filter: function (record) {                         
                        return filterString(#{site_webFilter}.getValue(), "site_web", record);
                    }
                });

                  f.push({
                      filter: function (record) {                         
                          return filterString(#{annee_creationFilter}.getValue(), "annee_creation", record);
                      }
                  });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "profilclient", record);
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
       <script type="text/javascript">




           function ConneteWithClient(id) {

               X.ConneteWithClient(id);
           }
    

    </script>
</asp:content>
<asp:content id="BodyContent" runat="server" contentplaceholderid="ContentPlaceHolder1">
      <%--Déclaration du grid--%>
    <ext:GridPanel ID="GridPanelMaster" runat="server" Layout="FitLayout" ForceFit="true" Border="false"
        Header="false">
       
        <Store>
            <ext:Store ID="StoreMaster" runat="server" RemoteSort="true"  PageSize="10"  OnReadData="MyData_Refresh">
                <Model>
                    <ext:Model ID="Model1" runat="server" IDProperty="clientid">
                        <Fields>
                            <ext:ModelField Name="clientid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="logo" />
                            <ext:ModelField Name="raison_sociale"/>
                            <ext:ModelField Name="sigle" />
                            <ext:ModelField Name="email" />
                            <ext:ModelField Name="site_web" />
                            <ext:ModelField Name="adresse" />
                            <ext:ModelField Name="tel" />
                            <ext:ModelField Name="fax" />
                            <ext:ModelField Name="capital" />
                            <ext:ModelField Name="annee_creation" type="String" />
                            <ext:ModelField Name="identifiant_fiscal" />
                            <ext:ModelField Name="registre_commerce" />
                            <ext:ModelField Name="effectif" />
                            <ext:ModelField Name="cnss" />
                            <ext:ModelField Name="patente" />
                            <ext:ModelField Name="bourse" />
                            <ext:ModelField Name="juridiqueid" />
                            <ext:ModelField Name="profilclientid" />
                            <ext:ModelField Name="paysid" />
                            <ext:ModelField Name="villeid" />
                            <ext:ModelField Name="carte_data" />
                            <ext:ModelField Name="abonnementid" />
                            <ext:ModelField Name="date_expiration" />
                            <ext:ModelField Name="date_desactiv" />
                            <ext:ModelField Name="langueid" />
                            <ext:ModelField Name="cartepardefautid"/>
                            <ext:ModelField Name="profilclient" />
                            <ext:ModelField Name="socite_mere" />
                             <ext:ModelField Name="carte_data" />
                             <ext:ModelField Name="bourse" />
                         </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>
         <%-- Définition des colonnes du grid --%>
        <ColumnModel ID="ColumnModel1"  runat="server">
            <Columns>
                <ext:Column ID="Column1"  runat="server" Text="<%$ Resources:Resource,Client_Id%>" DataIndex="clientid"  Hidden="true"></ext:Column>
                   <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                DataIndex="url" 
                                TemplateString='<img style="width:60px;height:45px;" src="../../Ressources/Images/imagesupload/{logo}" />'  >
                    </ext:TemplateColumn>
                   <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Client_Raison_sociale%>" DataIndex="raison_sociale"> 
                         <HeaderItems>
                            <ext:TextField ID="raison_socialeFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                   <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Client_Sigle%>" DataIndex="sigle" >
                         <HeaderItems>
                            <ext:TextField ID="sigleFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                    </ext:Column>
                <ext:Column ID="Column4" runat="server" Text="<%$ Resources:Resource,Client_Email%>" DataIndex="email" >

                 <HeaderItems>
                            <ext:TextField ID="emailFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Client_Site_Web%>"
                    DataIndex="site_web" >

                     <HeaderItems>
                            <ext:TextField ID="site_webFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column6" runat="server" Text="<%$ Resources:Resource,Client_Adresse%>" DataIndex="adresse">

                         <HeaderItems>
                            <ext:TextField ID="adresseFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column8" runat="server" Text="<%$ Resources:Resource,Client_Capital%>" DataIndex="capital">
                        <HeaderItems>
                            <ext:TextField ID="capitalFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
               <ext:Column ID="Column9" runat="server" Text="<%$ Resources:Resource,Client_Annee_creation%>" DataIndex="annee_creation">
                        <HeaderItems>
                            <ext:TextField ID="annee_creationFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
               <ext:Column ID="Column10" runat="server" Text="<%$ Resources:Resource,Client_Effectif%>" DataIndex="effectif">
                        <HeaderItems>
                            <ext:TextField ID="effectifFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
               <ext:Column ID="Column11" runat="server" Text="<%$ Resources:Resource,Client_Patente%>" DataIndex="patente">
                        <HeaderItems>
                            <ext:TextField ID="patenteFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" ></KeyUp>                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column7" runat="server" Text="<%$ Resources:Resource,Client_Type_Client%>" DataIndex="profilclient" >

                      <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                TriggerAction="All"
                                DisplayField="profilclient"
                                ValueField="profilclient"
                                Editable="false">
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="profilclient" ></ext:ModelField>
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
                        <Command Handler="EditLightbox(record.data.clientid);" ></Command>
                    </Listeners>
                </ext:CommandColumn>
                 <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridDelete(record.data.clientid);" />
                    </Listeners>
                       </ext:CommandColumn>
                     <ext:CommandColumn ID="CommandColumn3" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Accept" CommandName="Activer">
                            <ToolTip Text="<%$ Resources:Resource,GridActiver%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridActiver(record.data.clientid);" />
                    </Listeners>
             

                </ext:CommandColumn>
                       <ext:CommandColumn ID="CommandColumn33" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Connect" CommandName="Connecte">
                          <ToolTip Text="<%$ Resources:Resource,GridConnecte%>" ></ToolTip>
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="ConneteWithClient(record.data.clientid);" />
                    </Listeners>
                </ext:CommandColumn>
            </Columns>
        </ColumnModel>
         <%--    Barre des boutons (ajouter, filterer)--%>
        <SelectionModel>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" ></ext:CheckboxSelectionModel>
        </SelectionModel>
        <TopBar>
                <ext:Toolbar ID="Toolbar1" runat="server">
                    <Items>                        
                        <ext:Button ID="Button1" runat="server" Text="<%$ Resources:Resource,GridAdd%>" Icon="Add">
                          <Listeners>
                            <Click Handler="AddLightbox();" ></Click>
                        </Listeners>   
                        </ext:Button>
                                 
                        <ext:ToolbarFill ID="ToolbarFill1"  runat="server" ></ext:ToolbarFill>            
                        <ext:Button ID="Button3" runat="server" Text="<%$ Resources:Resource,DeleteFiltre%>">
                            <Listeners>
                                <Click Handler="clearFilter(null);" ></Click>
                             </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>

            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1"  runat="server" ></ext:PagingToolbar>
            </BottomBar>
    </ext:GridPanel>
</asp:content>
