<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GeoForm.aspx.cs" Inherits="GeoSI.Website.Modules.Profil.GeoForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />

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
         #GridPanel3
        {
            float:left;
        }
        #GridPanel4
        {
            float:left;
            margin-left:20px;
        }
         #GridPanel5
        {
            float:left;
        }
        #GridPanel6
        {
            float:left;
            margin-left:20px;
        }
         #GridPanel7
        {
            float:left;
        }
        #GridPanel8
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
        //
        var getDragDropText = function ()
        {
            var buf = [];
            buf.push("<ul>");
            Ext.each(this.view.panel.getSelectionModel().getSelection(), function (record)
            {
                buf.push("<li>" + record.data.libelle + "</li>");
            });
            buf.push("</ul>");
            return buf.join("");
        };
        //
        function FnSave(grid1,grid2,grid3,grid4)
        {
            var lignesH = "";
            var lignesG = "";
            var lignesV = "";
            var lignesA = "";
            //Récupération des Habilitations sélectionnées
            var records = grid1.store.getRange() || [],
            record,
            values = [];
            for (var i = 0; i < records.length; i++)
            {
                if (lignesH.length == 0)
                {
                    lignesH = records[i].data.habilitationid;
                }
                else
                {
                    lignesH = lignesH + ";" + records[i].data.habilitationid;
                }
            }
            //Récupération des alertes sélectionnées
            var recordsA = grid4.store.getRange() || [],
            record,
            values = [];
            for (var i = 0; i < recordsA.length; i++)
            {
                if (lignesA.length == 0)
                {
                    lignesA = recordsA[i].data.alerteid;
                }
                else
                {
                    lignesA = lignesA + ";" + recordsA[i].data.alerteid;
                }
            }
            //Récupération des Groupes sélectionnés
            var recordsG = grid2.store.getRange() || [],
          record,
          values = [];
            for (var i = 0; i < recordsG.length; i++) {
                if (lignesG.length == 0) {
                    lignesG = recordsG[i].data.groupeid;
                }
                else {
                    lignesG = lignesG + ";" + recordsG[i].data.groupeid;
                }
            }
            //Récupération des Vehicules sélectionnés
            var recordsV = grid3.store.getRange() || [],
         record,
         values = [];
            for (var i = 0; i < recordsV.length; i++) {
                if (lignesV.length == 0) {
                    lignesV = recordsV[i].data.vehiculeid;
                }
                else {
                    lignesV = lignesV + ";" + recordsV[i].data.vehiculeid;
                }
            }
            //appel MethodeProfil
            X.MethodeProfil(lignesH,lignesG,lignesV,lignesA, {
                success: function (result)
                {
                    if (result == 1)
                    {
                        parent.location.reload();
                    }
                    else
                    {
                        Ext.Msg.alert('Failure', errorMsg);
                    }
                },

                failure: function (errorMsg)
                {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
    </script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X" />
    <ext:Label ID="msgErreur" runat="server" Text="" />
             <%--Onglet: fiche détail--%>
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="GeoForm.aspx"
        Method="POST">
         <%-- Définition des champs de la forme--%>
        <Items>
            <ext:TextField ID="profilid" runat="server" Name="profilid" Text="" FieldLabel="profilid "
                Hidden="true" />
            <ext:TextField ID="libelle" runat="server" FieldLabel="<%$ Resources:Resource,Profil_libelle%>"
                Name="libelle" Vtype="chainenume" MaxLength="20" Width="310" >
            </ext:TextField>
            <ext:TextArea ID="description" runat="server" Height="50" Width="400" FieldLabel="<%$ Resources:Resource,Profil_description%>"
                MsgTarget="Side" Vtype="chainenume" MaxLength="100">
            </ext:TextArea>
           
            <%--affectation / désaffectaion habilitations--%>
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
                                        <ext:ModelField Name="habilitationid" />
                                        <ext:ModelField Name="action" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>

                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column1" runat="server"  DataIndex="habilitationid" Hidden="true" />
                            <ext:Column ID="Column2" runat="server" Text=" <%$ Resources:Resource,Profil_Habilitation_selectionnees%>" DataIndex="action" Width="300" />
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
                    Scroll="Vertical" >
                    <Store>
                        <ext:Store ID="Store2" runat="server">
                            <Model>
                                <ext:Model ID="Model2" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="habilitationid" />
                                        <ext:ModelField Name="action" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column4" runat="server" DataIndex="habilitationid" Hidden="true" />
                            <ext:Column ID="Column5" runat="server" Text=" <%$ Resources:Resource,Profil_Liste_Habilitation%> " DataIndex="action" Width="300" />
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

            <%-- affectation / désaffectation groupe --%>
             <ext:Panel ID="Panel2" runat="server" Width="622" Border="false" BodyStyle="background-color:#F1F1F1;">
    <Items>
           <ext:GridPanel
                    ID="GridPanel3"
                    runat="server"
                    MultiSelect="true"
                    Scroll="Vertical"
                    Header="false"
                    Width="300"
                    Height="300"                  
                    >
                    <Store>
                        <ext:Store  ID="Store3" runat="server">
                            <Model>
                                <ext:Model ID="Model3" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="groupeid" />
                                        <ext:ModelField Name="libelle" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>

                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column3" runat="server"  DataIndex="groupeid" Hidden="true" />
                            <ext:Column ID="Column6" runat="server" Text=" <%$ Resources:Resource,Profil_Groupe_selectionnes%>" DataIndex="libelle" Width="300" />
                        </Columns>
                    </ColumnModel>                   
                    <View>
                        <ext:GridView ID="GridView3" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop3" runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>

                <ext:GridPanel
                    ID="GridPanel4"
                    runat="server"
                    MultiSelect="true"
                    Header="false"
                     Width="300"
                    Height="300"
                    Scroll="Vertical" >
                    <Store>
                        <ext:Store ID="Store4" runat="server">
                            <Model>
                                <ext:Model ID="Model4" runat="server">
                                    <Fields>
                                          <ext:ModelField Name="groupeid" />
                                        <ext:ModelField Name="libelle" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column7" runat="server" DataIndex="groupeid" Hidden="true" />
                            <ext:Column ID="Column8" runat="server" Text=" <%$ Resources:Resource,Profil_Liste_Groupes%> " DataIndex="libelle" Width="300" />
                        </Columns>
                    </ColumnModel>                  
                    <View>
                        <ext:GridView ID="GridView4" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop4" runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup"/>
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
            <%-- affectation / désaffectation véhicule --%>
             <ext:Panel ID="Panel3" runat="server" Width="622" Border="false" BodyStyle="background-color:#F1F1F1;">
    <Items>
           <ext:GridPanel
                    ID="GridPanel5"
                    runat="server"
                    MultiSelect="true"
                    Scroll="Vertical"
                    Header="false"
                    Width="300"
                    Height="300"                  
                    >
                    <Store>
                        <ext:Store  ID="Store5" runat="server">
                            <Model>
                                <ext:Model ID="Model5" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="vehiculeid" />
                                        <ext:ModelField Name="matricule" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>

                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column9" runat="server"  DataIndex="vehiculeid" Hidden="true" />
                            <ext:Column ID="Column10" runat="server" Text=" <%$ Resources:Resource,Profil_Vehicule_selectionnes%>" DataIndex="matricule" Width="300" />
                        </Columns>
                    </ColumnModel>                   
                    <View>
                        <ext:GridView ID="GridView5" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop5" runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>

                <ext:GridPanel
                    ID="GridPanel6"
                    runat="server"
                    MultiSelect="true"
                    Header="false"
                     Width="300"
                    Height="300"
                    Scroll="Vertical" >
                    <Store>
                        <ext:Store ID="Store6" runat="server">
                            <Model>
                                <ext:Model ID="Model6" runat="server">
                                    <Fields>
                                          <ext:ModelField Name="vehiculeid" />
                                        <ext:ModelField Name="matricule" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column11" runat="server" DataIndex="vehiculeid" Hidden="true" />
                            <ext:Column ID="Column12" runat="server" Text=" <%$ Resources:Resource,Profil_Liste_Vehicules%> " DataIndex="matricule" Width="300" />
                        </Columns>
                    </ColumnModel>                  
                    <View>
                        <ext:GridView ID="GridView6" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop6" runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup"/>
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

             <%-- affectation / désaffectation alertes --%>
             <%--<ext:Panel ID="Panel4" runat="server" Width="622" Border="false" BodyStyle="background-color:#F1F1F1;">
    <Items>
           <ext:GridPanel
                    ID="GridPanel7"
                    runat="server"
                    MultiSelect="true"
                    Scroll="Vertical"
                    Header="false"
                    Width="300"
                    Height="300"                  
                    >
                    <Store>
                        <ext:Store  ID="Store7" runat="server">
                            <Model>
                                <ext:Model ID="Model7" runat="server">
                                    <Fields>
                                        <ext:ModelField Name="alerteid" />
                                        <ext:ModelField Name="titre" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>

                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column13" runat="server"  DataIndex="alerteid" Hidden="true" />
                            <ext:Column ID="Column14" runat="server" Text=" <%$ Resources:Resource,Profil_Alerte_selectionnes%>" DataIndex="titre" Width="300" />
                        </Columns>
                    </ColumnModel>                   
                    <View>
                        <ext:GridView ID="GridView7" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop7" runat="server" DragGroup="firstGridDDGroup" DropGroup="secondGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>

                <ext:GridPanel
                    ID="GridPanel8"
                    runat="server"
                    MultiSelect="true"
                    Header="false"
                     Width="300"
                    Height="300"
                    Scroll="Vertical" >
                    <Store>
                        <ext:Store ID="Store8" runat="server">
                            <Model>
                                <ext:Model ID="Model8" runat="server">
                                    <Fields>
                                          <ext:ModelField Name="alerteid" />
                                        <ext:ModelField Name="titre" />
                                    </Fields>
                                </ext:Model>
                            </Model>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:Column ID="Column15" runat="server" DataIndex="alerteid" Hidden="true" />
                            <ext:Column ID="Column16" runat="server" Text=" <%$ Resources:Resource,Profil_Liste_Alertes%> " DataIndex="titre" Width="300" />
                        </Columns>
                    </ColumnModel>                  
                    <View>
                        <ext:GridView ID="GridView8" runat="server">
                            <Plugins>
                                <ext:GridDragDrop ID="GridDragDrop8" runat="server" DragGroup="secondGridDDGroup" DropGroup="firstGridDDGroup"/>
                            </Plugins>
                            <Listeners>
                                <AfterRender Handler="this.plugins[0].dragZone.getDragText = getDragDropText;" />
                                <Drop Handler="var dropOn = overModel ? ' ' + dropPosition + ' ' + overModel.get('libelle') : ' on empty view';" />
                            </Listeners>
                        </ext:GridView>
                    </View>  
                </ext:GridPanel>
        </Items>
        </ext:Panel>--%>

            <ext:Button ID="Button2" Type="Submit" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk">
                <Listeners>
                    <Click Handler="FnSave(#{GridPanel1},#{GridPanel3},#{GridPanel5},#{GridPanel7});" />
                </Listeners>
            </ext:Button>
        </Items>
    </ext:FormPanel>
        
    </form>
</body>
</html>
