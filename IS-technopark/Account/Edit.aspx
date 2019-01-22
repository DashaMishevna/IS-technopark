<%@ Page Title="Выполнить вход" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IS_technopark.Account.Edit" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

    <h2 style="text-align:center" >Вход</h2>
    <div class="login" style="text-align:center">
        <hr />
        <asp:Label ID="Label1" runat="server" Text="ФИО"></asp:Label>
        <br/>
        <asp:TextBox ID="TextBox1" runat="server" Width="225px" Height="30px"></asp:TextBox>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="Вход запрещен"></asp:Label>
        <br/> <hr />
        <asp:Label ID="Label2" runat="server" Text="Пароль"></asp:Label>
        <br/>
        <asp:TextBox ID="TextBox2" runat="server" Width="225px" type="password" Height="31px"></asp:TextBox>
        <br />
        <hr />
        <asp:Button ID="Button1" runat="server" Text="Выполнить вход" Width="225px" OnClick="Button1_Click" Height="40px"  />
  
    </div>

</asp:Content>

