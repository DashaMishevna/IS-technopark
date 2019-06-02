<%@ Page Title="Выполнить вход" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IS_technopark.Account.Edit" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center;">ВХОД</h2>
        <br />
        <div style="margin-left:-50px; width: 1385px; margin-top: 0px;">
        <div class='form-label' style="margin-left:210px; text-align:right" runat="server">
        <asp:Label ID="Label_FIO" runat="server" Text="Имя сотрудника" Font-Size="12pt"></asp:Label>
        </div>
        <div class='form-row' style="text-align:left; margin-left:20px;">
        <asp:TextBox ID="TextBox_FIO" runat="server" Width="225px" Height="30px" CssClass="form-control"></asp:TextBox>
        </div> 
             <br />
             <br />
        <br/>
        <div class='form-label' style="margin-left:210px; text-align:right">
        <asp:Label ID="Label_Passw" runat="server" Text="Пароль" Font-Size="12pt"></asp:Label>
        </div>
        <div class='form-row' style="text-align:left; margin-left:20px;">
        <asp:TextBox ID="TextBox_Passw" runat="server" TextMode="Password" Width="225px" Height="31px" CssClass="form-control"></asp:TextBox>
        </div>
        <br />
        </div>
        <br />
        <div class="form-group" style="text-align:center">
        <br/>
        <asp:Button ID="Button_Edit" runat="server" Text="Вход" Width="100px" OnClick="Button1_Click" Height="35px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" />
        <br/>
        <br/>
        <asp:Label ID="Label_Mess" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
        </div>
</asp:Content>

