﻿<%@ Page Title="Выполнить вход" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="IS_technopark.Account.Edit" Async="true" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br>
    <h2 style="text-align:center;">ВХОД</h2>
    <div class="login" style="text-align:center">
        <br />
        <div class='form-label' style="margin-left:400px">
        <asp:Label ID="Label1" runat="server" Text="Имя сотрудника" Font-Size="12pt"></asp:Label>
        </div>
        <div class='form-row'>
        <asp:TextBox ID="TextBox1" runat="server" Width="225px" Height="30px"  CssClass="btn btn-default"></asp:TextBox>
        </div>
        
          
        <div class="form-group">
        <br/> 
        <div class='form-label'>
        <asp:Label ID="Label2" runat="server" Text="Пароль" Font-Size="10pt"></asp:Label>
        </div>
        <asp:TextBox ID="TextBox2" runat="server" Width="225px" Height="31px" CssClass="btn btn-default"></asp:TextBox>
        <br />
        <br/>
        </div>
        <div class="form-group">
        <asp:Button ID="Button1" runat="server" Text="Вход" Width="225px" OnClick="Button1_Click" Height="40px" CssClass="btn btn-default" Font-Size="12pt" BackColor="#CEE5F3" />
        <br/>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="" ForeColor="#CC3300"></asp:Label>
        </div>
    </div>
   

</asp:Content>

