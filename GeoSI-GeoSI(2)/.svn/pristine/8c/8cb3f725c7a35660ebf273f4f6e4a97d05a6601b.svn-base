<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="conForm.aspx.cs" Inherits="GeoSI.Website.Modules.VehiculeConfiguration.conForm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
    .imageup
    {
        max-width:150px;
        max-height:150px;
    }
    </style>
    <link href="../../Ressources/Styles/common/css_module.css" rel="stylesheet" type="text/css" />
     <script src="../../Ressources/Scripts/common/js_common_form.js" type="text/javascript"></script>
    <script type="text/javascript">
        function DesaffPersonnel(_iddesaffect) {
            X.DesaffectationPersonnel(_iddesaffect);
        }
    </script>
</head>
<body>
     <%-- Déclaration de la forme: fiche de détails--%>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="X" />
        <ext:TabPanel ID="TabPanel1" 
            runat="server" 
            DeferredRender="false">
            <Items>
                 <%-- Onglet1: fiche de détails--%>
            <ext:Panel ID="Panel1" runat="server" Title="Configuration Alarme vehicule">
            <Items>
    <ext:Label ID="msgErreur" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForm" Frame="true" runat="server" Url="conForm.aspx"
        Method="POST">
        <Items>
            <ext:TextField ID="vehiculeid" runat="server" Name="vehiculeid" Text="" FieldLabel="vehiculeid "
                Hidden="true" />

            <ext:TextField ID="codee" runat="server" FieldLabel="Code de vehicule" Width="310" Vtype="chainenum" MaxLength="20" />
            
            <ext:TextField ID="matricule" runat="server" Width="310" FieldLabel=" Matricule  "   MaxLength="20" />
                     <ext:TextField ID="vitesse" runat="server" Width="310" FieldLabel="Vitesse Max"   MaxLength="20" />
            <ext:TextField ID="connsomation" runat="server" Width="310" FieldLabel="Consomation Max par jour"   MaxLength="20" />
            <ext:TextField ID="kilometrage" runat="server" Width="310" FieldLabel="Kilometrage Aberrant par jour"   MaxLength="20" />
            <ext:TextField ID="dureeMax" runat="server" Width="310" FieldLabel="Duree max de conduite "   MaxLength="20" />

           
            <ext:Button ID="Button2" Type="Button" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk" OnDirectClick="updateInsert" >
        
            </ext:Button>
        </Items>
    </ext:FormPanel>
                </Items>
                </ext:Panel>

                <%--configuration cnt --%>

                      <ext:Panel ID="Panel2" runat="server" Title="Configuration Conduite non autoriser">
            <Items>
    <ext:Label ID="msgErreure" runat="server" Text="" />
    <ext:FormPanel StandardSubmit="true" ID="UserForme" Frame="true" runat="server" Url="conForm.aspx"
        Method="POST">
        <Items>
            <ext:TextField ID="TextField11" runat="server" Name="vehiculeid" Text="" FieldLabel="Id de vehicule  " Width="310"  />

            <ext:TextField ID="TextField12" runat="server" FieldLabel="Code de vehicule" Width="310" Vtype="chainenum" MaxLength="20" />
            
            <ext:TextField ID="TextField13" runat="server" Width="310" FieldLabel=" Matricule  "   MaxLength="20" />

            <ext:Panel ID="Panel3" runat="server" Header="false" Border="false" >
       <Content>     
            <table border="3">  
               <tr>
                   <td>Jour </td>
                   <td>De : </td>
                   <td>A :</td>


               </tr>
               <tr> <td >Lundi  </td> 
                   <td> <ext:TimeField ID="lundiD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="lundiF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Mardi  </td> 
                   <td> <ext:TimeField ID="mardiD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="mardiF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Mercredi  </td> 
                   <td> <ext:TimeField ID="mercrediD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="mercrediF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Jeudi  </td> 
                   <td> <ext:TimeField ID="jeudiD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="jeudiF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Vendredi  </td> 
                   <td> <ext:TimeField ID="vendrediD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="vendrediF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Samedi  </td> 
                   <td> <ext:TimeField ID="samediD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="samediF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
                <tr> <td >Dimanche  </td> 
                   <td> <ext:TimeField ID="dimancheD" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>
                   <td> <ext:TimeField ID="dimancheF" runat="server" MinTime="00:00"  MaxTime="23:59" Increment="60" Format="H:mm" /></td>

               </tr>
           <tr><td>  
               </td></tr>
               </table>
           </Content>

                </ext:Panel>
            <ext:Button ID="Button22" Type="Button" Cls="btn1" runat="server" Text="<%$ Resources:Resource,BtnSave%>"
                Icon="Disk" OnDirectClick="InsertCNA"  >
               </ext:Button>
        </Items>
    </ext:FormPanel>
                </Items>
                </ext:Panel>
                  <%-- Onglet2: affectation boitier--%>

               

                 <%-- Onglet3: Personnel affecté--%>

                </Items>
                </ext:TabPanel>
    </form>
</body>
</html>
