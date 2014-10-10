<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personnel.aspx.cs" Inherits="GeoSI.Website.Modules.Personnel.Personnel" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
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
             
                #{NomFilter}.reset();
                #{PrenomFilter}.reset();
                #{PermisFilter}.reset();
                #{CinFilter}.reset();
                #{CnssFilter}.reset();
                #{DateEmbaucheFilter}.reset();
                #{DateExpirationFilter}.reset();
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
            //Méthode pour filtrer un date
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
                        return filterString(#{PermisFilter}.getValue(), "permis", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{CinFilter}.getValue(), "cin", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{CnssFilter}.getValue(), "cnss", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterDate(#{DateEmbaucheFilter}.getValue(), "date_embauche", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterDate(#{DateExpirationFilter}.getValue(), "date_expiration", record);
                    }
                });

                f.push({
                    filter: function (record) {                         
                        return filterString(#{ComboBox1}.getValue()||"", "libelle", record);
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
      <%--Définition des éléments du store utilisé dans le grid--%>
        <Store>
                <ext:Store ID="StoreMaster" runat="server" OnReadData="MyData_Refresh" PageSize="10">
                    <Model>
                        <ext:Model ID="Model1" runat="server" IDProperty="personnelid">
                            <Fields>
                            <ext:ModelField Name="personnelid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="nom" />
                            <ext:ModelField Name="prenom" />
                            <ext:ModelField Name="permis" />
                            <ext:ModelField Name="cin" />
                            <ext:ModelField Name="cnss" />
                            <ext:ModelField Name="photo" />
                            <ext:ModelField Name="libelle" />
                            <ext:ModelField Name="date_embauche" Type="Date" />
                            <ext:ModelField Name="date_expiration" Type="Date" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
       <%-- Définition des colonnes du grid --%>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                  <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="personnelid" Hidden="true" />

                    <ext:TemplateColumn ID="TemplateColumn1"
                                runat="server"
                                Text="File"              
                                DataIndex="photo" 
                                TemplateString='<img style="width:60px;height:45px;" src="../../Ressources/Images/imagesupload/{photo}" />' 
                                />

                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,Personnel_Nom%>" DataIndex="nom">
                    <HeaderItems>
                            <ext:TextField ID="NomFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>

                    </ext:Column>
                    

                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,Personnel_Prenom%>" DataIndex="prenom">
                <HeaderItems>
                            <ext:TextField ID="PrenomFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column6" runat="server" text="<%$ Resources:Resource,Personnel_Permis%>" DataIndex="permis">
                <HeaderItems>
                            <ext:TextField ID="PermisFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column8" runat="server" text="<%$ Resources:Resource,Personnel_Cin%>" DataIndex="cin">
                <HeaderItems>
                            <ext:TextField ID="CinFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>


                    <ext:Column ID="Column5" runat="server" text="<%$ Resources:Resource,Personnel_Cnss%>" DataIndex="cnss">
                <HeaderItems>
                            <ext:TextField ID="CnssFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>


                    

                    <ext:Column ID="Column4" runat="server" text="<%$ Resources:Resource,Personnel_Typepersonnel%>" DataIndex="libelle">
                    <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                DisplayField="typepersonnel"
                                ValueField="typepersonnel"
                                EnableKeyEvents="true"
                                Editable="false"
                                >
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="typepersonnel" />
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



                    <ext:DateColumn ID="DateColumn1" runat="server" Text="<%$ Resources:Resource,Personnel_Date_Embauche%>" DataIndex="date_embauche">
                <HeaderItems>
                            <ext:DateField ID="DateEmbaucheFilter" runat="server" Editable="false">
                                <Listeners>
                                    <Select Handler="applyFilter(this);" />
                                </Listeners>
                            </ext:DateField>
                        </HeaderItems>
                </ext:DateColumn>

                    <ext:DateColumn ID="DateColumn2" runat="server" Text="<%$ Resources:Resource,Personnel_Date_Expiration%>" DataIndex="date_expiration">
                <HeaderItems>
                            <ext:DateField ID="DateExpirationFilter" runat="server" Editable="false">
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
                        <Command Handler="EditLightbox(record.data.personnelid);" />
                    </Listeners>
                </ext:CommandColumn> 
                          
                    
                 <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                         <Command Handler="GridDelete(record.data.personnelid);" />
                    </Listeners>
                </ext:CommandColumn>    
                </Columns>
            </ColumnModel>
            <SelectionModel>
            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="Multi" />
               
        </SelectionModel>
        <%--    Barre des boutons (ajouter, filterer)--%>
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
</asp:Content>