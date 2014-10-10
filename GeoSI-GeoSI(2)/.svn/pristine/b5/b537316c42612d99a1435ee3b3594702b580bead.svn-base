<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Utilisateur.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
     <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
    <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
    <style type="text/css">
        #GridPanel1
        {
            float:left;
        }
        #GridPanel2
        {
            float:left;
            margin-left:20px;
        }
       
        #button-1016, #button-1017, #button-1020, #button-1021
        {
            display: none;
        }
    </style>
    <script type="text/javascript">
        //Traitement des champs combobox
        var getDragDropText = function () {
            var buf = [];

            buf.push("<ul>");

            Ext.each(this.view.panel.getSelectionModel().getSelection(), function (record) {
                buf.push("<li>" + record.data.libelle + "</li>");
            });

            buf.push("</ul>");

            return buf.join("");
        };

        function FnSave(grid1, pays, ville,lang) {
            var lignes = "";
            var combopays = pays;
            var comboville = ville;
            var combolang = lang;
            var records = grid1.store.getRange() || [],
            record,
            values = [];
            for (var i = 0; i < records.length; i++) {
                if (lignes.length == 0) {
                    lignes = records[i].data.profilid;
                }
                else {
                    lignes = lignes + ";" + records[i].data.profilid;
                }


            }
            if (combopays == null) { combopays = "0"; }
            if (comboville == null) { comboville = "0"; }
            if (combolang == null) { combolang = "0"; }
            X.MethodeProfil(lignes, combopays, comboville, combolang, {
                success: function (result) {
                    if (result == 1) {
                        parent.location.reload();
                    }
                    else { Ext.Msg.alert('Failure', errorMsg); }
                },

                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });


        }
    </script>
   
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X" />
     <%-- Déclaration de la forme: fiche de détails--%>
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
        <Items>
              <%-- Déclaration des champs--%>
            <ext:TextField ID="utilisateurid" runat="server" Text="" FieldLabel="id "
                Hidden="true" />

            <ext:TextField ID="nom" runat="server" Text="" FieldLabel="<%$ Resources:Resource,Utilisateur_Nom%> " Vtype="chaine" MaxLength="10" AllowBlank="false"/>

            <ext:TextField ID="prenom" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Prenom%> " Vtype="chaine" MaxLength="10"  AllowBlank="false" />

            <ext:TextField ID="email" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Email%> " Vtype="email" MaxLength="30"  AllowBlank="false" />

            <ext:TextField ID="login" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Login%> " Vtype="chainenum" MaxLength="30" />

            <ext:TextField ID="pwd" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Password%> " Vtype="chainenum" MaxLength="30 " InputType="Password" />

            <ext:TextField ID="tel" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Tel%> " Vtype="num" MaxLength="10"  AllowBlank="false" />

            <ext:TextArea ID="adresse" runat="server" Text=""  FieldLabel="<%$ Resources:Resource,Utilisateur_Adresse%> " Width="500" Height="60"  AllowBlank="false" />

             <ext:ComboBox ID="langueid" DisplayField="libelle" Editable="false" Width="310" ValueField="langueid"
                runat="server" FieldLabel="<%$ Resources:Resource,Utilisateur_Langue%>" >
                <Store>
                    <ext:Store ID="StoreComboboxlangue" runat="server">
                        <Model>
                            <ext:Model ID="Model5" runat="server">
                                <Fields>
                                    <ext:ModelField Name="langueid" />
                                    <ext:ModelField Name="libelle" />
                                </Fields>
                            </ext:Model>
                        </Model>
                    </ext:Store>
                </Store>
                 <Triggers>
                    <ext:FieldTrigger Icon="Clear" HideTrigger="false" ></ext:FieldTrigger>
                </Triggers>
                <Listeners>
                    <TriggerClick Handler="this.setValue('');" ></TriggerClick>
                </Listeners>
            </ext:ComboBox>

            <ext:ComboBox ID="paysid"
        runat="server"
        Editable="false"
        ValueField="paysid"
        DisplayField="pays"
        FieldLabel="Pays "
        >
       
        <Store>
            <ext:Store
                runat="server"
                ID="Store3"
                >              
                <Model>
                    <ext:Model ID="Model3" runat="server">
                        <Fields>
                            <ext:ModelField Name="paysid" />
                            <ext:ModelField Name="pays" />
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
            </Store>
        <Listeners>
            <Select Handler="#{villeid}.clearValue(); #{CitiesStore}.reload();" />
        </Listeners>       
       
    </ext:ComboBox>
   
    <ext:ComboBox
        ID="villeid"
        runat="server"     
        ValueField="villeid"
        DisplayField="ville"
        FieldLabel="Ville "
        >
        <Store>
            <ext:Store
                runat="server"
                ID="CitiesStore"
                OnReadData="CitiesRefresh"
                >              
                <Model>
                    <ext:Model ID="Model4" runat="server" IDProperty="villeid">
                        <Fields>
                            <ext:ModelField Name="villeid" Type="int" />
                            <ext:ModelField Name="ville" Type="String" />
                        </Fields>
                    </ext:Model>
                </Model>
            </ext:Store>
        </Store>   
    </ext:ComboBox>
<ext:Panel ID="Panel1" runat="server" Width="622" Border="false" BodyStyle="background-color:#F1F1F1;">
    <Items>
           <ext:GridPanel
                    ID="GridPanel1"
                    runat="server"
                    MultiSelect="true"
                    Scroll="Vertical"
                    Header="false"
                    Width="300"
                    Height="300"                  
                    >
                    <Store>
                        <ext:Store  ID="Store1" runat="server">
                            <Model>
                                <ext:Model ID="Model1" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="profilid" />
                                        <ext:ModelField Name="libelle" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>

                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column1" runat="server"  DataIndex="profilid" Hidden="true" />
                            <ext:Column ID="Column2" runat="server" Text=" <%$ Resources:Resource,Utilisateur_ProfilSelectionne%>" DataIndex="libelle" Width="300" />
                        </Columns>
                    </ColumnModel>                   
                    <View>
                        <ext:GridView ID="GridView1" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop1" runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>
                <ext:GridPanel
                    ID="GridPanel2"
                    runat="server"
                    MultiSelect="true"
                    Header="false"
                     Width="300"
                    Height="300"
                    Scroll="Vertical"
                   
                    >
                    <Store>
                        <ext:Store ID="Store2" runat="server">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="profilid" />
                                        <ext:ModelField Name="libelle" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column4" runat="server" DataIndex="profilid" Hidden="true" />
                            <ext:Column ID="Column5" runat="server" Text="<%$ Resources:Resource,Utilisateur_Profil%> " DataIndex="libelle" Width="300" />
                        </Columns>
                    </ColumnModel>                  
                    <View>
                        <ext:GridView ID="GridView2" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop2" runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>
        </Items>
        </ext:Panel>
            <ext:Button ID="Button2" Type="Submit" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk">
                <Listeners>
                    <Click Handler="FnSave(#{GridPanel1},#{paysid}.getValue(),#{villeid}.getValue(),#{langueid}.getValue());" />
                  
                </Listeners>
            </ext:Button>
        </Items>
    </ext:FormPanel>
    </form>
</body>
</html>