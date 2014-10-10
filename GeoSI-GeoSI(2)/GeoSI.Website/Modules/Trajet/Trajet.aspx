<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trajet.aspx.cs" Inherits="GeoSI.Website.Modules.Trajet.Trajet" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<style>
 #Panel4_Content
        {
            width:100%;
            height:100%;
            }
</style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
<ext:Panel ID="Panel4" 
                    runat="server"
                    border="false"
                    Region="Center" 
                    Header="false" BodyStyle="z-index:1;"
                    >
                    <Loader ID="Loader1" 
                        runat="server" 
                        Url="LoadTrajet.aspx" 
                        Mode="Frame">
                        <LoadMask ShowMask="true" />    
                    </Loader>
                   </ext:Panel>
</asp:Content>