<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarteSim.aspx.cs" Inherits="GeoSI.Website.Modules.CarteSim.CarteSim" %>

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
             
                #{NumeroSerieFilter}.reset();
                #{NumeroTelFilter}.reset();
                #{CodePinFilter}.reset();
                #{CodePukFilter}.reset(); 
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
                        return filterString(#{NumeroSerieFilter}.getValue(), "numero_serie", record);
                    }
                });
                
                f.push({
                    filter: function (record) {                         
                        return filterString(#{NumeroTelFilter}.getValue(), "numero_tel", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{CodePinFilter}.getValue(), "code_pin", record);
                    }
                }); 

                f.push({
                    filter: function (record) {                         
                        return filterString(#{CodePukFilter}.getValue(), "code_puk", record);
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
                        <ext:Model ID="Model1" runat="server" IDProperty="cartesimid">
                            <Fields>
                            <ext:ModelField Name="cartesimid" Type="Int" UseNull="true" />
                            <ext:ModelField Name="numero_serie" />
                            <ext:ModelField Name="numero_tel" />
                            <ext:ModelField Name="code_pin" />
                            <ext:ModelField Name="code_puk" />
                            <ext:ModelField Name="libelle" />
                            </Fields>
                        </ext:Model>
                    </Model>
                </ext:Store>
            </Store>
       <%-- Définition des colonnes du grid --%>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                  <ext:Column ID="Column1" runat="server" Text="Id" DataIndex="cartesimid" Hidden="true" />
                <ext:Column ID="Column2" runat="server" Text="<%$ Resources:Resource,CarteSim_Numero_serie%>" DataIndex="numero_serie">
                    <HeaderItems>
                            <ext:TextField ID="NumeroSerieFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>

                    </ext:Column>
                    

                <ext:Column ID="Column3" runat="server" Text="<%$ Resources:Resource,CarteSim_Numero_tel%>" DataIndex="numero_tel">
                <HeaderItems>
                            <ext:TextField ID="NumeroTelFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>

                <ext:Column ID="Column6" runat="server" text="<%$ Resources:Resource,CarteSim_Code_PIN%>" DataIndex="code_pin">
                <HeaderItems>
                            <ext:TextField ID="CodePinFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                <ext:Column ID="Column8" runat="server" text="<%$ Resources:Resource,CarteSim_Code_PUK%>" DataIndex="code_puk">
                <HeaderItems>
                            <ext:TextField ID="CodePukFilter" runat="server" EnableKeyEvents="true">
                                <Listeners>
                                    <KeyUp Handler="applyFilter(this);" Buffer="250" />                                                
                                </Listeners>
                            </ext:TextField>
                        </HeaderItems>
                </ext:Column>
                    <ext:Column ID="Column4" runat="server" text="<%$ Resources:Resource,CarteSim_OperateurTelecom%>" DataIndex="libelle">
                    <HeaderItems>
                            <ext:ComboBox 
                                ID="ComboBox1" 
                                runat="server"
                                DisplayField="operateur"
                                ValueField="operateur"
                                EnableKeyEvents="true"
                                Editable="false"
                                >
                                <Store>
                                    <ext:Store ID="Store2" runat="server">
                                        <Model>
                                            <ext:Model ID="Model2" runat="server">
                                                <Fields>
                                                    <ext:ModelField Name="operateur" />
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


                <ext:CommandColumn ID="CommandColumn1" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="NoteEdit" CommandName="Edit" Cls="ajax">
                            <ToolTip Text="<%$ Resources:Resource,GridEdit%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="EditLightbox(record.data.cartesimid);" />
                    </Listeners>
                </ext:CommandColumn> 
                  
                <ext:CommandColumn ID="CommandColumn2" runat="server" Width="30">
                    <Commands>
                        <ext:GridCommand Icon="Delete" CommandName="delete">
                            <ToolTip Text="<%$ Resources:Resource,GridDelete%>" />
                        </ext:GridCommand>
                    </Commands>
                    <Listeners>
                        <Command Handler="GridDelete(record.data.cartesimid);" />
                    </Listeners>
                </ext:CommandColumn>    
                               
                </Columns>
            </ColumnModel>
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
