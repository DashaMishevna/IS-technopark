<%@ Page  Title="HomePage" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="IS_technopark.HomePage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <asp:Button ID="Button1" runat="server" Text="Button" Height="80px" Width="150px" OnClick="Button1_Click" />
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
</asp:Content>
