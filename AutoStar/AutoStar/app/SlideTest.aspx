<%@ Page Title="" Language="C#" MasterPageFile="~/app/MasterPage.Master" AutoEventWireup="true" CodeBehind="SlideTest.aspx.cs" Inherits="AutoStar.app.SlideTest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="crossfade">
        <img src="Images/backgrounds/Chrysler1.jpg" alt="Image 1" />
        <img src="Images/backgrounds/Chrysler2.jpg" alt="Image 2" />
        <img src="Images/backgrounds/Freightliner1.jpg" alt="Image 3" />
        <img src="Images/backgrounds/Freightliner2.jpg" alt="Image 4" />
        <img src="Images/backgrounds/Jeep1.jpg" alt="Image 5" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
